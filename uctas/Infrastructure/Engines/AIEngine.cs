using System;
using System.Linq;
using uctas.Models;

namespace uctas.Infrastructure.Engines
{
    public class AIEngine
    {
        public static Player Player { get; set; }
        public AIEngine()
        {
        }

        public static Game Act(Game _game)
        {
            Game game = _game;
            if(Player.Stones.ToList().Any(s => s.NodeId == null))
            {
                Stone stone = Player.Stones.ToList().Where(s => s.NodeId == null).First();

                Node node = game.Board.Nodes.Where(n => n.Stone == null).First();

                node.Player = Player;
                node.Stone = stone;
                stone.NodeId = node.ID;
            }


            return game;
        }
    }
}
