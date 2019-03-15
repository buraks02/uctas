using System;
namespace uctas.Models.ViewModels
{
    public class NodeViewModel
    {
        public int NodeId { get; set; }
        public int? StoneId { get; set; }
        public string PlayerName { get; set; }
        public string Color { get; set; }
    }
}
