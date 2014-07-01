define(['./section'] ,function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this.sections = [];
        }

        Container.prototype.add = function (section) {
            if (!section) {
                throw new Error('Can not add undefined section to container.');
            }

            if(!(section instanceof Section)) {
                throw new Error('Section should consist only items.');
            }

            this.sections.push(section);
        };

        Container.prototype.getData = function () {
            var result = [];
            for (var i in this.sections) {
                result.push(this.sections[i]);
            }

            return result;
        };

        return Container;
    }());

    return Container;
});