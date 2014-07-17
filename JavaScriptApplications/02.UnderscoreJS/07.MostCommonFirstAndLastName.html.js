var people = data.getStudents();

var grouptedPeopleByFirstName = _.groupBy(people, '_firstName');
var grouptedPeopleByLastName = _.groupBy(people, '_lastName');

var mostCommonFirstName = 'Most common first name is: ' + findMostCommonName(grouptedPeopleByFirstName);
var mostCommonLastName = 'Most common last name is: ' + findMostCommonName(grouptedPeopleByLastName);

console.log(grouptedPeopleByFirstName);
console.log(mostCommonFirstName);

console.log(grouptedPeopleByLastName);
console.log(mostCommonLastName);

function findMostCommonName(collectionOfPeople) {
    var mostCommonNameCount = 0;
    var mostCommonName = '';

    _.each(collectionOfPeople, function (groupByName, name) {
        if (mostCommonNameCount < groupByName.length) {
            mostCommonNameCount = groupByName.length;
            mostCommonName = name;
        }
    });

    return mostCommonName + ' -> ' + mostCommonNameCount + ' times.';
}