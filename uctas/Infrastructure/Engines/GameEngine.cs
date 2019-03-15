using System;
using uctas.Models;

namespace uctas.Infrastructure.Engines
{
    public class GameEngine
    {
        public static GameActionResult CheckGameAction(Game existingGame, Game newGame)
        {
            GameActionResult gameActionResult = new GameActionResult() { ActionResultCode = ActionResultCode.FAIL };

            return gameActionResult;

        }
    }
}
