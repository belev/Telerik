define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content, type) {
            if (!content) {
                throw new Error('Item must have content.');
            }

            this.content = content;

            if (type) {
                this.type = type;
            }
        }

        Item.prototype.getData = function () {
            return {
                content: this.content
            }
        };

        return Item;
    })();

    return Item;
});