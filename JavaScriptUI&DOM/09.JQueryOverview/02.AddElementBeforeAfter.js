// extend jquery functionality
$.prototype.addElementBefore = function (elementToAppend) {
    $(this).before(elementToAppend);
};

$.prototype.addElementAfter = function (elementToPrepend) {
    $(this).after(elementToPrepend);
};

var countBefore = 0;
var countAfter = 0;

$('#add-before').on('click', function () {
    countBefore++;

    var elementToAddBefore = $('<div />');
    elementToAddBefore.addClass('added-before');
    elementToAddBefore.text('added before the element ' + countBefore);

    $('.elementToSurround').addElementBefore(elementToAddBefore);
});

$('#add-after').on('click', function () {
    countAfter++;

    var elementToAddAfter = $('<div />');
    elementToAddAfter.addClass('added-after');
    elementToAddAfter.text('added after the element ' + countAfter);

    $('.elementToSurround').addElementAfter(elementToAddAfter);
});