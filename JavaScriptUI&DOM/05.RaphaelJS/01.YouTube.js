window.onload = (function () {
    var paper = new Raphael(50, 50, 350, 260);

    var rect = paper.rect(50, 50, 290, 100);
    rect.attr({
        stroke: 'lightgray',
        'stroke-width': 3
    });

    var you = paper.text(115, 100, 'You');
    you.attr({
        fill: '#4B4B4B',
        stroke: '#4B4B4B',
        'stroke-width': 2,
        'font-size': 60
    });

    var redRect = paper.rect(175, 65, 150, 70, 15);
    redRect.attr({
        fill: 'red',
        stroke: 'red'
    });

    var tube = paper.text(250, 100, 'Tube');
    tube.attr({
        stroke: 'white',
        fill: 'white',
        'stroke-width': 2,
        'font-size': 60
    });

}());