function GameEngine() {
	CELL_SIZE = 10,
    FIELD_WIDTH = 600,
    FIELD_HEIGHT = 450;
	
    var SNAKE_INITIAL_LENGTH = 4,
    LEFT_ARROW_KEY_NUMBER = 37,
    UP_ARROW_KEY_NUMBER = 38,
    RIGHT_ARROW_KEY_NUMBER = 39,
    DOWN_ARROW_KEY_NUMBER = 40,
    UP_DIRECTION = 'up',
    DOWN_DIRECTION = 'down',
    LEFT_DIRECTION = 'left',
    RIGHT_DIRECTION = 'right';

    var collisionDetector,
        snake,
        food,
        score,
        gameEnded,
        direction;

    document.onkeydown = function (event) {
        var keyCode = event.keyCode;

        switch (keyCode) {
            // left
            case LEFT_ARROW_KEY_NUMBER:
                if (direction != RIGHT_DIRECTION) {
                    direction = LEFT_DIRECTION;
                }
                break;
            // up
            case UP_ARROW_KEY_NUMBER:
                if (direction != DOWN_DIRECTION) {
                    direction = UP_DIRECTION;
                }
                break;
            // right
            case RIGHT_ARROW_KEY_NUMBER:
                if (direction != LEFT_DIRECTION) {
                    direction = RIGHT_DIRECTION;
                }
                break;
            // down
            case DOWN_ARROW_KEY_NUMBER:
                if (direction != UP_DIRECTION) {
                    direction = DOWN_DIRECTION;
                }
                break;
            default:
                break;
        }
    };

    function initSnake() {
        var length = SNAKE_INITIAL_LENGTH;
        var initialSnake = [];
        for (var i = length - 1; i >= 0; i--) {
            initialSnake.push({x: i, y: 0});
        }

        return initialSnake;
    }

    function createFood() {
        var foodX = Math.floor(Math.random() * ((FIELD_WIDTH / CELL_SIZE) - 1));
        var foodY = Math.floor(Math.random() * ((FIELD_HEIGHT / CELL_SIZE) - 1));
        for (var k = 0; k < snake.length; k++) {
            if (collisionDetector.checkIfEatFood({x: foodX, y: foodY}, snake[k])) {
                createFood();
            }
        }

        return {
            x: foodX,
            y: foodY
        };
    }

    function drawSnake() {
        for (var i = 0; i < snake.length; i++) {
            var s = snake[i];

            if (i == 0) {
                drawCell(s.x, s.y, 'red', '#333');
            }
            else {
                drawCell(s.x, s.y, '#999', '#333');
            }
        }
    }

    function drawCell(x, y, fillColor, stroke) {
        ctx.fillStyle = fillColor;
        ctx.fillRect(x * CELL_SIZE, y * CELL_SIZE, CELL_SIZE, CELL_SIZE);

        //add the stroke if it is defined
        if (typeof stroke !== "undefined") {
            ctx.strokeStyle = stroke;
            ctx.strokeRect(x * CELL_SIZE, y * CELL_SIZE, CELL_SIZE, CELL_SIZE);
        }
    }

    function drawFood() {
        drawCell(food.x, food.y, 'green', '#333');
    }

    function initializeGameSettings() {
        snake = initSnake();
        collisionDetector = new CollisionDetector();
        food = createFood();
        score = 0;
        gameEnded = false;
        direction = 'right';
    }

    function moveSnake() {
        if (!gameEnded) {
            var headX = snake[0].x;
            var headY = snake[0].y;

            // change head position
            if (direction == RIGHT_DIRECTION) {
                headX++;
            }
            else if (direction == LEFT_DIRECTION) {
                headX--;
            }
            else if (direction == UP_DIRECTION) {
                headY--;
            }
            else if (direction == DOWN_DIRECTION) {
                headY++;
            }

            // tail of the snake goes as head of the snake
            var tail = snake.pop();
            tail.x = headX;
            tail.y = headY;
            snake.unshift(tail);
        }
    }

    function startGame() {
        moveSnake();

        var head = snake[0];

        if (collisionDetector.checkIfBiteItself(snake) || collisionDetector.checkIfHitWall(snake)) {
            ctx.clearRect(0, 0, FIELD_WIDTH, FIELD_HEIGHT);
            ctx.fillText("GAME OVER", 100, 100);
            ctx.fillText("SCORE: " + score, 100, 120);

            gameEnded = true;
            return;
        }
        else if (collisionDetector.checkIfEatFood(food, snake[0])) {
            ctx.clearRect(food.x, food.y, CELL_SIZE, CELL_SIZE);

            score += 10;

            var x = snake[snake.length - 1].x;
            var y = snake[snake.length - 1].y;

            snake.push({x: x, y: y});

            food = createFood();
        }
        else {
            ctx.clearRect(0, 0, FIELD_WIDTH, FIELD_HEIGHT);
            ctx.beginPath();

            drawSnake();
            drawFood();
        }
    }

    return {
        initializeGameSettings: initializeGameSettings,
        startGame: startGame
    };
}