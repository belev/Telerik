function Student(firstName, lastName, grade) {
    if (grade <= 0 || grade > 12) {
        throw new RangeError("Grade value must be between 1 - 12");
    }

    return{
        firstName: firstName,
        lastName: lastName,
        grade: grade
    };
}

function addStudentToTable(student) {
    var currentRow = $('<tr />');
    currentRow.append($('<td />').text(student.firstName));
    currentRow.append($('<td />').text(student.lastName));
    currentRow.append($('<td />').text(student.grade));

    table.append(currentRow);
}

var students = [
    new Student('Pesho', 'Petrov', 2),
    new Student('Gosho', 'Peshev', 11),
    new Student('Maria', 'Dimitrova', 8),
    new Student('Dimitar', 'Marinov', 12),
    new Student('Stamo', 'Slavov', 5)
];

var table = $('<table />');
table.css({'border-collapse': 'collapse'});
table.attr('border', '2px solid black');


var headingCellsRow = $('<tr />');
headingCellsRow.append($('<th />').text('First name'));
headingCellsRow.append($('<th />').text('Last name'));
headingCellsRow.append($('<th />').text('Grade'));

table.append(headingCellsRow);

for (var i = 0; i < students.length; i++) {
    addStudentToTable(students[i]);
}

$('#add-student').on('click', function () {
    var studentInfo = $('#student-info').val();

    var rawStudentData = studentInfo.split(' ');

    if (rawStudentData.length != 3) {
        throw new Error('Invalid student info input!');
    }

    var firstName = rawStudentData[0];
    var lastName = rawStudentData[1];
    var grade = parseInt(rawStudentData[2]);

    var student = new Student(firstName, lastName, grade);

    addStudentToTable(student);
});

$('#wrapper').append(table);