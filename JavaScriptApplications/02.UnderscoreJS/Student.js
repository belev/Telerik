var Student = function (params) {
    this._firstName = params.firstName;
    this._lastName = params.lastName;
    this._age = params.age;
    this._marks = params.marks;
};

Student.prototype = {
    getFirstName: function () {
        return this._firstName;
    },
    getLastName: function () {
        return this._lastName;
    },
    getAge: function () {
        return this._age
    },
    getMarks: function () {
        return this._marks.slice(0);
    },
    getFullName: function () {
        return this._firstName + ' ' + this._lastName;
    },
    setAverageMark: function (averageMark) {
        this._averageMark = averageMark;
    }
};
