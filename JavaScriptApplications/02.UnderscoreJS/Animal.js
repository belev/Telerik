var Animal = function (params) {
    this._numberOfLegs = params.numberOfLegs;
    this._species = params.species;
};

Animal.prototype = {
    getNumberOfLegs: function () {
        return this._numberOfLegs;
    },
    getSpecies: function () {
        return this._species;
    }
};