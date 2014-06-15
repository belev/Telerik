function changeImage(direction) {
    var elements = document.getElementsByClassName("hideable");

    var visibleID = getVisibleElementIndex(elements);
    elements[visibleID].style.display = "none";

    if (direction == 'previous') {
        var makeVisible = getPreviousElementIndex(visibleID, elements.length);
    } else if (direction == 'next') {
        var makeVisible = getNextElementIndex(visibleID, elements.length);
    }

    elements[makeVisible].style.display = "block";
}

function getVisibleElementIndex(elements) {
    var visibleID = -1;
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].style.display == "block") {
            visibleID = i;
        }
    }
    return visibleID;
}

function getPreviousElementIndex(currentIndex, arrayLength) {
    if (currentIndex == 0) return arrayLength - 1;
    else return currentIndex - 1;
}

function getNextElementIndex(currentIndex, arrayLength) {
    if (currentIndex == arrayLength - 1) return 0;
    else return currentIndex + 1;
}

function setComponents() {
    var IMAGES_COUNT = 6;
    var ul = document.getElementById("images-holder");

    for (var i = 1; i <= IMAGES_COUNT; i++) {
        var path = "images/img" + i + ".jpg";

        var li = document.createElement("li");
        li.innerHTML = '<img id="slide-image" src="' + path + '" width="300px" height="200px">';
        li.className = 'hideable';

        if (i == 1) {
            li.style.display = 'block';
        } else {
            li.style.display = 'none';
        }

        ul.appendChild(li);
    }

    var previousButton = document.getElementById('previous-button');
    previousButton.addEventListener('click', function () {
        changeImage("previous");
    });

    var nextButton = document.getElementById('next-button');
    nextButton.addEventListener('click', function () {
        changeImage("next");
    });
}/**
 * Created by HP on 22-May-14.
 */
