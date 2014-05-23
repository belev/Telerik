function Solve(args) {
    var rowsAndCols = args[0].split(' ');

    var rowsCount = parseInt(rowsAndCols[0]);
    var colsCount = parseInt(rowsAndCols[1]);

    var matrix = [];
    var visited = [];

    for (var i = 0; i < rowsCount; i++) {
        var line = args[i + 1].split(' ');

        matrix[i] = [];
        visited[i] = [];

        for (var j = 0; j < colsCount; j++) {
            matrix[i][j] = line[j].toLowerCase();
            visited[i][j] = false;
        }
    }

    // dr ur ul dl
    var dx = [1, -1, -1, 1];
    var dy = [1, 1, -1, -1];
    var sum = 0;

    var pos = new Position(0, 0);

    while (true) {
        if (!isValidCell(rowsCount, colsCount, pos.x, pos.y)) {
            return 'successed with ' + sum;
        }

        if (visited[pos.x][pos.y] === true) {
            return 'failed at (' + pos.x + ', ' + pos.y + ')';
        }

        sum += Math.pow(2, pos.x) + pos.y;
        visited[pos.x][pos.y] = true;

        var dir = matrix[pos.x][pos.y].toLowerCase();

        if (dir === 'dr') {
            pos.x += dx[0];
            pos.y += dy[0];
        }
        else if (dir === 'ur') {
            pos.x += dx[1];
            pos.y += dy[1];
        }
        else if (dir === 'ul') {
            pos.x += dx[2];
            pos.y += dy[2];
        }
        else if (dir === 'dl') {
            pos.x += dx[3];
            pos.y += dy[3];
        }
    }

    function Position(row, col) {
        return {
            x: row,
            y: col
        };
    }

    function isValidCell(rowsNumber, colsNumber, row, curCcolol) {
        return (curCcolol >= 0 && row >= 0 && curCcolol < colsNumber && row < rowsNumber);
    }
}
(function () {
    var tests =
        [
            [
                '3 5',
                'dr dl dr ur ul',
                'dr dr ul ur ur',
                'dl dr ur dl ur'
            ],
            ['3 5',
             'dr dl dl ur ul',
             'dr dr ul ul ur',
             'dl dr ur dl ur'
            ],
            ['2 2',
                'dr dr',
                'ul ul'
            ]
        ];

    console.log(Solve(tests[0]));
    console.log(Solve(tests[2]));
}());