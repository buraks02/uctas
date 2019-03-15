using System;
using System.Xml.Linq;
using uctas.Models;
using uctas.Models.ViewModels;

namespace uctas.Infrastructure.Extensions
{
    public static class GameExtensions
    {
        public static Game ToGameModel(this GameViewModel gameViewModel, Game activeGame)
        {
            Game game = new Game
            {
                ID = gameViewModel.GameId,
                Board = gameViewModel.Board.ToBoardModel(activeGame),
                Player1 = gameViewModel.Player1.ToPlayerModel(activeGame),
                Player2 = gameViewModel.Player2.ToPlayerModel(activeGame)
            };

            return game;
        }

        public static Player ToPlayerModel(this PlayerViewModel playerViewModel, Game activeGame)
        {
            Player player = playerViewModel.PlayerName == activeGame.Player1.Name ? activeGame.Player1 : activeGame.Player2;
            //player.Stones[0].NodeId = playerViewModel.Stones[0].NodeId;
            //player.Stones[1].NodeId = playerViewModel.Stones[1].NodeId;
            //player.Stones[2].NodeId = playerViewModel.Stones[2].NodeId;

            return player;
        }

        public static Board ToBoardModel(this BoardViewModel boardViewModel, Game activeGame)
        {
            Board board = new Board();
            board.Nodes[0] = boardViewModel.Node1.ToNodeModel(activeGame);
            board.Nodes[1] = boardViewModel.Node2.ToNodeModel(activeGame);
            board.Nodes[2] = boardViewModel.Node3.ToNodeModel(activeGame);
            board.Nodes[3] = boardViewModel.Node4.ToNodeModel(activeGame);
            board.Nodes[4] = boardViewModel.Node5.ToNodeModel(activeGame);
            board.Nodes[5] = boardViewModel.Node6.ToNodeModel(activeGame);
            board.Nodes[6] = boardViewModel.Node7.ToNodeModel(activeGame);
            board.Nodes[7] = boardViewModel.Node8.ToNodeModel(activeGame);
            board.Nodes[8] = boardViewModel.Node9.ToNodeModel(activeGame);

            return board;
        }

        public static Node ToNodeModel(this NodeViewModel nodeViewModel, Game activeGame)
        {
            //Node node = new Node();
            Node node = activeGame.Board.Nodes[nodeViewModel.NodeId];
            //node.ID = nodeViewModel.NodeId;
            if (!string.IsNullOrEmpty(nodeViewModel.PlayerName))
            {
                node.Player = activeGame.Player1.Name == nodeViewModel.PlayerName ? activeGame.Player1 : activeGame.Player2;
            }
            else
            {
                node.Player = null;
            }

            int stoneIndex = nodeViewModel.StoneId.HasValue ? (int)nodeViewModel.StoneId : -1;
            if (stoneIndex != -1)
            {
                node.Stone = node.Player.Stones[stoneIndex];
                node.Player.Stones[stoneIndex].NodeId = node.ID;
            }
            else
            {
                node.Stone = null;
            }

            return node;
        }
    }
}
