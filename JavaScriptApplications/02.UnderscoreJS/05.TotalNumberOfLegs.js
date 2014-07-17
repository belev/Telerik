var animals = data.getAnimals();

var totalNumberOfLegs = 0;
var allNumberOfLegsAsString = '';

_.each(animals, function (animal) {
    allNumberOfLegsAsString += animal.getNumberOfLegs() + ' + ';
    totalNumberOfLegs += animal.getNumberOfLegs();
});

console.log('All number of legs are: ');
console.log(allNumberOfLegsAsString + '= ' + totalNumberOfLegs);