using System;
using Microsoft.AspNetCore.Mvc;
using uctas.Infrastructure;
using uctas.Infrastructure.Engines;
using uctas.Infrastructure.Extensions;
using uctas.Models;
using uctas.Models.ViewModels;

namespace uctas.Controllers
{
    public class HomeController : Controller
    {
        private static Game game;
        public HomeController()
        {
            game = new Game();
            AIEngine.Player = game.Player2;
        }

        [HttpGet]
        public ViewResult Index()
        {
            //game = new Game();
            GameViewModel gameViewModel = game.ToGameViewModel();
            return View(gameViewModel);
        }

        [HttpPost]
        public ViewResult Index(GameViewModel gameViewModel)
        {
            Game newGame = gameViewModel.ToGameModel(game);
            GameActionResult gameActionResultForPlayer = GameEngine.CheckGameAction(game, newGame);
            if(gameActionResultForPlayer.ActionResultCode == ActionResultCode.FINISHED)
            {
                game.Message = "Player1 won!!";
                return Index();
            } 
            //TODO: Add ActionResultCode.FAIL flow

            //game = gameViewModel.ToGameModel(game);
            newGame = AIEngine.Act(newGame);

            GameActionResult gameActionResultForAI = GameEngine.CheckGameAction(game, newGame);
            if (gameActionResultForAI.ActionResultCode == ActionResultCode.FINISHED)
            {
                game.Message = "AI won!!";
                game = newGame;
                return Index();
            }

            return Index();
        }
    }
}
