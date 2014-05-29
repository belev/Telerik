function draw() {
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');

    var fillStyleColor = '#975B5B';

    ctx.fillStyle = fillStyleColor;
    ctx.lineWidth = 2.5;

    var startingTrianglePosX = 7,
        startingTrianglePosY = 170,
        windowWidth = 50,
        windowHeight = 33,
        leftWindowPosX = 20,
        leftWindowPosY = 190,
        upRightWindowPosX = 170,
        upRightWindowPosY = 190,
        downRightWindowPosX = 170,
        downRightWindowPosY = 280,
        windowsDistance = 3,
        houseWidth = 300;

    // draw roof
    ctx.beginPath();
    ctx.moveTo(startingTrianglePosX, startingTrianglePosY);
    ctx.lineTo(startingTrianglePosX + houseWidth, startingTrianglePosY);
    ctx.lineTo(158, 10);
    ctx.lineTo(startingTrianglePosX, startingTrianglePosY);
    ctx.fill();
    ctx.stroke();

    // draw walls
    ctx.fillRect(startingTrianglePosX, startingTrianglePosY, 300, 250);
    ctx.strokeRect(startingTrianglePosX, startingTrianglePosY, 300, 250);

    drawWindows(leftWindowPosX, leftWindowPosY, windowsDistance, windowWidth, windowHeight, ctx, fillStyleColor);
    drawWindows(upRightWindowPosX, upRightWindowPosY, windowsDistance, windowWidth, windowHeight, ctx, fillStyleColor);
    drawWindows(downRightWindowPosX, downRightWindowPosY, windowsDistance, windowWidth, windowHeight, ctx, fillStyleColor);

    // draw chimney
    var chimneyWidth = 30,
        chimneyHeight = 85,
        chimneyPosX = 210,
        chimneyPoxY = 35;

    ctx.closePath();
    ctx.beginPath();

    ctx.fillRect(chimneyPosX, chimneyPoxY, chimneyWidth, chimneyHeight);
    ctx.moveTo(chimneyPosX - 1, chimneyPoxY);
    ctx.lineTo(chimneyPosX - 1, chimneyPoxY + chimneyHeight);
    ctx.moveTo(chimneyPosX + chimneyWidth + 1, chimneyPoxY);
    ctx.lineTo(chimneyPosX + chimneyWidth + 1, chimneyPoxY + chimneyHeight);
    ctx.save();
    ctx.scale(1, 0.3);
    ctx.moveTo(240, 120);
    ctx.arc(225, 120, 15, 0, 2 * Math.PI);
    ctx.restore();
    ctx.fill();
    ctx.stroke();

    // draw door
    ctx.closePath();
    ctx.beginPath();

    var arcPosX = 80,
        arcPosY = 550,
        arcRadius = 45;

    ctx.save();
    ctx.scale(1, 0.6);
    ctx.arc(arcPosX, arcPosY, arcRadius, Math.PI + 0.1, Math.PI * 2 - 0.1);
    ctx.restore();
    ctx.moveTo(arcPosX - arcRadius, 326);
    ctx.lineTo(arcPosX - arcRadius, 420);
    ctx.moveTo(arcPosX + arcRadius, 326);
    ctx.lineTo(arcPosX + arcRadius, 420);
    ctx.moveTo(arcPosX, 304);
    ctx.lineTo(arcPosX, 420);
    ctx.stroke();
    ctx.closePath();

    // draw doorknobs
    var leftKnobPosX = 65,
        leftKnobPosY = 385,
        rightKnobPosX = 95,
        rightKnobPosY = 385,
        knobRadius = 4;

    drawDoorknob(leftKnobPosX, leftKnobPosY, knobRadius, 0, 2 * Math.PI, ctx);
    drawDoorknob(rightKnobPosX, rightKnobPosY, knobRadius, 0, 2 * Math.PI, ctx);
}

function drawWindows(posX, posY, windowDistance, windowWidth, windowHeight, ctx, fillStyleColor) {
    for (var i = 1; i < 3; i++) {
        for (var j = 1; j < 3; j++) {
            ctx.fillStyle = 'black';
            ctx.fillRect(posX + 10, posY + 10, windowWidth, windowHeight);

            posX += windowWidth + windowDistance;

        }
        posY += windowHeight + windowDistance;

        posX -= 2 * (windowWidth + windowDistance);
    }

    ctx.fillStyle = fillStyleColor;
}

function drawDoorknob(posX, posY, radius, startAngle, endAngle, ctx) {
    ctx.beginPath();
    ctx.arc(posX, posY, radius, startAngle, endAngle);
    ctx.stroke();
    ctx.closePath();
}