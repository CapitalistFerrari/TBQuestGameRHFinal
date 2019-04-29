using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGameRH.Models
{
    public class GameItemQuantity
    {

        public GameItem GameItem { get; set; }
        public int Quantity { get; set; }
        public int Level { get; set; }

        public GameItemQuantity()
        {

        }

        public GameItemQuantity(GameItem gameItem, int quantity, int level)
        {
            GameItem = gameItem;
            Quantity = quantity;
            Level = level;
        }
    }
}
