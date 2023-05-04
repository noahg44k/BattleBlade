using Basic_Text_Game.Classes;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Xml.Xsl;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

/* USER INPUT CHECKING
 * 
 * while(true)
        {
            try
            {

            }
            catch
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }
        }
 */

public class Game
{
    public static void tc(char color)
    {
        switch (color)
        {
            case 'W':
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 'G':
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case 'g':
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
            case 'M':
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 'm':
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case 'Y':
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 'y':
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case 'E':
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 'e':
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case 'R':
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 'r':
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case 'B':
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 'b':
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case 'C':
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 'c':
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
        }
    }

    public static void death()
    {
        while(true)
        {
            PrintTitle();

            tc('R');
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|          You Died        |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            tc('W');

            Console.WriteLine("Try again?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(y/n)");
            tc('W');
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                SaveData.Delete();
                player.resetPlayer();
                gameLoop();
            }
            else if (choice == "n")
            {
                Console.WriteLine("I bid you farewell, {0}", player.name + ".");
                SaveData.Delete();
                Environment.Exit(0);
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                tc('W');
                Console.ReadKey();
            }
        }
    }

    public static void PrintTitle()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("             ______   ______   ______  ______  __       ______ \n" +
                            "            /\\  == \\ /\\  __ \\ /\\__  _\\/\\__  _\\/\\ \\     /\\  ___\\   \n" +
                            "            \\ \\  __< \\ \\  __ \\\\/_/\\ \\/\\/_/\\ \\/\\ \\ \\____\\ \\  __\\        \n" +
                            "             \\ \\_____\\\\ \\_\\ \\_\\  \\ \\_\\   \\ \\_\\ \\ \\_____\\\\ \\_____\\      \n" +
                            "              \\/_____/ \\/_/\\/_/   \\/_/    \\/_/  \\/_____/ \\/_____/      \n" +
                            "                                                           \n" +
                            "                         ______   __       ______   _____    ______    \n" +
                            "                        /\\  == \\ /\\ \\     /\\  __ \\ /\\  __-. /\\  ___\\   \n" +
                            "                        \\ \\  __< \\ \\ \\____\\ \\  __ \\\\ \\ \\/\\ \\\\ \\  __\\   \n" +
                            "                         \\ \\_____\\\\ \\_____\\\\ \\_\\ \\_\\\\ \\____- \\ \\_____\\ \n" +
                            "                          \\/_____/ \\/_____/ \\/_/\\/_/ \\/____/  \\/_____/ \n" +
                            "                                                           ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        Clock.printTime();
        tc('W');
    }

    // ARE U SURE
    /*
    while (true)
    {
        PrintTitle();
        tc('W');
        Console.WriteLine("Are you sure?");
        Thread.Sleep(500);
        tc('g');
        Console.WriteLine("y/n");
        tc('W');
        string answer = Console.ReadLine();

        if (answer.ToLower().Contains("y"))
        {
            return;
        }
        else if (answer.ToLower().Contains("n"))
        {
            //do something
        }
    }
    */

    public static void ChooseClass()
    {
        Role.buildRoleIndex();
        PrintTitle();
        Thread.Sleep(2000);
        string choice = "";
        while (true)
        {
            int num = 1;
            PrintTitle();
            tc('W');
            Console.WriteLine("So, " + player.name + "...");
            Console.WriteLine("What class would you like to be?");
            Console.WriteLine("\n");
            foreach (Role classes in Role.roles)
            {
                List<Stat> classesStats = new List<Stat>();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(num + ". " + classes.name);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(classes.desc);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (Stat stat in classes.roleStats)
                {
                    Console.WriteLine(stat.name + ": " + stat.value);
                }
                Console.WriteLine("Level: " + classes.roleLevel);
                Console.WriteLine("God: " + classes.god);
                Console.WriteLine("\n");
                num++;
            }
            tc('W');
            choice = Console.ReadLine();

            if (choice.Contains("1") || choice.ToLower().Contains("thie"))
            {
                while(true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be a Thief?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Thief");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Thief class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }

            }
            else if (choice.Contains("2") || choice.ToLower().Contains("kni"))
            {
                while (true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be a Knight?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Knight");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Knight class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }
            }
            else if (choice.Contains("3") || choice.ToLower().Contains("sorc"))
            {
                while (true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be a Sorcerer?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Sorcerer");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Sorcerer class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }
            }
            else if (choice.Contains("4") || choice.ToLower().Contains("arch"))
            {
                while (true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be an Archer?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Archer");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Archer class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }
            }
            else if (choice.Contains("5") || choice.ToLower().Contains("barr"))
            {
                while (true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be a Barren?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Barren");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Barren class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }
            }
            else if (choice.Contains("6") || choice.ToLower().Contains("bles"))
            {
                while (true)
                {
                    PrintTitle();
                    tc('W');
                    Console.WriteLine("Are you sure you want to be a Blest?");
                    Thread.Sleep(500);
                    tc('g');
                    Console.WriteLine("y/n");
                    tc('W');
                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("y"))
                    {
                        Role.assignRole("Blest");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You selected the Blest class!");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                        return;
                    }
                    else if (answer.ToLower().Contains("n"))
                    {
                        break;
                    }
                    else
                    {
                        tc('R');
                        Console.WriteLine("Invalid input");
                        Thread.Sleep(500);
                        tc('g');
                        Console.WriteLine("Press any key to continue");
                        tc('W');
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                tc('W');
                Console.ReadKey();
            }
        }
    }

    public static void Intro()
    {
        PrintTitle();
        Thread.Sleep(2000);
        string choice = "";
        while(true)
        {
            PrintTitle();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                    Welcome to Battle: Blade! The Text-Based RPG!\n");
            tc('W');
            Console.WriteLine("Would you like to...");
            Console.WriteLine("Load previous save");
            Console.WriteLine("Start new save");

            try
            {
                choice = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press any key to continue");
                tc('W');
                Console.ReadKey();
                Intro();
                break;
            }

            if(choice.ToLower().Contains("load")|| choice.ToLower().Contains("previous"))
            {
                try
                {
                    SaveData.Load();
                }
                catch (FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Save not found!");
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue");
                    tc('W');
                    Console.ReadKey();
                    Intro();
                    break;
                }
                playerActions();
                return;
            }
            else if (choice.ToLower().Contains("start") || choice.ToLower().Contains("new"))
            {
                SaveData.NewSave();
                welcomeNewSave();
                return;
            }
        }
    }
 
    public static void welcomeNewSave()
    {
        PrintTitle();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("                    Welcome to Battle: Blade! The Text-Based RPG!\n");
        tc('W');
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        player.name = name;
        player.currentWeapon = player.getInvItem("fist");

        while (true)
        {
            ChooseClass();
            player.maxHealth = Role.calculateHealth(player.role.getStat("Vigor").value);
            player.health = player.maxHealth;
            PrintTitle();
            Console.WriteLine("Let's begin!");
            Thread.Sleep(3000);
            return;
        }
    }

    public static void playerActions()
    {
        string option = "";
        bool canContinue = false;
        while (true)
        {
            SaveData.Save();
            PrintTitle();
            Console.WriteLine("What would you like to do?\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Explore");
            Console.WriteLine("Rest");
            Console.WriteLine("Pray");
            Console.WriteLine("Use/Equip Item");
            Console.WriteLine("Inspect Player");
            Console.WriteLine("Quit");
            tc('W');

            try
            {
                option = Console.ReadLine().ToLower();
                canContinue = true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                tc('W');
                Thread.Sleep(750);
                canContinue = false;
            }

            if(canContinue)
            {
                if (option.Contains("explore") || option.Contains("1"))
                {
                    player.explore();
                }
                else if (option.Contains("rest") || option.Contains("2"))
                {
                    player.rest();
                }
                else if (option.Contains("pray") || option.Contains("3"))
                {
                    player.pray();
                }
                else if(option.Contains("use") || option.Contains("4") || option.Contains("item"))
                {
                    player.useItem();
                }
                else if(option.Contains("player") || option.Contains("5"))
                {
                    player.printStats();
                }
                else if(option.Contains("quit") || option.Contains("6"))
                {
                    while (true)
                    {
                        PrintTitle();
                        Console.WriteLine("Are you sure you want to quit?");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("(y/n)");
                        tc('W');
                        string choice = Console.ReadLine();
                        if (choice.ToLower() == "y")
                        {
                            Console.WriteLine("\nI bid you farewell, {0}", player.name + ".");
                            Thread.Sleep(500);
                            Environment.Exit(0);
                            return;
                        }
                        else if (choice.ToLower() == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input");
                            tc('W');
                            Thread.Sleep(750);
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    tc('W');
                    Thread.Sleep(750);
                }
            }
        }
    }

    public static void gameLoop()
    {
        Intro();
        playerActions();
    }

    public static bool running = true;

    public static Player player = new Player();

    public static Map map = new Map();

    public static void Main(String[] args)
    {
        Item items = new Item();
        Enemy.currentEnemy.buildEnemyDex();
        items.buildItemDex();
        bool running = true;
        map.setStage(Map.Stage.first);
        map.checkStage();

        //START OF GAME

        while(running)
        {
            gameLoop();
        }

        //DEATH
        death();
    }
}