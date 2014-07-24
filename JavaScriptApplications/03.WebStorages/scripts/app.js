(function () {
    require.config({
        paths: {
            'jquery': '../libs/jquery-1.11.1.min',
            'numberGenerator': './game/numberGenerator',
            'processUserInput': './game/processUserInput',
            'localStorageManager': './game/localStorageManager'
        }
    });

    require(['game/game'], function (Game) {
        Game.start();
    });
}());