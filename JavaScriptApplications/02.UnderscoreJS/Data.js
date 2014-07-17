var data = (function () {
    function getMarks() {
        var mark, marks = [];
        for (var i = 0; i < 15; i += 1) {
            mark = Math.random() * 4 + 2;

            marks.push(mark);
        }

        return marks;
    }

    function getStudents() {
        var students = [];
        var people = [
            new Student({
                firstName: 'Pesho',
                lastName: 'Dimitrov',
                age: 20,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Joro',
                lastName: 'Atanasov',
                age: 30,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Anna',
                lastName: 'Zlatova',
                age: 19,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Mariq',
                lastName: 'Kacarova',
                age: 22,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Doncho',
                lastName: 'Ceckov',
                age: 29,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Ivo',
                lastName: 'Vaskov',
                age: 10,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Niki',
                lastName: 'Petkanov',
                age: 50,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Lubcho',
                lastName: 'Lubenov',
                age: 26,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Pesho',
                lastName: 'Petkanov',
                age: 20,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Lubcho',
                lastName: 'Petkanov',
                age: 26,
                marks: getMarks()
            }),
            new Student({
                firstName: 'Lubcho',
                lastName: 'Lubenov',
                age: 26,
                marks: getMarks()
            })];

        for(var i = 0; i < people.length; i += 1) {
            students.push(people[i]);
        }

        return students;
    }

    var species = ['big-cats', 'primates', 'marine-animals', 'reptile', 'birds'];
    var possibleNumberOfLegs = [2, 4, 6, 8, 100];

    function getAnimals() {
        var animals = [],
            animal;
        for (var i = 0; i < 30; i += 1) {
            var animalSpecies = species[Math.floor(Math.random() * species.length)];
            var animalNumberOfLegs = possibleNumberOfLegs[Math.floor(Math.random() * possibleNumberOfLegs.length)];

            animal = new Animal({
                numberOfLegs: animalNumberOfLegs,
                species: animalSpecies
            });

            animals.push(animal);
        }

        return animals;
    }

    var authors = ['author #1', 'author #2', 'author #3', 'author #4', 'author #5', 'author #6', 'author #7', 'author #8'];
    var names = ['test name #1', 'test name #2', 'test name #3', 'test name #4', 'test name #5', 'test name #6'];

    function getBooks() {
        var books = [];

        for (var i = 0; i < 40; i += 1) {
            books.push(new Book({
                author: authors[Math.floor(Math.random() * authors.length)],
                name: names[Math.floor(Math.random() * names.length)]
            }));
        }

        return books;
    }

    return {
        getStudents: getStudents,
        getAnimals: getAnimals,
        getBooks: getBooks
    };
}());