function Solve(args) {
    var number = parseInt(args[0]);


    var count = 0;

    for (var i = 0; i <= Math.floor(number / 3); i++) {
        for (var j = 0; j <= Math.floor(number / 4) ; j++) {
            for (var k = 0; k <= Math.floor(number / 10) ; k++) {
                if (i * 3 + j * 4 + k * 10 === number) {
                    count++;
                }
            }
        }
    }

    return count;
}

(function () {
    var tests =
        [
            ['7'],
            ['10'],
            ['40']
        ];

    for (var i = 0; i < tests.length; i++) {
        console.log(Solve(tests[i]));
    }
}());