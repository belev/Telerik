(function ($) {
    $.fn.listview = function (itemsToDisplay) {
        var $this = $(this);

        var templateId = $this.data('template');
        var templateSource;

        if (templateId) {
            templateSource = $('#' + templateId).html();
        }
        else {
            templateSource = $('#students-table-template').html();
        }

        var template = Handlebars.compile(templateSource);

        var result = template(itemsToDisplay);
        console.log(result);

        $this.append(result);

        return $this;
    }
}($));

var books = {
    books: [
        { id: 1, title: 'JavaScript: The good parts'},
        { id: 2, title: 'Secrets of the JavaScript Ninja'},
        { id: 3, title: 'Core HTML5 Canvas: Graphics, Animation, and Game Development'},
        { id: 4, title: 'JavaScript Patterns'},
    ]
};

var students = {
    students: [
        { name: 'Petar Petrov', mark: 5.5 },
        { name: 'Stamat Georgiev', mark: 4.7 },
        { name: 'Maria Todorova', mark: 6 },
        { name: 'Georgi Geshov', mark: 3.7 },
        { name: 'Anna Hristova', mark: 4 },
    ]
};

$('#books-list').listview(books);
$('#students-table-body').listview(students);
$('#div-students-table').listview(students);