using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernValidator
{
    public class Card
    {
        public int id;
        public double balance;
        public int bonusTime = 60;
        public bool ent_exit = false;
        public int penalTime = 60;
        public Card()
        { }
    }
}
