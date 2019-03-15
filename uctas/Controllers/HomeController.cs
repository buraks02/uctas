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
            game = new Game();
            GameViewModel gameViewModel = game.ToGameViewModel();
            return View(gameViewModel);
        }

        [HttpPost]
        public ViewResult Index(GameViewModel gameViewModel)
        {
            game = gameViewModel.ToGameModel(game);
            game = AIEngine.Act(game);
            //TODO: Gameengine entegre edilecek.
            GameViewModel gameView = game.ToGameViewModel();
            return View(gameView);
        }
    }
}
