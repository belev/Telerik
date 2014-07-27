(function () {
    $('#get-students-button').on('click', function () {
        HttpRequester.getStudents()
            .then(function (responseData) {
                visualizeStudents(responseData);
            }, function (err) {
                console.log(err);
            });
    });

    $('#add-student-button').on('click', function () {
        var name = $('#student-name').val(),
            grade = $('#student-grade').val();

        HttpRequester.addStudent({
            name: name,
            grade: grade
        }).then(function (responseData) {
            var addStudentResult = $('#add-student-result');
            addStudentResult.fadeIn(200);
            addStudentResult.html('Student ' + JSON.stringify(responseData) + ' added successfully.');
            addStudentResult.fadeOut(2000);

        }, function (err) {
            var addStudentResult = $('#add-student-result');
            addStudentResult.fadeIn(200);
            addStudentResult.html(err);
            addStudentResult.fadeOut(2000);
        });
    });

    $('#delete-student-button').on('click', function () {
        var studentId = $('#student-id').val();

        HttpRequester.deleteStudent(studentId)
            .then(function (responseData) {
                var deleteStudentResult = $('#delete-student-result');
                deleteStudentResult.fadeIn(200);
                deleteStudentResult.html(JSON.stringify(responseData));
                deleteStudentResult.fadeOut(2000);
            }, function (err) {
                var deleteStudentResult = $('#delete-student-result');
                deleteStudentResult.fadeIn(200);
                deleteStudentResult.html(err);
                deleteStudentResult.fadeOut(2000);
            });
    });


    function visualizeStudents(responseData) {
        var containerToAddStudents = $('#students-get-result'),
            ul = $('<ul />'),
            li = $('<li />'),
            student,
            liText;
        console.log(responseData.students);

        for (var i in responseData.students) {
            student = responseData.students[i];

            liText = 'Id: ' + student.id + ' Name: ' + student.name + ' in ' + student.grade + ' grade.';


            ul.append($('<li />').html(liText));
        }

        containerToAddStudents.find('ul').remove();
        containerToAddStudents.append(ul);
    }
}());