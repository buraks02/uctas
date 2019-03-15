using System;
namespace uctas.Models
{
    public class Node
    {
        public int ID { get; set; }
        public Player Player { get; set; }
        public Stone Stone { get; set; }
        public Node()
        {
        }
    }
}
