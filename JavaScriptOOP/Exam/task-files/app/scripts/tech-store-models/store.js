define(['tech-store-models/item', 'tech-store-models/item-types'], function (Item, ITEM_TYPES) {
    var Store;
    Store = (function () {
        var STORE_MIN_NAME_LENGTH = 6,
            STORE_MAX_NAME_LENGTH = 30;

        function sortItemsByName(itemsCollection) {
            itemsCollection.sort(function (firstItem, secondItem) {
                var firstItemName = firstItem._name.toLowerCase();
                var secondItemName = secondItem._name.toLowerCase();

                if (firstItemName < secondItemName) {
                    return -1;
                }

                if (firstItemName > secondItemName) {
                    return 1;
                }

                return 0;
            });

            return itemsCollection;
        }

        // types are taken as an object with the wanted types. The object take is similar to those in item-types.js
        // but in it there are only the types which items we want to take
        function getItemsByTypes(types, itemsCollection) {
            var itemsToReturn = [];

            for (var i in itemsCollection) {
                var item = itemsCollection[i];

                if (types[item._type.toUpperCase()]) {
                    itemsToReturn.push(item);
                }
            }

            return itemsToReturn;
        }

        function getFilteredItemsByPrice(options, itemsCollection) {
            options = options || {};

            var minPrice = options.min || 0;
            var maxPrice = options.max || Number.POSITIVE_INFINITY;

            var itemsInPriceRange = [];

            for (var i in itemsCollection) {
                var item = itemsCollection[i];

                if (item._price > minPrice && item._price < maxPrice) {
                    itemsInPriceRange.push(item);
                }
            }

            itemsInPriceRange.sort(function (firstItem, secondItem) {
                return firstItem._price - secondItem._price;
            });

            return itemsInPriceRange;
        }

        function countItemsByType(itemsCollection) {
            var itemCounts = {};

            for (var index in itemsCollection) {
                var item = itemsCollection[index];

                // if the current item type is not set as an itemCounts property, we set it
                itemCounts[item._type] = itemCounts[item._type] || 0;
                itemCounts[item._type] += 1;
            }

            return itemCounts;
        }

        function getItemsByPartOfName(partOfName, itemsCollection) {
            var itemsByPartOfName = [];

            partOfName = partOfName.toLowerCase();

            for (var i in itemsCollection) {
                var item = itemsCollection[i];
                var itemName = item._name.toLowerCase();

                if (itemName.indexOf(partOfName) !== -1) {
                    itemsByPartOfName.push(item);
                }
            }

            return itemsByPartOfName;
        }

        function Store(name) {
            if (typeof name !== "string") {
                throw {
                    message: 'Store name should be a string.'
                }
            }

            if (name.length < STORE_MIN_NAME_LENGTH || name.length > STORE_MAX_NAME_LENGTH) {
                throw {
                    message: 'Store name should be between 6 and 30 symbols.'
                }
            }

            this._name = name;
            this._items = [];
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw {
                        message: 'Store can have only items of type Item.'
                    }
                }

                this._items.push(item);

                return this;
            },
            getAll: function () {
                var allItems = this._items.slice(0);

                allItems = sortItemsByName(allItems);
                return allItems;
            },
            getSmartPhones: function () {
                var smartPhoneType = {
                    'SMART-PHONE': ITEM_TYPES['SMART-PHONE']
                };
                var smartPhones = getItemsByTypes(smartPhoneType, this._items.slice(0));
                smartPhones = sortItemsByName(smartPhones);

                return smartPhones;
            },
            getMobiles: function () {
                var mobileTypes = {
                    'SMART-PHONE': ITEM_TYPES['SMART-PHONE'],
                    TABLET: ITEM_TYPES.TABLET
                };
                var mobiles = getItemsByTypes(mobileTypes, this._items.slice(0));
                mobiles = sortItemsByName(mobiles);

                return mobiles;
            },
            getComputers: function () {
                var computerTypes = {
                    NOTEBOOK: ITEM_TYPES.NOTEBOOK,
                    PC: ITEM_TYPES.PC
                };
                var computers = getItemsByTypes(computerTypes, this._items.slice(0));
                computers = sortItemsByName(computers);

                return computers;
            },
            filterItemsByType: function (filterType) {
                var itemType = {};
                itemType[filterType.toUpperCase()] = filterType;

                var itemsByType = getItemsByTypes(itemType, this._items.slice(0));
                itemsByType = sortItemsByName(itemsByType);

                return itemsByType;
            },
            filterItemsByPrice: function (options) {
                var itemsInPriceRange = getFilteredItemsByPrice(options, this._items.slice(0));

                return itemsInPriceRange;
            },
            countItemsByType: function () {
                var itemsByTypesCounts = countItemsByType(this._items.slice(0));
                return itemsByTypesCounts
            },
            filterItemsByName: function (partOfName) {
                var itemsFilteredByPartOfName = getItemsByPartOfName(partOfName, this._items.slice(0));
                itemsFilteredByPartOfName = sortItemsByName(itemsFilteredByPartOfName);

                return itemsFilteredByPartOfName;
            }
        };

        return Store;
    }());

    return Store;
});