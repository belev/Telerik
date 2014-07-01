define(['./section'] ,function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            if (!section) {
                throw new Error('Can not add undefined section to container.');
            }

            if(!(section instanceof Section)) {
                throw new Error('Section should consist only items.');
            }

            this._sections.push(section);
        };

        Container.prototype.getData = function () {
            return this._sections;
        };

        return Container;
    }());

    return Container;
});