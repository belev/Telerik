var CanvasDrawer = function (selector) {
    var LINE_WIDTH = 2,
        STROKE_COLOR = 'black',
        FILL_COLOR = 'lightgreen';

    var canvas = document.querySelector(selector);
    var ctx = canvas.getContext('2d');

    ctx.lineWidth = LINE_WIDTH;
    ctx.strokeStyle = STROKE_COLOR;
    ctx.fillStyle = FILL_COLOR;

    function drawRect(position, width, height) {
        ctx.beginPath();

        ctx.rect(position.x, position.y, width, height);

        ctx.fill();
        ctx.stroke();
    }

    function drawCircle(centerPosition, radius) {
        ctx.beginPath();

        ctx.arc(centerPosition.x, centerPosition.y, radius, 0, 2 * Math.PI);

        ctx.fill();
        ctx.stroke();
    }

    function drawLine(fromPosition, toPosition) {
        ctx.beginPath();
        ctx.moveTo(fromPosition.x, fromPosition.y);
        ctx.lineTo(toPosition.x, toPosition.y);
        ctx.stroke();
    }

    function Position(x, y) {
        this.x = x;
        this.y = y;
    }

    return {
        drawRect: drawRect,
        drawCircle: drawCircle,
        drawLine: drawLine
    }
};