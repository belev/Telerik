var Book = function (params) {
    this._author = params.author;
    this._name = params.name;
};

Book.prototype = {
    getAuthor: function () {
        return this._author;
    },
    getName: function () {
        return this._name;
    }
};