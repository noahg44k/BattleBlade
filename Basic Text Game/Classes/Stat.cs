using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Text_Game.Classes
{
    public class Stat
    {
        public string name = "";
        public int value = 0;
        public static List<Stat> stats = new List<Stat>();
        public static Stat statContr = new Stat();
            
        public Stat newStat(string name, int value)
        {
            Stat stat = new Stat();
            stat.name = name;
            stat.value = value;

            return stat;
        }

    }
}
