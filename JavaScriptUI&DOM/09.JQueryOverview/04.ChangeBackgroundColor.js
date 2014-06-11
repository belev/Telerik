var button = $('<button />').text('Change background color');
$('body').append(button);

var inputColor = $('<input />');
inputColor.attr('type', 'color');
inputColor.attr('id', 'input-color');
console.log(inputColor.attr('color', '#FFFFFF'));

$('body').append(inputColor);

button.on('click', function () {
    $('body').css('background-color', $('#input-color').val());
});

