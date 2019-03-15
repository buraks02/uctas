using System;
namespace uctas.Models.ViewModels
{
    public class GameViewModel
    {
        public string GameId { get; set; }
        public BoardViewModel Board { get; set; } 
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
    }
}
