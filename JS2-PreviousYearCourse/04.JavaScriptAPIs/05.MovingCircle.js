function drawMovingCircle() {
    var canvas = document.getElementById('canvas');
    canvas.style.border = "1px solid red";

    var circleCenterX = canvas.width / 2 - 50,
        circleCenterY = canvas.height / 2 + 30,
        circleRadius = 5,
        maxWidth = canvas.width,
        maxHeight = canvas.height;

    var ctx = canvas.getContext('2d');
    ctx.beginPath();
    ctx.arc(circleCenterX, circleCenterY, circleRadius, 0, 2 * Math.PI);
    ctx.stroke();
    ctx.closePath();

    var dirX = 4.5;
    var dirY = 5.5;

    requestAnimationFrame(function(){
        moveCircle(circleRadius, circleCenterX, circleCenterY, dirX, dirY, ctx, maxWidth, maxHeight);
    });
}

function moveCircle(radius, posX, posY, dirX, dirY, ctx, maxWidth, maxHeight) {

    ctx.clearRect(0,0,maxWidth,maxHeight);

    ctx.beginPath();
    ctx.arc(posX, posY, radius, 0, 2 * Math.PI);
    ctx.stroke();
    ctx.closePath();


    posX += dirX;
    posY += dirY;


    var hitUpOrDownWall = posY + radius >= maxHeight || posY - radius <= 0;
    var hitLeftOrRightWall = posX + radius >= maxWidth || posX - radius <= 0;

    if (hitUpOrDownWall) {
        dirY *= -1;
    }
    else if (hitLeftOrRightWall) {
        dirX *= -1;
    }

    requestAnimationFrame(function(){
        moveCircle(radius, posX, posY, dirX, dirY, ctx, maxWidth, maxHeight);
    });
}