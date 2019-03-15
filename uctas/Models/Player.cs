using System;
namespace uctas.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Stone[] Stones { get; set; }

        public Player(string playerName, string playerColor)
        {
            Name = playerName;
            Color = playerColor;
            Stones = new Stone[]
            {
                new Stone { ID = 0, NodeId = null },
                new Stone { ID = 1, NodeId = null },
                new Stone { ID = 2, NodeId = null }
            };

        }
    }
}
