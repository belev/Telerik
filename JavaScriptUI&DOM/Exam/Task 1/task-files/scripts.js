function createImagesPreviewer(selector, items) {
    var BIG_IMAGE_WIDTH = 430,
        BIG_IMAGE_HEIGHT = 440,
        SMALL_IMAGE_WIDTH = 150,
        SMALL_IMAGE_HEIGHT = 150,
        BIG_IMAGE_FONT_SIZE = 30,
        SMALL_IMAGE_FONT_SIZE = 20;

    var container = document.querySelector(selector);

    var bigImageContainer = document.createElement('div');
    bigImageContainer.className = 'big-image-container';
    bigImageContainer.style.width = 500 + 'px';
    bigImageContainer.style.height = 450 + 'px';
    bigImageContainer.style.display = 'inline-block';
    bigImageContainer.style.textAlign = 'center';
    bigImageContainer.style.fontSize = BIG_IMAGE_FONT_SIZE + 'px';

    var allImagesContainer = document.createElement('div');
    allImagesContainer.className = 'all-images-container';
    allImagesContainer.style.display = 'inline-block';

    var filter = document.createElement('div');
    filter.className = 'filter';
    filter.style.textAlign = 'center';

    var filterTitle = document.createElement('div');
    filterTitle.className = 'filter-title';
    filterTitle.innerHTML = 'Filter';

    var filterInput = document.createElement('input');
    filterInput.type = 'text';
    filterInput.className = 'filter-input';

    filter.appendChild(filterTitle);
    filter.appendChild(filterInput);
    allImagesContainer.appendChild(filter);

    var allImages = document.createElement('ul');
    allImages.className = 'all-images-ul-list';
    allImages.style.width = 200 + 'px';
    allImages.style.height = 450 + 'px';
    allImages.style.overflow = 'scroll';
    allImages.style.listStyleType = 'none';
    allImages.style.textAlign = 'center';

    var imageHolder = document.createElement('li');
    imageHolder.className = 'image-holder';

    var imageTitle = document.createElement('div');
    imageTitle.style.display = 'block';
    imageTitle.style.fontWeight = 'bold';
    imageTitle.className = 'image-title';

    var image = document.createElement('img');
    image.className = 'image';

    for (var i = 0, len = items.length; i < len; i += 1) {
        imageTitle.innerHTML = items[i].title;
        image.src = items[i].url;
        image.style.borderRadius = 15 + 'px';

        if (i == 0) {
            image.style.width = BIG_IMAGE_WIDTH + 'px';
            image.style.height = BIG_IMAGE_HEIGHT + 'px';

            bigImageContainer.appendChild(imageTitle.cloneNode(true));
            bigImageContainer.appendChild(image.cloneNode(true));
        }

        image.style.width = SMALL_IMAGE_WIDTH + 'px';
        image.style.height = SMALL_IMAGE_HEIGHT + 'px';
        imageTitle.style.fontSize = SMALL_IMAGE_FONT_SIZE + 'px';

        imageHolder.appendChild(imageTitle.cloneNode(true));
        imageHolder.appendChild(image.cloneNode(true));

        allImages.appendChild(imageHolder.cloneNode(true));

        while (imageHolder.firstChild) {
            imageHolder.removeChild(imageHolder.firstChild);
        }

    }

    addEventListenersToImages();
    filterInput.addEventListener('keyup', onInputFilterChange);

    allImagesContainer.appendChild(allImages);

    container.appendChild(bigImageContainer);
    container.appendChild(allImagesContainer);

    function onMouseOver() {
        this.style.backgroundColor = '#CCCCCC';
    }

    function onMouseOut() {
        this.style.backgroundColor = 'white';
    }

    function onImageClick() {
        var clickedImageHolder = this;

        var clickedImageTitle = clickedImageHolder.querySelector('.image-title').innerHTML,
            clickedImageSource = clickedImageHolder.querySelector('.image').getAttribute('src');

        bigImageContainer.querySelector('.image-title').innerHTML = clickedImageTitle;
        bigImageContainer.querySelector('.image').setAttribute('src', clickedImageSource);
    }

    function onInputFilterChange() {
        var filterValue = this.value.toLowerCase();
        var imageHolders = allImages.querySelectorAll('.image-holder');

        for (var i = 0; i < imageHolders.length; i += 1) {
            var imageTitle = imageHolders[i].querySelector('.image-title').innerHTML.toLowerCase();
            console.log(imageTitle);

            if (imageTitle.indexOf(filterValue) == -1) {
                imageHolders[i].style.display = 'none';
            } else {
                imageHolders[i].style.display = '';
            }
        }
    }

    function addEventListenersToImages() {
        var imageHolders = allImages.querySelectorAll('.image-holder');

        for (var i = 0; i < imageHolders.length; i++) {
            imageHolders[i].addEventListener('mouseover', onMouseOver);
            imageHolders[i].addEventListener('mouseout', onMouseOut);
            imageHolders[i].addEventListener('click', onImageClick);
        }
    }
}