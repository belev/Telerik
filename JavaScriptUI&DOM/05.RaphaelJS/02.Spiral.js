window.onload = (function () {
    var paper = new Raphael(250, 250, 250, 250);

    var centerX = 150;
    var centerY = 150;

    var spiralTurning = 3;
    var successiveTurnsDistance = 4;

    var angle = 0;

    var x = centerX,
        y = centerY,
        radius = 1;

    function moveCircleAround() {
        paper.circle(x, y, radius).attr({fill: 'black'});

        angle += 0.015;
        x = centerX + (spiralTurning + successiveTurnsDistance * angle) * Math.sin(angle);
        y = centerY + (spiralTurning + successiveTurnsDistance * angle) * Math.cos(angle);

        if (x > paper.width || y > paper.height) {
            clearInterval(moveCircleAround);
        }
        else {
            setTimeout(moveCircleAround, 0.3);
        }
    }

    setTimeout(moveCircleAround, 0.3);
}());