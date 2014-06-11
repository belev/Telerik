function drawer(containerID) {
    var STROKE_COLOR = '#77B300',
        TEXT_COLOR = 'black',
        RECT_HEIGHT = 50,
        RECT_WIDTH = 145,
        FONT_SIZE = 18,
        ARROW_SIZE = 5,
        BEIZER_STROKE_WIDTH = 2;

    var layer = new Kinetic.Layer();

    function getRectWithText(x, y, cornerRadius, text) {
        var currRect = new Kinetic.Rect({
            x: x,
            y: y,
            width: RECT_WIDTH,
            height: RECT_HEIGHT,
            strokeWidth: 3,
            stroke: STROKE_COLOR,
            cornerRadius: cornerRadius
        });

        var currText = new Kinetic.Text({
            x: x,
            y: y + (RECT_HEIGHT / 3),
            text: text,
            fontSize: FONT_SIZE,
            fontFamily: 'Calibri',
            width: RECT_WIDTH,
            align: 'center',
            fill: TEXT_COLOR
        });

        layer.add(currRect);
        layer.add(currText);
    }

    function makeFemaleRect(x, y, name) {
        getRectWithText(x, y, 25, name);
    }

    function makeMaleRect(x, y, name) {
        getRectWithText(x, y, 10, name);
    }

    function makeLinkBetweenMaleFemale(leftX, leftY) {
        var currLine = new Kinetic.Shape({
            drawFunc: function (context) {
                context.beginPath();
                context.moveTo(leftX + RECT_WIDTH, leftY + RECT_HEIGHT / 2);
                context.lineTo(leftX + RECT_WIDTH * 1.5, leftY + RECT_HEIGHT / 2);
                context.stroke(this);
            },
            strokeWidth: BEIZER_STROKE_WIDTH,
            stroke: STROKE_COLOR
        });
        layer.add(currLine);
    }

    function makeConnection(leftParentX, leftParentY, childX, childY) {
        var startX = leftParentX + RECT_WIDTH * 1.25;
        var startY = leftParentY + RECT_HEIGHT / 2;
        var endX = childX + RECT_WIDTH / 2;
        var endY = childY;
        innerGetBezierLine(startX, startY, endX, endY, layer);

        function innerGetBezierLine(stX, stY, eX, eY) {
            var beizerCPdx = Math.abs(eX - stX) / 10;
            var beizerCPdY = Math.abs(eY - stY) * 0.95;
            var currLine = new Kinetic.Shape({
                drawFunc: function (context) {
                    context.beginPath();
                    context.moveTo(stX, stY);
                    context.bezierCurveTo(stX + beizerCPdx, stY + beizerCPdY, eX - beizerCPdx, eY - beizerCPdY, eX, eY);
                    context.stroke(this);
                    context.beginPath();
                    context.lineTo(eX + ARROW_SIZE, eY - ARROW_SIZE);
                    context.lineTo(eX - ARROW_SIZE, eY - ARROW_SIZE);
                    context.lineTo(eX, eY);
                    context.fill(this);
                },
                strokeWidth: BEIZER_STROKE_WIDTH,
                fill: STROKE_COLOR,
                stroke: STROKE_COLOR
            });

            layer.add(currLine);
        }
    }

    function renderTree(members) {
        var stageSize = (function () {
            var maxWidth = 0;
            var maxDepth = 0;
            for (var i = 0; i < members.length; i++) {
                if (maxWidth < members[i].depthX) {
                    maxWidth = members[i].depthX;
                }
                if (maxDepth < members[i].depthY) {
                    maxDepth = members[i].depthY;
                }
            }
            return {
                maxXIndexes: maxWidth + 1,
                maxDepth: maxDepth + 1
            };
        }());

        var stage = new Kinetic.Stage({
            container: containerID,
            width: stageSize.maxXIndexes * RECT_WIDTH * 1.5,
            height: stageSize.maxDepth * RECT_HEIGHT * 2
        });

        var shownMembers = [];

        for (var i = 0; i < members.length; i++) {
            if (shownMembers.indexOf(members[i].name) < 0) {
                var coords = getCoords(members[i]);

                if (members[i].female) {
                    makeFemaleRect(coords.X, coords.Y, members[i].name);

                    if (members[i].partner) {
                        var pCoords = getCoords(members[i].partner);

                        var connectionX = Math.min(coords.X, pCoords.X);
                        var connectionY = Math.min(coords.Y, pCoords.Y);

                        makeLinkBetweenMaleFemale(connectionX, connectionY);
                    }
                }
                else {
                    makeMaleRect(coords.X, coords.Y, members[i].name);
                }

                // if there is a parent - show the link
                if (members[i].parent) {
                    var coords1 = getCoords(members[i].parent);
                    var coords2 = getCoords(members[i].parent.partner);

                    var minX = Math.min(coords1.X, coords2.X);
                    var minY = Math.min(coords1.Y, coords2.Y);

                    makeConnection(minX, minY, coords.X, coords.Y);
                }

                shownMembers.push(members[i].name);
            }
        }

        function getCoords(member) {
            return {
                X: member.depthX * RECT_WIDTH * 1.5,
                Y: member.depthY * RECT_HEIGHT * 2
            };
        }

        stage.add(layer);
    }

    return {
        renderTree: renderTree
    };
}