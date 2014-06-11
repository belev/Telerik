function nextSlide() {
    currentSlideIndex++;

    if (currentSlideIndex >= slides.length) {
        currentSlideIndex = 0;
    }

    clearInterval(auto);
    clearTimeout(timeout);
    auto = setInterval(nextSlide, INTERVAL_TIME);
    render(currentSlideIndex);
}

function previousSlide() {
    currentSlideIndex--;

    if (currentSlideIndex < 0) {
        currentSlideIndex = slides.length - 1;
    }

    clearInterval(auto);
    clearTimeout(timeout);
    auto = setInterval(nextSlide, INTERVAL_TIME);
    render(currentSlideIndex);
}

function render() {
    slider.fadeOut(500);

    timeout = setTimeout(function () {
        slider.html(slides[currentSlideIndex]);
        slider.fadeIn(700)
    }, 500);
}

var dice = '<h3>Dice image</h3><img src="logo.png">';
var abstract = '<h3>Abstract painting</h3><img src="abstract.jpg">';
var article = '<article><h2>Article header</h2><p>Some text as paragraph</p></article>';
var articleWithDiv = '<article><h2>Article header</h2><div>Some text as div</div></article>';

var slides = [dice, articleWithDiv, abstract, article];
var INTERVAL_TIME = 5000;

$('#previous').on('click', previousSlide);
$('#next').on('click', nextSlide);

var slider = $('#slider');
slider.css('margin-left', $(window).width() / 2 - 100);

var currentSlideIndex = 0;
var auto = setInterval(nextSlide, INTERVAL_TIME);
var timeout = 0;

render();
