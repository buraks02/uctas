using System;
namespace uctas.Models
{
    public class Game 
    {
        public string ID { get; set; }
        public Board Board;
        public Player Player1;
        public Player Player2;
        public string Message { get; set; }

        public Game()
        {
            ID = "1";
            Board = new Board();
            Player1 = new Player("Player1", "red");
            Player2 = new Player("Player2", "blue");
        }


    }
}
