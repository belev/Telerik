var students = data.getStudents();

var allBetween18And24 = _.filter(students, function(student) {
   return (student.getAge() > 18 && student.getAge() < 24);
});

_.each(allBetween18And24, function(student) {
    console.log(student.getFullName())
});