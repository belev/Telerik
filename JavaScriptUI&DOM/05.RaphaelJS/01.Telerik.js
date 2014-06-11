window.onload = (function () {
    var paper = Raphael(50, 50, 500, 500);

    var containerRect = paper.rect(10, 5, 400, 150);
    containerRect.attr({
        stroke: '#E0FFA3',
        'stroke-width': 3
    });

    var telerikLogo = paper.path('M25 40 40 25 80 66 55 90 35 65 75 25 90 40');
    telerikLogo.attr({
        'stroke-width': 7,
        stroke: '#5CE600'
    });

    var telerikText = paper.text(230, 62, 'Telerik');
    telerikText.attr({
        'font-size': 80,
        fill: '#282828',
        'font-weight': 'bold',
        'font-family': 'Arial'
    });

    var circle = paper.circle(370, 58, 8);
    circle.attr({
        'stroke-width': 2
    });

    var trademarkR = paper.text(370, 58, 'R');
    trademarkR.attr({
        fill: '#282828',
        stroke: '#282828',
        'font-size': 12,
        'font-weight': 'bold'
    });

    var developExperiences = paper.text(255, 112, 'Develop experiences');
    developExperiences.attr({
        fill: '#282828',
        'font-size': 30,
        'font-family': 'Arial'
    });
}());