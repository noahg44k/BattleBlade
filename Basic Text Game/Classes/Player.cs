using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Text_Game.Classes
{
    public class Player
    {
        public List<Item> inventory = new List<Item>();
        public Item currentWeapon = new Item();
        public Item currentArmor = new Item();
        public List<Item> stageItemsAvailable = new List<Item>();
        public Role role = new Role();
        public string name = "";
        public float maxHealth = 75f;
        public float health = 75f;
        public float dmg = 1f;
        public float dmgMod = 1;
        public int AR = 0; //ARMOR RATING
        public long xp = 0;
        public int lvl = 1;
        public int distWalked = 0;
        public int lvlXpCap = 25;
        public int faith = 0;

        public Item getInvItem(string name)
        {
            foreach (Item item in inventory)
            {
                if (item.name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            Console.WriteLine("Could not find item of name " + name);
            return null;
        }

        public int determineXPCap()
        {
            int xpCap = 25;

            int total = 0;
            foreach (Stat stat in role.roleStats)
            {
                total += stat.value;
            }
            role.roleLevel = total;
            xpCap += 5 * role.roleLevel;
            return xpCap;
        }

        public void resetPlayer()
        {
            name = "";
            maxHealth = 75f;
            health = 75f;
            dmg = 1f;
            dmgMod = 1;
            AR = 0; //ARMOR RATING
            xp = 0;
            lvlXpCap = 25;
            lvl = 1;
            distWalked = 0;
            faith = 0;
            Clock.resetClock();
            inventory.Clear();
            inventory.Add(Item.getItem("fist"));
            currentWeapon = getInvItem("fist");
            currentArmor = Item.getItem("nakey");
            Game.map.setStage(Map.Stage.first);
            Game.map.checkStage();
        }

        public void addXP(long newXP)
        {
            xp += newXP;

            lvlXpCap = determineXPCap();

            while(xp >= lvlXpCap)
            {
                 lvlUp();
            }
        }

        public void increaseStat()
        {
            while(true)
            {
                Game.PrintTitle();
                Game.tc('W');
                Console.WriteLine("Which stat would you like to increase?");
                Game.tc('g');
                int num = 1;
                foreach (Stat stat in role.roleStats)
                {
                    Console.WriteLine(num + ". " + stat.name + ": " + stat.value);
                    num++;
                }
                Console.WriteLine("\n");
                Game.tc('W');
                string choice = Console.ReadLine().ToLower();
                if (choice.Contains("1") || choice.Contains("str"))
                {
                    while(true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("You want to increase Strength?");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("y/n");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm.Contains("y"))
                        {
                            role.raiseStat("Strength");
                            return;
                        }
                        else if(confirm.Contains("n"))
                        {
                            break;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
                else if (choice.Contains("2") || choice.Contains("luck"))
                {
                    while (true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("Cannot upgrade luck. Pray to your god to increase luck.");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("Press any key to continue");
                        Game.tc('W');
                        Console.ReadKey();
                        break;
                    }
                }
                else if (choice.Contains("3") || choice.Contains("vig"))
                {
                    while (true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("You want to increase Vigor?");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("y/n\n");
                        Game.tc('W');
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm.Contains("y"))
                        {
                            role.raiseStat("Vigor");
                            return;
                        }
                        else if (confirm.Contains("n"))
                        {
                            break;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
                else if (choice.Contains("4") || choice.Contains("spee"))
                {
                    while (true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("You want to increase Speed?");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("y/n");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm.Contains("y"))
                        {
                            role.raiseStat("Speed");
                            return;
                        }
                        else if (confirm.Contains("n"))
                        {
                            break;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
                else if (choice.Contains("5") || choice.Contains("inte"))
                {
                    while (true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("You want to increase Intelligence?");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("y/n");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm.Contains("y"))
                        {
                            role.raiseStat("Intelligence");
                            return;
                        }
                        else if (confirm.Contains("n"))
                        {
                            break;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
                else if (choice.Contains("6") || choice.Contains("prec"))
                {
                    while (true)
                    {
                        Game.PrintTitle();
                        Game.tc('W');
                        Console.WriteLine("You want to increase Precision?");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("y/n");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm.Contains("y"))
                        {
                            role.raiseStat("Precision");
                            return;
                        }
                        else if (confirm.Contains("n"))
                        {
                            break;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void lvlUp()
        {
            Map.Stage beforeStage = Game.map.getStage();

            lvl++;
            lvlXpCap = determineXPCap();
            xp -= 200;
            if (xp < 0)
            {
                xp = 0;
            }
            Game.PrintTitle();
            Game.map.checkStage();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You leveled up to level " + lvl + "!");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Game.tc('W');
            Console.ReadKey();

            increaseStat();

            if (beforeStage != Game.map.getStage())
            {
                Console.WriteLine("\nCongratulations! You entered the " + Game.map.getStage() + " stage!");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Game.tc('W');
                Console.ReadKey();
            }
            Game.tc('W');
            health = maxHealth;
        }

        public void takeDamage(float damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            float damageTaken = damage * (1 - (AR * 0.01f));
            if (damageTaken < 0)
            {
                Console.WriteLine("You took 0 pts of damage!");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Game.tc('W');
                Console.ReadKey();
                damageTaken = 0;
            }
            else
            {
                health -= damageTaken;
                Console.WriteLine("You took " + damageTaken.ToString("0.00") + " pts of damage!");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Game.tc('W');
                Console.ReadKey();
                damageTaken = 0;
            }

            if (health <= 0)
            {
                Game.death();
            }
        }

        public void heal(float heal)
        {
            health += heal;
            if (health > maxHealth)
                health = maxHealth;
            Console.WriteLine("You healed {0}", heal + " health pts!");
        }

        //ATTACK VARS
        //USED FOR "TIRING YOU OUT"
        //INCREASES THE AMOUNT OF REST YOU CAN HAVE IF YOU ATTACK FOUR TIMES
        public int numOfAttacks = 0;

        public float calculateDamage(int lvl, int minStat, int scaleStat)
        {
            //TAKE MINIMUM STAT LEVEL AND EACH LEVEL ABOVE THAT, USE THE FORMULA
            float dmgMultiplier = 1.1f;
            float newDmg;

            int difference = lvl - minStat;
            // SCALES DAMAGE UP EXPONENTIALLY FOR EACH LEVEL ABOVE
            // MINIMUM * SCALE VALUE FOR THAT STAT
            newDmg = (float)(Math.Pow(dmgMultiplier, difference)) * (1 + (scaleStat * 0.5f))-1;
            return newDmg;
        }

        public float wepDamageWithWeaponScaling(Item weapon)
        {
            float damage = 0;
            // INTELLIGENCE
            if (weapon.minStats["Intelligence"] > role.getStat("Intelligence").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Intelligence"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Intelligence"] < role.getStat("Intelligence").value)
            {
                damage += calculateDamage(role.getStat("Intelligence").value, weapon.minStats["Intelligence"], weapon.sclStats["Intelligence"]);
            }
            // LUCK
            if (weapon.minStats["Luck"] > role.getStat("Luck").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Luck"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Luck"] < role.getStat("Luck").value)
            {
                damage += calculateDamage(role.getStat("Luck").value, weapon.minStats["Luck"], weapon.sclStats["Luck"]);
            }
            // PRECISION
            if (weapon.minStats["Precision"] > role.getStat("Precision").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Precision"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Precision"] < role.getStat("Precision").value)
            {
                damage += calculateDamage(role.getStat("Precision").value, weapon.minStats["Precision"], weapon.sclStats["Precision"]);
            }
            // SPEED
            if (weapon.minStats["Speed"] > role.getStat("Speed").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Speed"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Speed"] < role.getStat("Speed").value)
            {
                damage += calculateDamage(role.getStat("Speed").value, weapon.minStats["Speed"], weapon.sclStats["Speed"]);
            }
            // STRENGTH
            if (weapon.minStats["Strength"] > role.getStat("Strength").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Strength"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Strength"] < role.getStat("Strength").value)
            {
                damage += calculateDamage(role.getStat("Strength").value, weapon.minStats["Strength"], weapon.sclStats["Strength"]);
            }
            // VIGOR
            if (weapon.minStats["Vigor"] > role.getStat("Vigor").value)
            {
                //do nothing
                damage += 0;
            }
            else if (weapon.minStats["Vigor"] == 1)
            {
                // do nothing
                damage += 0;
            }
            else if (weapon.minStats["Vigor"] < role.getStat("Vigor").value)
            {
                damage += calculateDamage(role.getStat("Vigor").value, weapon.minStats["Vigor"], weapon.sclStats["Vigor"]);
            }
            return damage;
        }

        public void useItem()
        {
            while (true)
            {
                Game.PrintTitle();
                Console.WriteLine("What item would you like to use?");
                printInventory();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press Enter to go back");
                Game.tc('W');
                string choice = Console.ReadLine();

                if (choice.ToLower() == "" || choice == "nothing" || choice == "back" || choice == "exit" || choice == null)
                {
                    Enemy.completedAction = false;
                    Game.PrintTitle();
                    return;
                }
                else
                {
                    foreach (Item item in inventory)
                    {
                        if (choice.ToLower() == item.name.ToLower())
                        {
                            if (item.use == "heal")
                            {
                                Game.PrintTitle();
                                heal(item.heal);
                                item.currentStack -= 1;
                                if(item.currentStack == 0)
                                    inventory.Remove(item);
                                Enemy.completedAction = true;
                                Thread.Sleep(1000);
                                Game.PrintTitle();
                                return;
                            }
                            else if (item.use == "equip")
                            {
                                if (!item.equipped)
                                {
                                    Game.PrintTitle();
                                    currentWeapon.equipped = false;
                                    currentWeapon = item;
                                    currentWeapon.equipped = true;
                                    Console.WriteLine("You equipped {0}", item.name);
                                    Enemy.completedAction = false;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Press any key to continue");
                                    Game.tc('W');
                                    Console.ReadKey();
                                    Game.PrintTitle();
                                    return;
                                }
                                else
                                {
                                    Game.PrintTitle();
                                    currentWeapon.equipped = false;
                                    currentWeapon = getInvItem("fist");
                                    currentWeapon.equipped = true;
                                    Console.WriteLine("You unequipped {0}", item.name);
                                    Enemy.completedAction = false;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Press any key to continue");
                                    Game.tc('W');
                                    Console.ReadKey();
                                    Game.PrintTitle();
                                    return;
                                }
                            }
                            else if (item.use == "put on")
                            {
                                if (!item.equipped)
                                {
                                    Game.PrintTitle();
                                    currentArmor.equipped = false;
                                    currentArmor = item;
                                    currentArmor.equipped = true;
                                    AR = currentArmor.AR;
                                    Console.WriteLine("You equipped {0}", item.name);
                                    Enemy.completedAction = false;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Press any key to continue");
                                    Game.tc('W');
                                    Console.ReadKey();
                                    Game.PrintTitle();
                                    return;
                                }
                                else if(item.equipped)
                                {
                                    Game.PrintTitle();
                                    currentArmor.equipped = false;
                                    currentArmor = Item.getItem("nakey");
                                    AR = 0;
                                    Console.WriteLine("You unequipped {0}", item.name);
                                    Enemy.completedAction = false;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Press any key to continue");
                                    Game.tc('W');
                                    Console.ReadKey();
                                    Game.PrintTitle();
                                    return;
                                }
                            }
                            else
                            {
                                Game.PrintTitle();
                                Console.WriteLine("{0}", choice + " could not be used!");
                                Enemy.completedAction = false;
                                Console.WriteLine("Please type in the name of a useable item...");
                                Thread.Sleep(500);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Press any key to continue");
                                Game.tc('W');
                                Console.ReadKey();
                                Game.PrintTitle();
                                break;
                            }
                        }
                    }
                    Game.PrintTitle();
                    Console.WriteLine("You don't have {0}", choice + "!");
                    Enemy.completedAction = false;
                    Console.WriteLine("Type in an item name...");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    Game.PrintTitle();
                }
            }
        }

        public void pickUp(Item item)
        {
            Game.PrintTitle();
            if (item.currentStack+1 <= item.stackHeight)
            {
                item.currentStack += 1;
                if(!inventory.Contains(item))
                    inventory.Add(item);
                Console.WriteLine("You picked up {0}", item.name + "!");
            }
            else
            {
                Console.WriteLine("You encountered a " + item.name + ", but you have the maximum amount of that item already.");
            }
        }

        public void pray()
        {
            while(true)
            {
                Game.PrintTitle();
                Game.tc('Y');
                Console.WriteLine("PRAY TO YOUR GOD: " + role.god);
                Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                Game.tc('g');
                Console.WriteLine("Faith: " + faith);
                Game.tc('Y');
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("What would you like to pray for?");
                Console.WriteLine("1. Favor");
                Console.WriteLine("2. Luck");
                Console.WriteLine("3. Weapon Imbuement");
                Game.tc('g');
                Console.WriteLine("Praying increases faith, which is used to cast blessings.");
                Console.WriteLine("Press 9 or type exit");
                Console.WriteLine("");

                string input = Console.ReadLine().ToLower();
                if (input.Contains("exit") || input.Contains("9"))
                {
                    return;
                }
            }
        }

        //REST VARS
        int restLimit = 8;
        public int restLevel = 0;

        public void rest()
        {
            Random rand = new Random();
            int num = rand.Next(1, 4);
            string level = "";

            Game.PrintTitle();
            restLevel += num;
            if (restLevel <= restLimit)
            {
                Console.WriteLine("You rested for {0}", num + " hours.\n");
                Clock.increaseTime(num, 0);
                num = rand.Next(0, 4);
                switch (num)
                {
                    case 0:
                        level = "tired";
                        Console.WriteLine("You gained 0 health points.");
                        break;
                    case 1:
                        level = "the same as you did before";
                        int healNum = rand.Next(5, 11);
                        heal(healNum);
                        break;
                    case 2:
                        level = "refreshed";
                        healNum = rand.Next(12, 18);
                        heal(healNum);
                        break;
                    case 3:
                        level = "amazing";
                        healNum = rand.Next(19, 25);
                        heal(healNum);
                        break;
                }

                if (health >= maxHealth)
                {
                    health = maxHealth;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("|You are fully healed!|");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~\n");
                    Game.tc('W');
                }
                Console.WriteLine("You feel {0}", level + ".");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Game.tc('W');
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You aren't tired anymore!");
                Console.WriteLine("You have to tire yourself out first.");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                Game.tc('W');
                Console.ReadKey();
            }
            
        }

        public void explore()
        {
            Random rand = new Random();
            int num = rand.Next(0, 7);
            int previousDist = 0;
            int walkTime;

            Game.PrintTitle();
            Console.WriteLine("                                            (  N  )");
            Console.WriteLine("What direction would you like to travel in? (W + E)");
            Console.WriteLine("                                            (  S  )");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(North, West, Forward, Left, etc.)");
            Game.tc('W');
            string direction = Console.ReadLine();
            switch (num)
            {
                case 0:
                    Enemy.currentEnemy.encounterEnemy();
                    Console.ResetColor();
                    break;
                case 1:
                    Game.PrintTitle();
                    int dist = rand.Next(4, 15);
                    Console.WriteLine("After a long voyage of {0}", dist + " miles, you lay on the floor and take a rest.");
                    distWalked += dist;
                    walkTime = dist * 16;
                    Clock.increaseTime(walkTime);
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    rest();
                    break;
                case 2:
                    Game.PrintTitle();

                    int itemType = rand.Next(0, stageItemsAvailable.Count());

                    Console.WriteLine("What luck! You encountered an item!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();

                    pickUp(stageItemsAvailable.ElementAt(itemType));
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    break;
                case 3:
                    Enemy.currentEnemy.encounterEnemy();
                    Console.ResetColor();
                    break;
                case 4:
                    Game.PrintTitle();
                    dist = rand.Next(4, 15);
                    Console.WriteLine("After a long voyage of {0}", dist + " miles, you decide you can continue.");
                    distWalked += dist;
                    walkTime = dist * 16;
                    Clock.increaseTime(walkTime);
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    break;
                case 5:
                    Game.PrintTitle();
                    dist = rand.Next(4, 15);
                    Console.WriteLine("After a long voyage of {0}", dist + " miles, you decide you can continue.");
                    distWalked += dist;
                    walkTime = dist * 16;
                    Clock.increaseTime(walkTime);
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    break;
                case 6:
                    Game.PrintTitle();

                    itemType = rand.Next(0, stageItemsAvailable.Count());

                    Console.WriteLine("What luck! You encountered an item!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();

                    pickUp(stageItemsAvailable.ElementAt(itemType));
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                    break;
            }
            if(distWalked >= previousDist + 8)
            {
                previousDist = distWalked;
                restLevel = 0;
            }
        }

        public void changeName()
        {
            while (true)
            {
                Game.PrintTitle();
                Console.WriteLine("What would you like to change your name to?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press Enter to cancel");
                Game.tc('W');
                string name = Console.ReadLine();
                if (name == "" || name == null)
                {
                    return;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Are you sure you want to change your name to " + name + "?");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("(y/n)");
                        Game.tc('W');
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm == "y")
                        {
                            Game.player.name = name;
                            return;
                        }
                        else if (confirm == "n")
                        {
                            return;
                        }
                        else
                        {
                            Game.tc('R');
                            Console.WriteLine("Invalid input");
                            Thread.Sleep(500);
                            Game.tc('g');
                            Console.WriteLine("Press any key to continue");
                            Game.tc('W');
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void inspectItem()
        {
            string name = "";
            while (true)
            {
                try
                {
                    Game.PrintTitle();
                    Console.WriteLine("What item would you like to inspect?\n");
                    printInventory();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press Enter to cancel");
                    Game.tc('W');
                    name = Console.ReadLine();

                    if (name == "" || name == null)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            foreach (Item item in inventory)
                            {
                                if (item.name.ToLower() == name.ToLower())
                                {
                                    if (item.use == "equip")
                                    {
                                        Game.PrintTitle();
                                        Console.WriteLine(item.name);
                                        Console.WriteLine("Equipped: " + item.equipped);
                                        Console.WriteLine("Base Damage: " + item.wepDmg);
                                        Console.WriteLine("Damage with Skill Proficiencies: " + (item.wepDmg + wepDamageWithWeaponScaling(item)).ToString());
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                        try
                                        {
                                            //MIN STATS
                                            foreach(KeyValuePair<string, int> kvp in item.minStats)
                                            {
                                                if (role.getStat(kvp.Key).value >= kvp.Value)
                                                {
                                                    Game.tc('E');
                                                }
                                                else
                                                {
                                                    Game.tc('W');
                                                }
                                                Console.WriteLine(String.Format("{0,-25}", "Minimum " + kvp.Key + ": ") + String.Format("{0,10}", kvp.Value));
                                                Game.tc('W');
                                            }

                                            Console.Write("\n");

                                            //SCALE STATS
                                            foreach (KeyValuePair<string, int> kvp in item.sclStats)
                                            {
                                                Console.WriteLine(String.Format("{0,-25}", kvp.Key + " Scaling: ") + String.Format("{0,10}", kvp.Value));
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("smt wrong with the dictionary");
                                            Thread.Sleep(1500);
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine("Press Enter to continue");
                                        Game.tc('W');
                                        Console.ReadKey();
                                    }
                                    else if (item.use == "put on")
                                    {
                                        Game.PrintTitle();
                                        Console.WriteLine(item.name);
                                        Console.WriteLine("Equipped: " + item.equipped);
                                        Console.WriteLine("Armor Rating: " + item.AR);
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        //MIN STATS
                                        foreach (KeyValuePair<string, int> kvp in item.minStats)
                                        {
                                            if (role.getStat(kvp.Key).value >= kvp.Value)
                                            {
                                                Game.tc('E');
                                            }
                                            else
                                            {
                                                Game.tc('W');
                                            }
                                            Console.WriteLine(String.Format("{0,-25}", "Minimum " + kvp.Key + ": ") + String.Format("{0,10}", kvp.Value));
                                            Game.tc('W');
                                        }

                                        Console.Write("\n");

                                        //SCALE STATS
                                        foreach (KeyValuePair<string, int> kvp in item.sclStats)
                                        {
                                            Console.WriteLine(String.Format("{0,-25}", kvp.Key + " Scaling: ") + String.Format("{0,10}", kvp.Value));
                                        }

                                        Game.tc('g');
                                        Console.WriteLine("Press Enter to continue");
                                        Game.tc('W');
                                        Console.ReadKey();
                                    }
                                    else if (item.use == "heal")
                                    {
                                        Game.PrintTitle();
                                        Console.WriteLine(item.name);
                                        Console.WriteLine("Heal: " + item.heal);
                                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        //MIN STATS
                                        foreach (KeyValuePair<string, int> kvp in item.minStats)
                                        {
                                            if (role.getStat(kvp.Key).value >= kvp.Value)
                                            {
                                                Game.tc('E');
                                            }
                                            else
                                            {
                                                Game.tc('W');
                                            }
                                            Console.WriteLine(String.Format("{0,-25}", "Minimum " + kvp.Key + ": ") + String.Format("{0,10}", kvp.Value));
                                            Game.tc('W');
                                        }

                                        Console.Write("\n");

                                        //SCALE STATS
                                        foreach (KeyValuePair<string, int> kvp in item.sclStats)
                                        {
                                            Console.WriteLine(String.Format("{0,-25}", kvp.Key + " Scaling: ") + String.Format("{0,10}", kvp.Value));
                                        }
                                        Game.tc('g');
                                        Console.WriteLine("Press Enter to continue");
                                        Game.tc('W');
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine(name + " is not a valid name");
                            Thread.Sleep(1500);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("It not work idk");
                    Thread.Sleep(1500);
                }
            }
        }

        public void dropItem()
        {
            string name = "";
            while (true)
            {
                try
                {
                    Game.PrintTitle();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("What item would you like to drop?\n");
                    Game.tc('W');
                    printInventory();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press Enter to cancel");
                    Game.tc('W');
                    name = Console.ReadLine();

                    if (name == "" || name == null || name == " ")
                    {
                        return;
                    }

                    foreach (Item item in inventory)
                    {
                        if (name.ToLower() == item.name.ToLower())
                        {
                            if (item.name.ToLower() == "fist")
                            {
                                Console.WriteLine("Cannot drop fists! They are attached to your arms...");
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                if (item == currentWeapon)
                                {
                                    currentWeapon = Item.getItem("fist");
                                }
                                item.currentStack -= 1;
                                if(item.currentStack == 0)
                                    inventory.Remove(item);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You dropped " + name + "!");
                                Thread.Sleep(1500);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Could not find item with name " + name + "!");
                    Thread.Sleep(2000);
                }
            }

        }

        public void printInventory()
        {
            List<Item> weapons = new List<Item>();
            List<Item> armor = new List<Item>();
            List<Item> heals = new List<Item>();

            string weaponSpot = "";
            string armorSpot = "";
            string healsSpot = "";

            List<List<Item>> listsList = new List<List<Item>>();

            foreach (Item item in inventory)
            {
                if (item.use == "equip")
                {
                    weapons.Add(item);
                }
                else if (item.use == "put on")
                {
                    armor.Add(item);
                }
                else if (item.use == "heal")
                {
                    heals.Add(item);
                }
            }

            listsList.Add(weapons);
            listsList.Add(armor);
            listsList.Add(heals);

            var sortedList = listsList.OrderByDescending(l => l.Count()).ToList();

            Console.WriteLine("Inventory: ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            string title = string.Format("{0,-35}{1,-35}{2,-35}\n", "Weapons", "Armor", "Heals");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(title);
            Game.tc('W');
            string inv = "";
            for (int i = 0; i < sortedList[0].Count; i++)
            {
                try
                {
                    weaponSpot = weapons[i].name;
                }
                catch(ArgumentOutOfRangeException)
                {
                    weaponSpot = " ";
                }
                try
                {
                    armorSpot = armor[i].name;
                }
                catch (ArgumentOutOfRangeException)
                {
                    armorSpot = " ";
                }
                try
                {
                    healsSpot = heals[i].name + " x" + heals[i].currentStack;
                }
                catch (ArgumentOutOfRangeException)
                {
                    healsSpot = " ";
                }

                inv += string.Format("{0,-35}{1,-35}{2,-35}\n", weaponSpot, armorSpot, healsSpot);
            }
            Console.WriteLine(inv);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        public void printStats()
        {
            string choice = "";
            string[] leftStats = new string[8];
            string[] rightStats = new string[8];
            while (true)
            {
                Game.PrintTitle();
                string roleName = role.name;
                string healthStr = "HP: " + health.ToString("0.0");
                string maxHealthStr = "Max HP: " + maxHealth.ToString("0.0");
                string xpStr = "XP: " + xp.ToString("0.0");
                string nxtLvl = "XP until next level: " + (determineXPCap() - xp).ToString("0.0");
                string lvlStr = "Level: " + lvl;
                string distWalkedStr = "Distance Walked: " + distWalked.ToString();
                string curStageStr = "Current Stage: " + Game.map.getStage().ToString();
                string armorStr = "Armor Rating: " + AR.ToString();
                string faithStr = "Faith: " + faith;
                string strength = role.getStat("Strength").name + ": " + role.getStat("Strength").value;
                string luck = role.getStat("Luck").name + ": " + role.getStat("Luck").value;
                string vigor = role.getStat("Vigor").name + ": " + role.getStat("Vigor").value;
                string speed = role.getStat("Speed").name + ": " + role.getStat("Speed").value;
                string intelligence = role.getStat("Intelligence").name + ": " + role.getStat("Intelligence").value;
                string precision = role.getStat("Precision").name + ": " + role.getStat("Precision").value;

                leftStats[0] = healthStr;
                leftStats[1] = xpStr;
                leftStats[2] = lvlStr;
                leftStats[3] = distWalkedStr;
                leftStats[4] = luck;
                leftStats[5] = speed;
                leftStats[6] = precision;
                leftStats[7] = strength;

                rightStats[0] = maxHealthStr;
                rightStats[1] = nxtLvl;
                rightStats[2] = curStageStr;
                rightStats[3] = faithStr;
                rightStats[4] = vigor;
                rightStats[5] = intelligence;
                rightStats[6] = armorStr;
                rightStats[7] = "";


                Console.WriteLine("\n"+Game.player.name + "'s Stats\n~~~~~~~~~~~~~~~~~~\n");

                Game.tc('E');
                Console.WriteLine("Class: " + roleName);
                for (int i = 0; i < leftStats.Length; i++)
                {
                    leftStats[i] = String.Format("{0,-58}", leftStats[i]);
                    rightStats[i] = String.Format("{0,-20}", rightStats[i]);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(leftStats[i] + rightStats[i]);
                }
                Console.WriteLine("\n");
                Game.tc('W');

                printInventory();

                Console.WriteLine("What would you like to do?\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Change Name");
                Console.WriteLine("Drop Item");
                Console.WriteLine("Use/Equip Item");
                Console.WriteLine("Inspect Item");
                Console.WriteLine("Leave");
                Game.tc('W');
                try
                {
                    choice = Console.ReadLine().ToLower();

                    if (choice.Contains("name") || choice.Contains("1"))
                    {
                        changeName();
                    }
                    else if (choice.Contains("drop") || choice.Contains("2"))
                    {
                        dropItem();
                    }
                    else if (choice.Contains("use") || choice.Contains("3") || choice.Contains("equip"))
                    {
                        useItem();
                    }
                    else if (choice.Contains("inspect") || choice.Contains("4"))
                    {
                        inspectItem();
                    }
                    else if (choice.Contains("leave") || choice.Contains("5") || choice.Contains("exit"))
                    {
                        return;
                    }
                    else
                    {
                        Game.tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        Game.tc('g');
                        Console.WriteLine("Press any key to continue");
                        Game.tc('W');
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Game.tc('R');
                    Console.WriteLine("Invalid input");
                    Thread.Sleep(500);
                    Game.tc('g');
                    Console.WriteLine("Press any key to continue");
                    Game.tc('W');
                    Console.ReadKey();
                }
            }
        }
    }

}
