var movingDivsModule = (function () {
    var DIV_WIDTH = 20,
        DIV_HEIGHT = 20,
        DIV_BORDER_RADIUS = 4000,
        DIV_BORDER_WIDTH = 1,
        RECT_WIDTH = 300,
        RECT_HEIGHT = 300,
        DIV_MOVE_SPEED = 12,
        ELLIPSE_CENTER_X = 150,
        ELLIPSE_CENTER_Y = 150,
        ELLIPSE_RADIUS = 150;

    function addMovingDiv(movingType, top, left) {
        var div = generateDiv(top, left);
        document.body.appendChild(div);

        if (movingType == 'ellipse') {
            moveDivEllipse(div);
        }
        else if (movingType == 'rect') {
            moveDivRectangular(div);
        }
    }

    function generateDiv(top, left) {
        var div = document.createElement('div');
        div.style.width = DIV_WIDTH + 'px';
        div.style.height = DIV_HEIGHT + 'px';

        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
        div.style.borderColor = getRandomColor();

        div.style.borderRadius = DIV_BORDER_RADIUS + "px";
        div.style.borderWidth = DIV_BORDER_WIDTH + "px";
        div.style.borderStyle = 'solid';

        div.style.position = 'absolute';
        div.style.top = top + 'px';
        div.style.left = left + 'px';

        return div;
    }

    // all divs moving in rectangle, move in rectangle with width = 300px and height = 300px
    function moveDivRectangular(div) {
        var top = parseInt(div.style.top.substring(0, div.style.top.length - 2));
        var left = parseInt(div.style.left.substring(0, div.style.left.length - 2));

        var startTop = top;
        var startLeft = left;

        var leftSpeed = DIV_MOVE_SPEED;
        var topSpeed = 0;

        function moveOnRect() {

            if (left + DIV_WIDTH + 2 >= RECT_WIDTH) {
                leftSpeed = 0;
                topSpeed = DIV_MOVE_SPEED;

                left = RECT_WIDTH - DIV_WIDTH;
            }
            if (top + DIV_HEIGHT + 2 >= RECT_HEIGHT) {
                leftSpeed = -DIV_MOVE_SPEED;
                topSpeed = 0;

                top = RECT_HEIGHT - DIV_HEIGHT;
            }
            if (left < startLeft) {
                leftSpeed = 0;
                topSpeed = -DIV_MOVE_SPEED;

                left = startLeft;
            }
            if (top < startTop) {
                leftSpeed = DIV_MOVE_SPEED;
                topSpeed = 0;

                top = startTop;
            }

            div.style.top = top + 'px';
            div.style.left = left + 'px';

            left += leftSpeed;
            top += topSpeed;
        }

        setInterval(moveOnRect, 100);
    }

    function moveDivEllipse(div) {
        var movementAngle = 0;

        function moveOnEllipse() {
            movementAngle += 3;
            if (movementAngle == 360) {
                movementAngle = 0;
            }

            var left = ELLIPSE_CENTER_X + Math.cos((2 * Math.PI / 180) * (movementAngle)) * ELLIPSE_RADIUS;
            var right = 2 * (ELLIPSE_CENTER_Y + Math.sin((2 * Math.PI / 180) * (movementAngle)) * ELLIPSE_RADIUS);
            div.style.left = left + "px";
            div.style.top = right + "px";
        }

        setInterval(moveOnEllipse, 100);
    }


    function getRandomColor() {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }

    return {
        addMovingDiv: addMovingDiv
    };
}());