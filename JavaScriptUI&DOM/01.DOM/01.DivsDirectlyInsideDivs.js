var getAllDivsDirectlyInsideOtherDivsModule = (function () {
    function getAllDirectlyInsideDivsByQuery() {
        var divMatches = document.querySelectorAll('div > div');

        for (var i = 0; i < divMatches.length; i++) {
            console.log(divMatches[i].outerHTML);
            console.log('---------------------------------------------------------------------------------');
        }

        return 'That were all divs directly inside other divs by query selector. Answer by query selector: ' + divMatches.length;
    }

    function getAllDirectlyInsideDivsByTagName(elements) {
        var counter = 0;
        for (var i = 0; i < elements.length; i++) {
            var child = elements[i];
            if (child.parentNode.nodeName == 'DIV' && child.nodeName == 'DIV') {
                counter++;

                console.log(child.outerHTML);
                console.log('--------------------------------------------------------------------------------');
            }

            if (child.nodeType === 1) {
                getAllDirectlyInsideDivsByTagName(child, counter);
            }
        }

        return 'That were all divs directly inside other divs by tag name. Answer by tag name: ' + counter;
    }

    var moduleFunctions = {};
    moduleFunctions.byQuerySelector = getAllDirectlyInsideDivsByQuery;
    moduleFunctions.byTagName = getAllDirectlyInsideDivsByTagName;

    return moduleFunctions;
}());