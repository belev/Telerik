function getMembersAsTree(familyMembers) {

    function TreeNode(name) {
        this.parent = false;
        this.name = name;
        this.partner = false;
        this.children = [];
        this.female = false;
    }

    function createTreeFromMembers() {
        var allFamilyMembers = [];

        for (var i = 0; i < familyMembers.length; i++) {
            var currentMember = getCurrentMemberAsTreeNode(familyMembers[i].mother);
            currentMember.female = true;

            // make connection between husbands and wives
            if (!currentMember.partner) {
                currentMember.partner = getCurrentMemberAsTreeNode(familyMembers[i].father);
                currentMember.partner.partner = currentMember;
            }

            // for all the children - creates (or gets) a child and sets its parent property
            for (var j = 0; j < familyMembers[i].children.length; j++) {
                var currentChild = getCurrentMemberAsTreeNode(familyMembers[i].children[j]);
                currentChild.parent = currentMember;

                currentMember.children.push(currentChild);
            }
        }

        return allFamilyMembers;

        function getCurrentMemberAsTreeNode(name) {
            for (var i = 0; i < allFamilyMembers.length; i++) {

                if (name == allFamilyMembers[i].name) {
                    return allFamilyMembers[i];
                }
            }

            var memberAsNode = new TreeNode(name);
            allFamilyMembers.push(memberAsNode);

            return memberAsNode;
        }
    }

    function findGrandParents() {
        var grandParents = [];

        for (var i = 0; i < membersAsTree.length; i++) {
            if (!membersAsTree[i].parent && membersAsTree[i].children.length > 0) {
                grandParents.push(membersAsTree[i]);
            }
        }

        return grandParents;
    }

    function setNodeDepths (grandparents, members) {
        var depthY = 0;
        var depthsX = [];

        while (grandParents.length > 0) {

            if (!depthsX[depthY]) {
                depthsX[depthY] = 0;
            }

            var len = grandParents.length;
            var shownPartners = [];

            for (var i = 0; i < len; i++) {
                // we have added this member already
                if (shownPartners.indexOf(grandParents[i].name) != -1) {
                    continue;
                }

                grandparents[i].depthX = depthsX[depthY]++;
                grandparents[i].depthY = depthY;

                if (grandparents[i].partner) {
                    shownPartners.push(grandparents[i].partner.name);
                    grandparents[i].partner.depthX = depthsX[depthY]++;
                    grandparents[i].partner.depthY = depthY;
                }
                else {
                    // without partner can not have children
                    continue;
                }

                // get parents children, if current parent children are not set, than get the children from its partner
                var children = grandparents[i].children;

                if (children.length === 0) {
                    children = grandparents[i].partner.children;
                }

                for (var j = 0; j < children.length; j++) {
                    grandparents.push(children[j]);
                }
            }

            // remove all grand parents which are used
            grandparents.splice(0, len);
            depthY++;
        }

        return members;
    }

    var membersAsTree = createTreeFromMembers();
    var grandParents = findGrandParents();

    var membersWithDepths = setNodeDepths(grandParents, membersAsTree);

    return membersWithDepths;
}