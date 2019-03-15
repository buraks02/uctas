using System;
using uctas.Models.ViewModels;

namespace uctas.Models
{
    public class Board
    {
        public Node[] Nodes = new Node[]
        {
            new Node { ID = 0, Stone = null },
            new Node { ID = 1, Stone = null },
            new Node { ID = 2, Stone = null },
            new Node { ID = 3, Stone = null },
            new Node { ID = 4, Stone = null },
            new Node { ID = 5, Stone = null },
            new Node { ID = 6, Stone = null },
            new Node { ID = 7, Stone = null },
            new Node { ID = 8, Stone = null }
        };

        public Board()
        {
        }
    }
}
