define(['./item'], function (Item) {
    'use strict';

    var Section;
    Section = (function () {
        function Section(title) {
            if (!title) {
                throw new Error('Section must have title.');
            }

            this.title = title;
            this._items = [];
        }

        Section.prototype.add = function (item) {
            if (!item) {
                throw new Error('Can not add undefined item to section.');
            }

            if (!(item instanceof Item)) {
                throw new Error('Section should consist only items.');
            }

            this._items.push(item);
        };

        Section.prototype.getData = function () {
            return {
                title: this.title,
                items: this._items
            };
        };
        return Section;
    }());


    return Section;
});