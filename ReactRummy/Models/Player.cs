using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Player
    {
        //Properties
        public int ID { get; set; }
        //Foreign Key from Game
        public int GameID { get; set; }
        //HandID and LaydownID might not be used
        public int HandID { get; set; }
        public int LaydownID { get; set; }
        public string User { get; set; } //Reference to Identity Database
        public int Score { get; set; }

    }
}
