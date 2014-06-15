function draw() {
    var firstCircleCenterPosX = 75,
        firstCircleCenterPosY = 155,
        secondCircleCenterPosX = 180,
        secondCircleCenterPosY = 155,
        thirdCircleCenterPosX = 305,
        thirdCircleCenterPosY = 155,
        bigCircleRadius = 65,
        smallCircleRadius = 15;

    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');

    ctx.lineWidth = 2.5;
    ctx.fillStyle = '#90CAD7';
    ctx.strokeStyle = '#2E7A8C';

    // draw wheels and pedal's circle
    drawCircle(firstCircleCenterPosX, firstCircleCenterPosY, bigCircleRadius, 0, 2 * Math.PI, false, ctx);
    drawCircle(secondCircleCenterPosX, secondCircleCenterPosY, smallCircleRadius, 0, 2 * Math.PI, false, ctx, 'white');
    drawCircle(thirdCircleCenterPosX, thirdCircleCenterPosY, bigCircleRadius, 0, 2 * Math.PI, false, ctx);

    // draw bike frame
    ctx.beginPath();
    ctx.moveTo(firstCircleCenterPosX, firstCircleCenterPosY);
    ctx.lineTo(150, 75);
    ctx.lineTo(290, 75);
    ctx.lineTo(secondCircleCenterPosX, secondCircleCenterPosY);
    ctx.lineTo(firstCircleCenterPosX, firstCircleCenterPosY);
    ctx.stroke();
    ctx.closePath();

    // draw bike pedals
    ctx.beginPath();
    ctx.moveTo(158, 130);
    ctx.lineTo(170, 145);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(190, 167);
    ctx.lineTo(201, 181);
    ctx.stroke();
    ctx.closePath();

    // draw bike seat
    ctx.beginPath();
    ctx.moveTo(secondCircleCenterPosX, secondCircleCenterPosY);
    ctx.lineTo(130, 40);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(105, 40);
    ctx.lineTo(155, 40);
    ctx.stroke();
    ctx.closePath();

    // draw bike wheel
    ctx.beginPath();
    ctx.moveTo(thirdCircleCenterPosX, thirdCircleCenterPosY);
    ctx.lineTo(285, 30);
    ctx.lineTo(237, 40);
    ctx.moveTo(285, 30);
    ctx.lineTo(315, 2);
    ctx.stroke();
    ctx.closePath();
}

function drawCircle(posX, posY, radius, startAngle, endAngle, antiClockwise, ctx, fillColor) {
    if(fillColor) {
        ctx.fillStyle = fillColor;
    }

    ctx.beginPath();
    ctx.arc(posX, posY, radius, startAngle, endAngle, antiClockwise);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.fillStyle = '#90CAD7';
}