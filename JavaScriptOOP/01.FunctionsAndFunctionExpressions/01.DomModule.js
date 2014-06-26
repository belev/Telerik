var domModule = (function () {
    function getElement(selector) {
        var selectedElement = document.querySelector(selector);
        return selectedElement;
    }

    function getElements(selector) {
        var selectedElements = document.querySelectorAll(selector);
        return selectedElements;
    }

    function appendChildToParent(childToAppend, parentSelector) {
        var parent = getElement(parentSelector);

        if (!parent) {
            throw new Error("Can not append element to non existing parent.");
        }

        parent.appendChild(childToAppend);

        document.body.appendChild(parent);
    }

    function removeElement(parentSelector, childSelector) {
        var parent = getElement(parentSelector);
        var child = getElement(childSelector);

        if (!parent) {
            throw new Error("Can not remove child element from non existing parent.");
        }

        parent.removeChild(child);
    }

    function getElementsByCssSelector(cssSelector) {
        return getElements(cssSelector);
    }

    function attachEvent(elementSelector, eventType, handler) {
        var elements = getElements(elementSelector);

        if (!elements) {
            throw new Error("Can not attach event to non existing element.");
        }
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventType, handler, false);
        }
    }

    var buffer = {};
    var MAX_BUFFER_SIZE = 100;

    function appendElementToBuffer(parentSelector, element) {
        var parent = getElement(parentSelector);

        if (!buffer[parent]) {
            buffer[parent] = [];
        }

        buffer[parent].push(element);

        if (buffer[parent].length == MAX_BUFFER_SIZE) {
            var fragment = document.createDocumentFragment();

            for (var i = 0; i < buffer[parent].length; i++) {
                var child = buffer[parent][i];

                fragment.appendChild(child);
            }

            parent.appendChild(fragment);
            buffer[parent] = [];
        }
    }

    return {
        addChild: appendChildToParent,
        removeElement: removeElement,
        attachEvent: attachEvent,
        addElementToBuffer: appendElementToBuffer,
        getElementByCssSelector: getElementsByCssSelector
    };
})();