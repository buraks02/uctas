using System;
using uctas.Models;
using uctas.Models.ViewModels;

namespace uctas.Infrastructure.Extensions
{
    public static class GameViewExtensions
    {
        public static GameViewModel ToGameViewModel(this Game game)
        {
            GameViewModel gameViewModel = new GameViewModel();
            gameViewModel.GameId = game.ID;
            gameViewModel.Board = game.Board.ToBoardViewModel();
            gameViewModel.Player1 = game.Player1.ToPlayerViewModel();
            gameViewModel.Player2 = game.Player2.ToPlayerViewModel();

            return gameViewModel;
        }

        public static PlayerViewModel ToPlayerViewModel(this Player player)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel();

            playerViewModel.Color = player.Color;
            playerViewModel.PlayerName = player.Name;
            playerViewModel.Stones[0] = player.Stones[0].ToStoneViewModel();
            playerViewModel.Stones[1] = player.Stones[1].ToStoneViewModel();
            playerViewModel.Stones[2] = player.Stones[2].ToStoneViewModel();

            return playerViewModel;
        }

        public static StoneViewModel ToStoneViewModel(this Stone stone)
        {
            StoneViewModel stoneViewModel = new StoneViewModel();

            stoneViewModel.StoneId = stone.ID;
            stoneViewModel.NodeId = stone.NodeId;

            return stoneViewModel;
        }

        public static BoardViewModel ToBoardViewModel(this Board board)
        {
            BoardViewModel boardViewModel = new BoardViewModel();
            boardViewModel.Node1 = board.Nodes[0].ToNodeViewModel();
            boardViewModel.Node2 = board.Nodes[1].ToNodeViewModel();
            boardViewModel.Node3 = board.Nodes[2].ToNodeViewModel();
            boardViewModel.Node4 = board.Nodes[3].ToNodeViewModel();
            boardViewModel.Node5 = board.Nodes[4].ToNodeViewModel();
            boardViewModel.Node6 = board.Nodes[5].ToNodeViewModel();
            boardViewModel.Node7 = board.Nodes[6].ToNodeViewModel();
            boardViewModel.Node8 = board.Nodes[7].ToNodeViewModel();
            boardViewModel.Node9 = board.Nodes[8].ToNodeViewModel();

            return boardViewModel;
        }

        public static NodeViewModel ToNodeViewModel(this Node node)
        {
            NodeViewModel nodeViewModel = new NodeViewModel();

            nodeViewModel.Color = node.Player?.Color;
            nodeViewModel.NodeId = node.ID;
            nodeViewModel.PlayerName = node.Player?.Name;
            nodeViewModel.StoneId = node.Stone?.ID;

            return nodeViewModel;
        }
    }
}
