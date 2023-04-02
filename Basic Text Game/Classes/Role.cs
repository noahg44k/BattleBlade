using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Text_Game.Classes
{
    public class Role
    {
        public string name = "";
        public string desc = "";
        public string god = "";
        public static List<Role> roles = new List<Role>();
        public List<Stat> roleStats = new List<Stat>();
        public static Role roleContr = new Role();

        public void newRole(string name, string god, string desc, int str, int luck, int vig, int spd, int inl, int prc)
        {
            Role role = new Role();

            role.god = god;

            role.roleStats.Add(new Stat().newStat("Strength", str));
            role.roleStats.Add(new Stat().newStat("Luck", luck));
            role.roleStats.Add(new Stat().newStat("Vigor", vig));
            role.roleStats.Add(new Stat().newStat("Speed", spd));
            role.roleStats.Add(new Stat().newStat("Intelligence", inl));
            role.roleStats.Add(new Stat().newStat("Precision", prc));

            role.name = name;
            role.desc = desc;

            roles.Add(role);
        }

        public Role getRole(string name)
        {
            foreach(Role role in roles)
            {
                if(role.name == name)
                {
                    return role;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR Could not find role of name " + name);
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();
            return null;
        }

        public void buildRoleIndex()
        {
            newRole("Thief", "Godess Vica", "A swift and cunning assassin type class, " +
                "proficient with daggers and knives. \nGodess Vica watches " +
                "over all thieves.", 4, 8, 5, 11, 6, 7);
            newRole("Knight", "God Beram", "A strong and sturdy breed, the knights " +
                "protect and serve their king, Napir. \nProficient with mighty" +
                " swords and hammers. God Beram watches over all knights."
                , 11, 6, 9, 4, 3, 5);
            newRole("Sorcerer", "Godess Kakia", "The mages of this land, sorcerers are " +
                "highly intelligent, yet lack the physical \nprowess needed " +
                "to wield a sword. Godess Kakia watches over all sorcerers."
                , 2, 5, 4, 6, 11, 9);
            newRole("Archer", "God Coses", "Precise and swift, these kind are deadly from " +
                "long range. Proficient with bows and \ncrossbows. God Coses" +
                " watches over all archers.", 7, 3, 4, 9, 7, 11);
            newRole("Barren", "God Bast", "A shell of who they once were. They were not" +
                " fit to live this world, yet they refuse \nto give up. God Bast" +
                " watches over all barren.", 1, 1, 1, 1, 1, 1);
            newRole("Blest", "God Osper", "Not particularly skillful in any area, these" +
                " kind survive on pure fortune alone. \nGod Osper watches over " +
                "all blest.", 4, 12, 4, 4, 4, 4);
        }

        public float calculateHealth(int lvl)
        {
            float healthMultiplier = 1.1f;
            float baseHealth = 68.302f;
            float newHealth;

            newHealth = baseHealth * (float)(Math.Pow(healthMultiplier, lvl));
            return newHealth;
        }

        public void raiseStat(string name)
        {
            foreach (Stat stat in roleStats)
            {
                if (stat.name == name)
                {
                    stat.value++;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(name + " was increased by 1!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                    if (name == "Strength")
                    {
                        //make strength change something
                        return;
                    }
                    else if (name == "Luck")
                    {
                        //make item discovery increase
                        return;
                    }
                    else if (name == "Vigor")
                    {
                        Game.player.maxHealth = calculateHealth(Game.player.role.getStat("Vigor").value);
                        return;
                    }
                    else if (name == "Speed")
                    {
                        //make speed do something
                        return;
                    }
                    else if (name == "Intelligence")
                    {
                        //make intelligence do something
                        return;
                    }
                    else if (name == "Precision")
                    {
                        //make precision do something
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR Could not find stat of name " + name);
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        Game.tc('W');
                        Console.ReadKey();
                        return;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR Could not find stat of name " + name);
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();
            return;
        }

        public void lowerStat(string name)
        {
            foreach (Stat stat in roleStats)
            {
                if (stat.name == name)
                {
                    stat.value--;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(name + " was decreased by 1!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR Could not find stat of name " + name);
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();
        }

        public void setStat(string name, int value)
        {
            foreach (Stat stat in roleStats)
            {
                if (stat.name == name)
                {
                    stat.value = value;
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR Could not find stat of name " + name);
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();
            return;
        }

        public Stat getStat(string name)
        {
            foreach (Stat stat in roleStats)
            {
                if (stat.name == name)
                {
                    return stat;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR Could not find stat of name " + name);
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();
            return null;
        }
    }
}
