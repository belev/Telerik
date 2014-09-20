namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Http;

    public class HelpController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GameHelp()
        {
            var help = new StringBuilder();
            help.AppendLine("Welcome to tic tac toe game.");
            help.AppendLine("If you don't know how to play the game, now you will understand.");
            
            help.AppendLine("First of all you should create your user, so that you can join some game and play with other people.");
            help.AppendLine("After you create your user, you will be given a session key with which you can create new game or join already created game.");
            help.AppendLine("If you create a game, you must wait for second player to play with.");
            help.AppendLine("If not you could join already created game and play with someone");
            help.AppendLine();
            help.AppendLine("After the game begins you will get turns. To mark a cell as yours, you should give the row and col of the cell.");
            
            help.AppendLine("If there is something you don't understand, you will learn in the gameplay.");
            help.AppendLine("Happy playing and thanks for using our game! : )");

            return Ok(help.ToString());
        }
    }
}