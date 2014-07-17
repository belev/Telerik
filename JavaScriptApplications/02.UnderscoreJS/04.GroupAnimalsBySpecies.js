var animals = data.getAnimals();
var sortedAnimalsByLegs = _.sortBy(animals, function (animal) {
    return animal.getNumberOfLegs();
});

var groupedAnimals = _.groupBy(sortedAnimalsByLegs, '_species');
console.log(groupedAnimals);