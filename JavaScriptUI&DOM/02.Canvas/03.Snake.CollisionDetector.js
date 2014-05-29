function CollisionDetector() {
    function hasBiteItself(snake) {
        var head = snake[0];
        for (var i = 1; i < snake.length; i++) {
            if (head.x == snake[i].x && head.y == snake[i].y) {
                return true;
            }

        }
        return false;
    }

    function hasHitWall(snake) {
        var head = snake[0];
        if (head.x < 0 || head.y < 0) {
            return true;
        }
        else if ((head.x >= Math.floor(FIELD_WIDTH / CELL_SIZE) || (head.y >= Math.floor(FIELD_HEIGHT / CELL_SIZE)))) {
            return true;
        }

        return false;
    }

    function hasEatenFood(food, snakePart) {
        if (snakePart.x == food.x && snakePart.y == food.y) {
            return true;
        }
        else {
            return false;
        }
    }

    return {
        checkIfBiteItself: hasBiteItself,
        checkIfHitWall: hasHitWall,
        checkIfEatFood: hasEatenFood
    };
}