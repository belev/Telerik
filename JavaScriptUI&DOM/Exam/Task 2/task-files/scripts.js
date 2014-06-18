$.fn.gallery = function (colsCount) {
    var columnsInRow;

    if (colsCount) {
        columnsInRow = colsCount;
    } else {
        columnsInRow = 4;
    }

    var $that = this;
    $that.addClass('gallery');
    $that.addClass('disabled-background');


    $that.width(columnsInRow * ($that.find('.image-container').first().width() + 10));

    if ($that.find('.selected').children().length > 0) {
        $that.find('.image-container').addClass('blurred');
    }

    $that.find('.image-container').children().on('click', onImageClick);
    $that.find('.selected').children().on('click', onSelectedImageClick);

    function onImageClick() {
        if ($that.find('.image-container').attr('class').indexOf('blurred') != -1) {
            return;
        }

        var $this = $(this);

        var currentImageNumber = $this.data('info');

        changeImagesSources(currentImageNumber);

        $that.find('.image-container').addClass('blurred');
        $that.find('.selected').show();
    }

    function onSelectedImageClick() {
        var $this = $(this);

        if ($this.attr('class') == 'current-image') {
            $that.find('.selected').hide();
            $that.find('.image-container').removeClass('blurred');
        } else {
            var clickedImageSource = $this.children().first().attr('src');
            var start = clickedImageSource.indexOf('/');
            var end = clickedImageSource.indexOf('.');

            var imageNumber = parseInt(clickedImageSource.substring(start + 1, end));

            changeImagesSources(imageNumber);
        }
    }

    function changeImagesSources(imgNumber) {
        var previousImageNumber = imgNumber - 1,
            nextImageNumber = imgNumber + 1;


        if (previousImageNumber <= 0) {
            previousImageNumber = 12;
        }

        if (nextImageNumber > 12) {
            nextImageNumber = 1;
        }

        var selectedImages = $that.find('.selected').children();
        $(selectedImages[0]).children().first().attr('src', 'imgs/' + previousImageNumber + '.jpg');
        $(selectedImages[1]).children().first().attr('src', 'imgs/' + imgNumber + '.jpg');
        $(selectedImages[2]).children().first().attr('src', 'imgs/' + nextImageNumber + '.jpg');
    }
};