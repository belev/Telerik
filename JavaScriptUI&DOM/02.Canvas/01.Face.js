function draw() {
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    ctx.lineWidth = 2.5;
    ctx.fillStyle = '#90CAD7';
    ctx.strokeStyle = '#22545F';

    // draw head
    ctx.beginPath();
    ctx.save();
    ctx.scale(1, 0.85);
    ctx.arc(100, 190, 72.5, 0, 2 * Math.PI, false);
    ctx.restore();
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    // draw eyes
    var leftEyeCenterX = 55,
        leftEyeCenterY = 200,
        rightEyeCenterX = 110,
        rightEyeCenterY = 200,
        eyeRadius = 13,
        eyeScaleX = 1,
        eyeScaleY = 0.7,
        EyeSelection = 'eye';

    drawEllipse(leftEyeCenterX, leftEyeCenterY, eyeRadius, 0, 2 * Math.PI, eyeScaleX, eyeScaleY, ctx, EyeSelection);
    drawEllipse(rightEyeCenterX, rightEyeCenterY, eyeRadius, 0, 2 * Math.PI, eyeScaleX, eyeScaleY, ctx, EyeSelection);

    var leftEyeballCenterX = 100,
        leftEyeballCenterY = 140,
        rightEyeballCenterX = 210,
        rightEyeballCenterY = 140,
        eyeballRadius = 7,
        eyeballScaleX = 0.5,
        eyeballScaleY = 1,
        EyeballSelection = 'eyeball';

    drawEllipse(leftEyeballCenterX, leftEyeballCenterY, eyeballRadius, 0, 2 * Math.PI, eyeballScaleX, eyeballScaleY, ctx, EyeballSelection);
    drawEllipse(rightEyeballCenterX, rightEyeballCenterY, eyeballRadius, 0, 2 * Math.PI, eyeballScaleX, eyeballScaleY, ctx, EyeballSelection);

    // draw mouth
    ctx.beginPath();
    ctx.save();
    ctx.setTransform(1, 0.15, 0, 0.35, 0, 0);
    ctx.arc(80, 520, 26.5, 0, 2 * Math.PI);
    ctx.restore();
    ctx.stroke();
    ctx.closePath();

    // draw nose
    ctx.beginPath();
    ctx.lineJoin = 'bevel';
    ctx.moveTo(85, 140);
    ctx.lineTo(70, 170);
    ctx.lineTo(85, 170);
    ctx.stroke();
    ctx.closePath();

    // draw the down part of the hat
    ctx.fillStyle = '#396693';
    ctx.strokeStyle = '#272727';
    ctx.beginPath();
    ctx.save();
    ctx.scale(1, 0.195);
    ctx.arc(95, 525, 80, 0, 2 * Math.PI, false);
    ctx.restore();
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    // draw the up part of the hat
    ctx.beginPath();
    ctx.fillRect(60, 20, 80, 75);
    ctx.moveTo(60, 21);
    ctx.lineTo(60, 92);
    ctx.moveTo(140, 23);
    ctx.lineTo(140, 93);
    ctx.save();
    ctx.scale(1, 0.4);
    ctx.arc(100, 50, 40, 0, 2 * Math.PI, false);

    ctx.arc(100, 225, 40, 0, Math.PI, false);
    ctx.restore();
    ctx.fill();
    ctx.stroke();
    ctx.closePath();
}

function drawEllipse(posX, posY, radius, startAngle, endAngle, scaleX, scaleY, ctx, drawSelection) {
    ctx.beginPath();
    ctx.save();
    ctx.scale(scaleX, scaleY);
    ctx.arc(posX, posY, radius, startAngle, endAngle);
    ctx.restore();
    if (drawSelection == 'eye') {
        ctx.stroke();
    }
    else if (drawSelection == 'eyeball') {
        var fillStyleColor = ctx.fillStyle;
        ctx.fillStyle = ctx.strokeStyle;
        ctx.fill();

        ctx.fillStyle = fillStyleColor;
    }
    ctx.closePath();
}
