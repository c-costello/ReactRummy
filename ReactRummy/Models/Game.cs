using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Game
    {
        //Properties
        public int ID { get; set; }
        public StatusType Status { get; set; }
        
        public Game()
        {
            Status = StatusType.Open;
        }

        //Navigational Properties
        public List<Player> Players { get; set; } 

        //Enums
        public enum StatusType { Open, InGame, Over}

    }
}
