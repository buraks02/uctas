using System;
namespace uctas.Models.ViewModels
{
    public class PlayerViewModel
    {
        public PlayerViewModel() {
        
        }

        public string PlayerName { get; set; }
        public StoneViewModel[] Stones { get; set; } = new StoneViewModel[] {
            new StoneViewModel() { StoneId = 1 },
            new StoneViewModel() { StoneId = 2 },
            new StoneViewModel() { StoneId = 3 }
          };
        public string Color { get; set; }
    }
}
