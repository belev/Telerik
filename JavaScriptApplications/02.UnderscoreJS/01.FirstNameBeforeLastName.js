var students = data.getStudents();

var studentsWithFirstNameBeforeLastName = _.filter(students, function (student) {
    return student.getFirstName() < student.getLastName();
});

console.dir(_.sortBy(studentsWithFirstNameBeforeLastName, function (student) {
    return student.getFullName();
}));