function snake() {
    var canvas = document.getElementById('canvas-field');
    ctx = canvas.getContext('2d');

    var gameEngine = new GameEngine();
    gameEngine.initializeGameSettings();

    var loop;
    if (typeof loop !== "undefined") {
        clearInterval(loop);
    }
    else {
        loop = setInterval(gameEngine.startGame, 75);
    }
}