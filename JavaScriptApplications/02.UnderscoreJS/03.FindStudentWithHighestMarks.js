var students = data.getStudents();

var sortedStudentsByMark = _.sortBy(students, function (student) {
    var averageMark = 0;
    _.each(student.getMarks(), function (mark) {
        averageMark += mark;
    });

    averageMark /= student.getMarks().length;

    student.setAverageMark(averageMark);
    return averageMark;
});

console.log('All students: ');
console.log(sortedStudentsByMark);

console.log('Student with highest average mark: ');
console.log(sortedStudentsByMark[sortedStudentsByMark.length - 1]);