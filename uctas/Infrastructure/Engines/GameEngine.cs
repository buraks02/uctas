using System;
using uctas.Models;

namespace uctas.Infrastructure.Engines
{
    public class GameEngine
    {
        public static GameActionResult CheckGameAction(Game existingGame, Game newGame)
        {
            GameActionResult gameActionResult = new GameActionResult() { ActionResultCode = ActionResultCode.OK };

            //TODO: Hold movable nodes so can decide whether the action is valid.
            string message = string.Empty;
            if (CheckTrio(newGame, out message))
            {
                gameActionResult.ActionResultCode = ActionResultCode.FINISHED;
                gameActionResult.ActionMessage = message;
            }

            return gameActionResult;

        }

        private static bool CheckTrio(Game existingGame, out string message)
        {
            bool trioExists = false;
            //Find a better decision tree
            if (((existingGame.Board.Nodes[0].Player != null) &&
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[1].Player) && 
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[2].Player)) ||
                ((existingGame.Board.Nodes[3].Player != null) && 
                (existingGame.Board.Nodes[3].Player == existingGame.Board.Nodes[4].Player) && 
                (existingGame.Board.Nodes[3].Player == existingGame.Board.Nodes[5].Player)) ||
                ((existingGame.Board.Nodes[6].Player != null) && 
                (existingGame.Board.Nodes[6].Player == existingGame.Board.Nodes[7].Player) && 
                (existingGame.Board.Nodes[6].Player == existingGame.Board.Nodes[8].Player)) ||
                ((existingGame.Board.Nodes[0].Player != null) && 
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[3].Player) && 
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[6].Player)) ||
                ((existingGame.Board.Nodes[1].Player != null) && 
                (existingGame.Board.Nodes[1].Player == existingGame.Board.Nodes[4].Player) && 
                (existingGame.Board.Nodes[1].Player == existingGame.Board.Nodes[7].Player)) ||
                ((existingGame.Board.Nodes[2].Player != null) && 
                (existingGame.Board.Nodes[2].Player == existingGame.Board.Nodes[5].Player) && 
                (existingGame.Board.Nodes[2].Player == existingGame.Board.Nodes[8].Player)) ||
                ((existingGame.Board.Nodes[0].Player != null) && 
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[5].Player) && 
                (existingGame.Board.Nodes[0].Player == existingGame.Board.Nodes[8].Player)) ||
                ((existingGame.Board.Nodes[2].Player != null) && 
                (existingGame.Board.Nodes[2].Player == existingGame.Board.Nodes[4].Player) && 
                (existingGame.Board.Nodes[2].Player == existingGame.Board.Nodes[6].Player)))
            {
                trioExists = true;
                message = "Game finished";
            }
            else
            {
                message = "Return";
            }

            return trioExists;

        }
    }
}
