var trashBucketManager = (function () {
    function createBucket(width, height) {
        var bucket = $('<img />',
            {
                src: 'close-box.png',
                width: width,
                height: height
            });

        return bucket;
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }


    function createTrashItem(width, height) {
        var trashItem = $('<img />',
            {
                src: 'trash.png',
                width: width,
                height: height
            });
        //trashItem.on('dragstart', onDragTrash);

        var x = getRandomInt(200, window.innerWidth - 400);
        var y = getRandomInt(200, window.innerHeight - 400);

        trashItem.css('position', 'absolute');
        trashItem.css('left', x + 'px');
        trashItem.css('top', y + 'px');

        return trashItem;
    }

    return {
        createBucket: createBucket,
        createTrashItem: createTrashItem
    }
}());


function openBox() {
    bucket.attr('src', 'open-box.png');
}

function closeBox() {
    bucket.attr('src', 'close-box.png');
}

$.event.props.push("dataTransfer");

var container = $('#container');
var bucket = trashBucketManager.createBucket(200, 200);
bucket.on("dragenter", function () {
    openBox();
});

bucket.on("dragleave", function () {
    closeBox();
});

bucket.on("drop", function (ev) {
    closeBox();
    var droppedItem = ev.dataTransfer.getData('doppedElementID');
    container.find(droppedItem).remove();

});

bucket.on('dragover', function (e) {
    e.preventDefault();
});

$(container).append(bucket);

var trashItemsCount = 5;

for (var i = 0; i < trashItemsCount; i += 1) {
    var trashItem = trashBucketManager.createTrashItem(30, 30);
    trashItem.attr('id', 'trash-item-' + i);

    $(container).append(trashItem);
}

