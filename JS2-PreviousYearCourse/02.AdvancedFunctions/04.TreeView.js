Node.prototype.addNode = function () {
    var list = null;
    var ulNotExisting = this.querySelector("ul") == undefined || this.tagName == "ul";

    if (ulNotExisting) {
        list = this.appendChild(document.createElement("ul"));
    } else {
        list = this.querySelector("ul");
    }

    return list.appendChild(document.createElement("li"));
};

Node.prototype.content = function (cont) {
    var anchor = document.createElement("a");
    anchor.href = "#";
    anchor.innerText = cont;
    this.appendChild(anchor);
};

var treeViewControls = (function () {
    var treeRoot = null;

    function treeView(selector) {
        var treeRoot = document.querySelector(selector);
        return treeRoot;
    }

    function addNode() {
        return treeRoot.addNode();
    }

    return {
        treeView: treeView,
        addNode: addNode
    };
})();

function addHandlers() {
    function collapseLists(node, isRoot) {
        var lists = node.getElementsByTagName("ul");
        var i = isRoot ? 1 : 0;

        for (; i < lists.length; i++) {
            lists[i].style.display = "none";
        }
    }

    function expandList(node) {
        node.style.display = "block";

        // collapse inner lists
        var lists = node.querySelectorAll("ul");
        for (var i = 0; i < lists; i++) {
            collapseLists(lists[i], false);
        }
    }

    function toggleList(node) {
        // reverse the state of a list
        if (node.style.display == "block") {
            collapseLists(node.parentElement, false);
        } else {
            expandList(node);
        }
    }

    var root = document.body.querySelector(".tree-view");
    collapseLists(root, true);

    var items = root.querySelectorAll("a");
    for (var i = 0; i < items.length; i++) {

        items[i].onclick = function (e) {
            toggleList(e.target.nextElementSibling);
        };
    }
}