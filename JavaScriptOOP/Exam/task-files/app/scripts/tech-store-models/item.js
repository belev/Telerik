define(['tech-store-models/item-types'], function (ITEM_TYPES) {
    var Item;
    Item = (function () {
        var ITEM_MIN_NAME_LENGTH = 6,
            ITEM_MAX_NAME_LENGTH = 40;

        function Item(type, name, price) {
            if (!ITEM_TYPES[type.toUpperCase()]) {
                throw {
                    message: 'Invalid item type. The item type can be on the following: accessory, smart-phone, notebook, pc or tablet.'
                }
            }

            if (typeof name !== 'string') {
                throw {
                    message: 'Item name should be a string.'
                }
            }

            if (name.length < ITEM_MIN_NAME_LENGTH || name.length > ITEM_MAX_NAME_LENGTH) {
                throw {
                    message: 'Item name should be between 6 and 40 symbols.'
                }
            }

            if(typeof price !== 'number') {
                throw {
                    message: 'Item price must be a decimal floating-point number.'
                }
            }

            this._type = ITEM_TYPES[type.toUpperCase()];
            this._name = name;
            this._price = price;
        }

        return Item;
    }());

    return Item;
});