/// <reference path="_references.js" />

window.onload = function () {
    "use strict";


    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1440,
        height: 960
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();

    imageObj.onload = function () {
        var superMario = new Kinetic.Sprite({
            x: 450,
            y: 600,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                  // x, y, width, height (4 frames)
                  340, 980, 170, 250,
                  1130, 1040, 180, 200
                ],
                move: [
                  // x, y, width, height (3 frames)
                  560, 985, 240, 260,
                  25, 970, 235, 265,
                  860, 660, 200, 220
                ]
            },
            frameRate: 2,
            frameIndex: 0
        });

        // add the shape to the layer
        layer.add(superMario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        superMario.start();

        var frameCount = 0;

        superMario.on('frameIndexChange', function (evt) {
            if (superMario.animation() === 'move' && ++frameCount > 3) {
                superMario.animation('idle'); // restore original animation
                superMario.scaleX(1); // restore original animation
                frameCount = 0;
            }
        });

        function onKeyDown(evt) {
            switch (evt.keyCode) {
                case 37:  // left arrow
                    superMario.setX(superMario.attrs.x -= 50);
                    superMario.attrs.animation = "move";
                    break;
                case 39:  // right arrow
                    superMario.setX(superMario.attrs.x += 50);
                    superMario.scaleX(-1); // this scale reverses the mario
                    superMario.attrs.animation = "move";
                    break;
            }
        }

        window.addEventListener('keydown', onKeyDown);
    };

    imageObj.src = "images/super-mario-sprite.png";

    var paper = new Raphael(0, 0, 1440, 960);

    paper.image("images/super-mario-background.png", 0, 0, 1440, 960);
}