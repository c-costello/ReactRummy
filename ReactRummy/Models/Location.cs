using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models
{
    public class Location
    {
        public int ID {get; set; }
        public int GameID { get; set; }
        public HandType Hand { get; set; }

        public enum HandType { Draw, Discard, Hand, Laydown}
    }
}
