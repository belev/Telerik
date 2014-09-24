namespace Exam.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Exam.GameLogic;
    using Exam.Data;
    using Exam.Models;
    using Exam.WebApi.Infrastructure;
    using Exam.WebApi.Models;

    public class GamesController : BaseApiController
    {
        private const int GAMES_ON_PAGE_COUNT = 10;
        private const string NO_BLUE_PLAYER_YET = "No blue player yet";
        private const string NUMBER_ERROR_MESSAGE = "Your number must be exactly 4 digits long and must contain different digits from 0 - 9 inclusive.";

        private const int WINS_COUNT_MULTIPLIER = 100;
        private const int LOOSES_COUNT_MULTIPLIER = 15;

        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;
        private Random randomGenerator;

        public GamesController(IBullsAndCowsData data, IGameResultValidator resultValidator, IUserIdProvider userIdProvider, Random randomGenerator) : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
            this.randomGenerator = randomGenerator;
        }

        [HttpGet]
        [Route("scores")]
        public IHttpActionResult GetTopScores()
        {
            var topUsers = this.Data.Users
                               .All()
                               .OrderByDescending(u => (u.WinsCount * WINS_COUNT_MULTIPLIER + u.LoosesCount * LOOSES_COUNT_MULTIPLIER))
                               .Select(u => new { Username = u.UserName, Rank = (u.WinsCount * WINS_COUNT_MULTIPLIER + u.LoosesCount * LOOSES_COUNT_MULTIPLIER) })
                               .Take(10);

            return Ok(topUsers);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var games = this.Data.Games
                            .All()
                            .OrderBy(g => g.State)
                            .ThenBy(g => g.Name)
                            .ThenBy(g => g.CreatedOn)
                            .ThenBy(g => g.RedPlayer.UserName)
                            .AsQueryable();

            if (!this.User.Identity.IsAuthenticated)
            {
                games = games.Where(g => g.State == GameState.WaitingForOpponent);
            }
            else
            {
                var userId = this.userIdProvider.GetUserId();

                games = games.Where(g => (g.State == GameState.WaitingForOpponent) || g.RedPlayerId == userId || g.BluePlayerId == userId);
            }

            games = games.Take(GAMES_ON_PAGE_COUNT);

            return Ok(games.Select(GameModelShortInfo.FromGame));
        }

        [HttpGet]
        public IHttpActionResult Get(string page)
        {
            var pageNumber = int.Parse(page);
            var games = this.Data.Games
                            .All()
                            .OrderBy(g => g.State)
                            .ThenBy(g => g.Name)
                            .ThenBy(g => g.CreatedOn)
                            .ThenBy(g => g.RedPlayer.UserName)
                            .AsQueryable();

            if (!this.User.Identity.IsAuthenticated)
            {
                games = games.Where(g => g.State == GameState.WaitingForOpponent);
            }
            else
            {
                var userId = this.userIdProvider.GetUserId();

                games = games.Where(g => (g.State == GameState.WaitingForOpponent) || g.RedPlayerId == userId || g.BluePlayerId == userId);
            }

            games = games.Skip((pageNumber - 1) * GAMES_ON_PAGE_COUNT)
                         .Take(GAMES_ON_PAGE_COUNT);

            return Ok(games.Select(GameModelShortInfo.FromGame));
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Put(int id, UserNumberToGuessModel numberGuessModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (!this.resultValidator.IsPlayerGuessNumberInputValid(numberGuessModel.Number))
            {
                return BadRequest("Your number must be exactly 4 digits long and must contain different digits from 0 - 9 inclusive.");
            }

            var game = this.Data.Games.All()
                           .FirstOrDefault(g => g.GameId == id);

            if (game == null)
            {
                return BadRequest("Game with this id does not exists.");
            }
            var userId = this.userIdProvider.GetUserId();

            if (game.RedPlayerId == userId)
            {
                return BadRequest("You have created the game. You can not join the game as second player.");
            }

            game.BluePlayerId = userId;
            game.BluePlayer = this.Data.Users.All().Where(u => u.Id == game.BluePlayerId).FirstOrDefault();
            game.BluePlayer.NumberToGuess = numberGuessModel.Number;

            var stateForStarting = this.ChooseWhichPlayerWillStartTheGame(this.GetRandomNumberFrom1To10000());
            game.State = stateForStarting;

            this.Data.SaveChanges();

            return Ok(new { result = "You joined game \\" + game.Name + "!\\" });
        }

        /// <summary>
        /// Service for game details
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns>Returns detailed informationa about a game</returns>
        [Authorize]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var userId = this.userIdProvider.GetUserId();

            var game = this.Data.Games.All()
                           .FirstOrDefault(g => g.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            if (game.RedPlayerId != userId && game.BluePlayerId != userId)
            {
                return BadRequest("You must be part of the game to see the game details.");
            }

            if (game.State == GameState.WaitingForOpponent)
            {
                return BadRequest("The game has not started yet. Please wait for second player.");
            }

            var gameDetails = this.GetGameModelDetailedInfo(game, userId);
            return Ok(gameDetails);
        }

        /// <summary>
        /// Service for game creation
        /// </summary>
        /// <param name="game">In the post request should be given "name" and "number" for the game</param>
        /// <returns>The result of the game creation</returns>
        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(GameDataModel game)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            //if (this.Data.Games.All().FirstOrDefault(g => g.Number == game.Number) != null)
            //{
            //    return BadRequest("There is already a game with that number. You can not create games with equal game numbers.");
            //}

            if (!this.resultValidator.IsPlayerGuessNumberInputValid(game.Number))
            {
                return BadRequest(NUMBER_ERROR_MESSAGE);
            }

            var newGame = new Game()
            {
                State = GameState.WaitingForOpponent,
                Name = game.Name,
                Number = game.Number,
                CreatedOn = DateTime.Now
            };

            newGame.RedPlayerId = this.userIdProvider.GetUserId();
            newGame.RedPlayer = this.Data.Users.All().Where(u => u.Id == newGame.RedPlayerId).FirstOrDefault();

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            var gameInfoToReturn = GameModelShortInfo.CreateGameModelShortInfo(newGame);

            return Created(this.Url.ToString(), gameInfoToReturn);
        }

        /// <summary>
        /// Service for making a guess
        /// </summary>
        /// <param name="id">Shows in which game you want to make a guess</param>
        /// <param name="guess">Your guess</param>
        /// <returns>The result of the guess</returns>
        [Authorize]
        [HttpPost]
        [Route("api/games/{id}/{guess}")]
        public IHttpActionResult Post(int id, string guess)
        {
            var game = this.Data.Games.All().FirstOrDefault(g => g.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            if (!this.resultValidator.IsPlayerGuessNumberInputValid(guess))
            {
                return BadRequest(NUMBER_ERROR_MESSAGE);
            }

            var userId = this.userIdProvider.GetUserId();

            if (game.BluePlayerId != userId && game.RedPlayerId != userId)
            {
                return BadRequest("It is not your game to make moves. Please first join a game and then play.");
            }

            var onTurn = game.State;
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);

            if (onTurn == GameState.RedInTurn)
            {
                if (game.BluePlayerId == userId)
                {
                    return BadRequest("It is not your turn.");
                }

                var guessModel = this.GetNewGuessModel(game, guess, userId, PlayerOnTurn.Red);

                if (this.IsGameEnded(guessModel))
                {
                    return this.ProcessGameEnd(game, guessModel);
                }

                return Ok(guessModel);
            }
            else if (onTurn == GameState.BlueInTurn)
            {
                if (game.RedPlayerId == userId)
                {
                    return BadRequest("It is not your turn.");
                }

                var guessModel = this.GetNewGuessModel(game, guess, userId, PlayerOnTurn.Blue);

                if (this.IsGameEnded(guessModel))
                {
                    return this.ProcessGameEnd(game, guessModel);
                }

                return Ok(guessModel);
            }
            else
            {
                return BadRequest("The game is not on playable state.");
            }
        }

        /// <summary>
        /// Method for getting the detailed information about a game
        /// </summary>
        /// <param name="game">Current game which is played</param>
        /// <param name="userId">The current user id</param>
        /// <returns>Returns detailed information about a game</returns>
        private GameModelDetailedInfo GetGameModelDetailedInfo(Game game, string userId)
        {
            var yourNumber = game.Number;
            var yourColor = "red";
            var yourGuesses = game.RedPlayer.Guesses.Select(GuessModel.FromGuess);
            var opponentGuesses = game.BluePlayer.Guesses.Select(GuessModel.FromGuess);

            if (game.BluePlayerId == userId)
            {
                yourGuesses = game.BluePlayer.Guesses.Select(GuessModel.FromGuess);
                opponentGuesses = game.RedPlayer.Guesses.Select(GuessModel.FromGuess);
                yourNumber = game.BluePlayer.NumberToGuess;
                yourColor = "blue";
            }

            var gameDetails = new GameModelDetailedInfo
            {
                Id = game.GameId,
                Name = game.Name,
                DateCreated = game.CreatedOn,
                Red = game.RedPlayer.UserName,
                Blue = game.BluePlayer.UserName,
                YourNumber = yourNumber,
                YourGuesses = yourGuesses,
                OpponentGuesses = opponentGuesses,
                YourColor = yourColor,
                GameState = game.State.ToString()
            };

            return gameDetails;
        }

        private int GetRandomNumberFrom1To10000()
        {
            return this.randomGenerator.Next(1, 10001);
        }

        private GameState ChooseWhichPlayerWillStartTheGame(int number)
        {
            if (number > 5000)
            {
                return GameState.BlueInTurn;
            }
            else
            {
                return GameState.RedInTurn;
            }
        }

        /// <summary>
        /// Help method after guess is made
        /// </summary>
        /// <param name="game">The current game</param>
        /// <param name="guess">User guess</param>
        /// <param name="userId">The current user id</param>
        /// <param name="onTurn">Which is on turn(red or blue player)</param>
        /// <returns></returns>
        private GuessModel GetNewGuessModel(Game game, string guess, string userId, PlayerOnTurn onTurn)
        {
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);

            var numberToGuess = string.Empty;
            if (onTurn == PlayerOnTurn.Red)
            {
                numberToGuess = game.BluePlayer.NumberToGuess;
            }
            else
            {
                numberToGuess = game.Number;
            }

            var guessResult = this.resultValidator.GetResult(numberToGuess, guess, onTurn);
            var newGuess = new Guess
            {
                BullsCount = guessResult.BullsCount,
                CowsCount = guessResult.CowsCount,
                DateMade = DateTime.Now,
                UserId = userId,
                User = user,
                Game = game,
                GameId = game.GameId,
                Number = guess
            };

            if (onTurn == PlayerOnTurn.Red)
            {
                game.State = GameState.BlueInTurn;
            }
            else if (onTurn == PlayerOnTurn.Blue)
            {
                game.State = GameState.RedInTurn;
            }

            this.Data.Guesses.Add(newGuess);
            this.Data.SaveChanges();

            return GuessModel.FromGuess(newGuess);
        }

        private bool IsGameEnded(GuessModel guess)
        {
            if (guess.BullsCount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private IHttpActionResult ProcessGameEnd(Game game, GuessModel guess)
        {
            var redPlayer = game.RedPlayer;
            var bluePlayer = game.BluePlayer;

            if (game.RedPlayerId == guess.UserId)
            {
                redPlayer.WinsCount++;
                bluePlayer.LoosesCount++;

                game.State = GameState.WonByRed;
            }
            else
            {
                redPlayer.LoosesCount++;
                bluePlayer.WinsCount++;

                game.State = GameState.WonByBlue;
            }

            this.Data.SaveChanges();

            return Ok("Congratulations " + guess.Username + " ! You won the game!");
        }
    }
}