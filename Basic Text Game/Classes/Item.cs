using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Text_Game.Classes
{
    public class Item
    {
        public string name = "";
        public string use = "";
        public int ID = 0;
        public int AR = 0; //ARMOR RATING
        public int stage = 1;
        public int stackHeight = 1;
        public int currentStack = 0;
        public float wepDmg = 0f;
        public float heal = 0;
        public float discoverChance = 1;
        public bool equipped = false;
        public static List<Item> items = new List<Item>();

        public Dictionary<string, int> minStats = new Dictionary<string, int>();
        public Dictionary<string, int> sclStats = new Dictionary<string, int>();

        /*
        public int minStr = 1;
        public int minLuc = 1;
        public int minVig = 1;
        public int minSpd = 1;
        public int minInl = 1;
        public int minPrc = 1;

        public int sclStr = 1;
        public int sclLuc = 1;
        public int sclVig = 1;
        public int sclSpd = 1;
        public int sclInl = 1;
        public int sclPrc = 1;
        */

        int prevID = 0;

        public Item copyItem(Item item)
        {
            Item copy = new Item();
            copy.name = item.name;
            copy.heal = item.heal;
            copy.wepDmg = item.wepDmg;
            copy.AR = item.AR;
            copy.ID = item.ID;
            copy.use = item.use;
            copy.equipped = item.equipped;

            return copy;
        }

        public static Item getItem(string name)
        {
            foreach (Item item in items)
            {
                if (item.name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            Console.WriteLine("Could not find item of name: {0}", name);
            return null;
        }

        public static Item getRandomItem(int ID)
        {
            foreach (Item item in items)
            {
                if (item.ID == ID)
                {
                    return item;
                }
            }
            Console.WriteLine("Could not find item of ID: {0}", ID);
            return null;
        }

        public void newWeapon(string name, float dmg, float heal, int stage, 
            List<string> scaleStatNames = null, List<int> scaleStatValues = null,
            List<string> minStatNames = null, List<int> minStatValues = null,
            float discoverChance = 1)
        {
            Item newWeapon = new Item();
            newWeapon.name = name;
            newWeapon.ID = prevID + 1;
            prevID = newWeapon.ID;
            newWeapon.wepDmg = dmg;
            newWeapon.heal = heal;
            newWeapon.use = "equip";
            newWeapon.equipped = false;
            newWeapon.stage = stage;
            newWeapon.discoverChance = discoverChance;

            try
            {
                newWeapon.minStats.Add("Strength", 1);
                newWeapon.minStats.Add("Luck", 1);
                newWeapon.minStats.Add("Vigor", 1);
                newWeapon.minStats.Add("Speed", 1);
                newWeapon.minStats.Add("Intelligence", 1);
                newWeapon.minStats.Add("Precision", 1);

                newWeapon.sclStats.Add("Strength", 1);
                newWeapon.sclStats.Add("Luck", 1);
                newWeapon.sclStats.Add("Vigor", 1);
                newWeapon.sclStats.Add("Speed", 1);
                newWeapon.sclStats.Add("Intelligence", 1);
                newWeapon.sclStats.Add("Precision", 1);
            }
            catch{}

            if (minStatNames != null)
            {
                for (int i = 0; i < minStatNames.Count; i++)
                {
                    newWeapon.minStats[minStatNames[i]] = minStatValues[i];
                }
            }
            
            if(scaleStatNames != null)
            {
                for (int i = 0; i < scaleStatNames.Count; i++)
                {
                    newWeapon.sclStats[scaleStatNames[i]] = scaleStatValues[i];
                }
            }

            foreach (Item item in items)
            {
                if (item.name == newWeapon.name)
                {
                    items.Remove(item);
                    Console.WriteLine("Removed item with duplicate name {0}", newWeapon.name);
                }
            }

            items.Add(newWeapon);
            Console.WriteLine("Item added to items with name {0}", newWeapon.name + " and item ID " + newWeapon.ID);
        }

        public void newArmor(string name, int AR, int stage,
            List<string> scaleStatNames = null, List<int> scaleStatValues = null,
            List<string> minStatNames = null, List<int> minStatValues = null,
            float discoverChance = 1)
        {
            Item newArmor = new Item();
            newArmor.name = name;
            newArmor.ID = prevID + 1;
            prevID = newArmor.ID;
            newArmor.AR = AR;
            newArmor.use = "put on";
            newArmor.stage = stage;
            newArmor.discoverChance = discoverChance;

            try
            {
                newArmor.minStats.Add("Strength", 1);
                newArmor.minStats.Add("Luck", 1);
                newArmor.minStats.Add("Vigor", 1);
                newArmor.minStats.Add("Speed", 1);
                newArmor.minStats.Add("Intelligence", 1);
                newArmor.minStats.Add("Precision", 1);

                newArmor.sclStats.Add("Strength", 1);
                newArmor.sclStats.Add("Luck", 1);
                newArmor.sclStats.Add("Vigor", 1);
                newArmor.sclStats.Add("Speed", 1);
                newArmor.sclStats.Add("Intelligence", 1);
                newArmor.sclStats.Add("Precision", 1);
            }
            catch {}

            if (minStatNames != null)
            {
                for (int i = 0; i < minStatNames.Count; i++)
                {
                    newArmor.minStats[minStatNames[i]] = minStatValues[i];
                }
            }

            if (scaleStatNames != null)
            {
                for (int i = 0; i < scaleStatNames.Count; i++)
                {
                    newArmor.sclStats[scaleStatNames[i]] = scaleStatValues[i];
                }
            }

            foreach (Item item in items)
            {
                if (item.name == newArmor.name)
                {
                    items.Remove(item);
                    Console.WriteLine("Removed item with duplicate name {0}", newArmor.name);
                }
            }

            items.Add(newArmor);
            Console.WriteLine("Item added to items with name {0}", newArmor.name + " and item ID " + newArmor.ID);
        }

        public void newItem(string name, int heal, int stage, int stackHeight,
            List<string> scaleStatNames = null, List<int> scaleStatValues = null,
            List<string> minStatNames = null, List<int> minStatValues = null,
            float discoverChance = 1)
        {
            Item newItem = new Item();
            newItem.name = name;
            newItem.ID = prevID + 1;
            prevID = newItem.ID;
            newItem.heal = heal;
            newItem.use = "heal";
            newItem.stage = stage;
            newItem.stackHeight = stackHeight;
            newItem.discoverChance = discoverChance;

            try
            {
                newItem.minStats.Add("Strength", 1);
                newItem.minStats.Add("Luck", 1);
                newItem.minStats.Add("Vigor", 1);
                newItem.minStats.Add("Speed", 1);
                newItem.minStats.Add("Intelligence", 1);
                newItem.minStats.Add("Precision", 1);

                newItem.sclStats.Add("Strength", 1);
                newItem.sclStats.Add("Luck", 1);
                newItem.sclStats.Add("Vigor", 1);
                newItem.sclStats.Add("Speed", 1);
                newItem.sclStats.Add("Intelligence", 1);
                newItem.sclStats.Add("Precision", 1);
            }
            catch { }

            if (minStatNames != null)
            {
                for (int i = 0; i < minStatNames.Count; i++)
                {
                    newItem.minStats[minStatNames[i]] = minStatValues[i];
                }
            }

            if (scaleStatNames != null)
            {
                for (int i = 0; i < scaleStatNames.Count; i++)
                {
                    newItem.sclStats[scaleStatNames[i]] = scaleStatValues[i];
                }
            }

            foreach (Item item in items)
            {
                if (item.name == newItem.name)
                {
                    items.Remove(item);
                    Console.WriteLine("Removed item with duplicate name {0}", newItem.name);
                }
            }

            items.Add(newItem);
            Console.WriteLine("Item added to items with name {0}", newItem.name + " and item ID " + newItem.ID);
        }

        public static void AddAllItemsInStage(int stageNum)
        {
            foreach(Item item in items)
            {
                if(item.stage == stageNum)
                {
                    Game.player.stageItemsAvailable.Add(item);
                }
            }
        }

        public void buildItemDex()
        {
            //WEAPONS
            //         name   dmg, heal, stg,               required skill              required skill lvl                  scaling skill         scaling skill amount
            newWeapon("Sword", 8, -3.5f, 1, (new List<string> { "Strength" }), (new List<int>() { 5 }), new List<string>() { "Strength"}, new List<int>() { 5 }, 1);
            newWeapon("Knife", 3, -1, 1, (new List<string> { "Speed" }), (new List<int>() { 3 }), new List<string>() { "Speed" }, new List<int>() { 3 }, 1);
            newWeapon("Dagger", 5f, -1.5f, 1, (new List<string> { "Speed" }), (new List<int>() { 5 }), new List<string>() { "Speed" }, new List<int>() { 5 }, 0.8f);
            newWeapon("Short Bow", 10, -5, 1, (new List<string> { "Precision", "Strength" }), (new List<int>() { 6, 4 }), new List<string>() { "Precision", "Strength" }, new List<int>() { 6, 3 }, 0.7f);
            newWeapon("Hatchet", 8f, -2, 1, (new List<string> { "Strength", "Speed" }), (new List<int>() { 3, 2 }), new List<string>() { "Strength", "Speed" }, new List<int>() { 3, 3 }, 0.8f);

            newWeapon("Crossbow", 14, -8, 2, (new List<string> { "Precision", "Strength" }), (new List<int>() { 6, 5 }), new List<string>() { "Precision", "Strength" }, new List<int>() { 5, 2 }, 0.85f);
            newWeapon("Spear", 13, -4, 2, (new List<string> { "Strength", "Precision" }), (new List<int>() { 6, 5 }), new List<string>() { "Strength", "Precision" }, new List<int>() { 5, 4 }, 1);
            newWeapon("Warhammer", 11.5f, -2, 2, (new List<string> { "Strength" }), (new List<int>() { 5 }), new List<string>() { "Strength" }, new List<int>() { 4 }, 1);
            newWeapon("War Axe", 15.5f, -4, 2, (new List<string> { "Strength" }), (new List<int>() { 10 }), new List<string>() { "Strength" }, new List<int>() { 9 }, 0.8f);
            newWeapon("Club", 12, -5, 2, (new List<string> { "Strength" }), (new List<int>() { 7 }), new List<string>() { "Strength" }, new List<int>() { 9 }, 0.7f);

            newWeapon("The Big One", 120, -40, 3);
            newWeapon("Life Staff", 18, 100, 3);
            newWeapon("Death Staff", 200, -100, 3);
            newWeapon("Dragon Club", 212, -60, 3);

            newWeapon("Electric Staff", 30, -6, 4, (new List<string> { "Intelligence" }), (new List<int>() { 10 }), new List<string>() { "Intelligence" }, new List<int>() { 8 });
            newWeapon("Light Staff", 20, -2, 4, (new List<string> { "Intelligence" }), (new List<int>() { 7 }), new List<string>() { "Intelligence" }, new List<int>() { 6 });
            newWeapon("Dark Staff", 20, -2, 4, (new List<string> { "Intelligence" }), (new List<int>() { 7 }), new List<string>() { "Intelligence" }, new List<int>() { 6 });
            newWeapon("Poison Staff", 29, -20, 4, (new List<string> { "Intelligence" }), (new List<int>() { 5 }), new List<string>() { "Intelligence" }, new List<int>() { 5 });
            newWeapon("Trident", 26, -20, 4, (new List<string> { "Strength", "Precision" }), (new List<int>() { 12, 10 }), new List<string>() { "Strength", "Precision" }, new List<int>() { 8, 7 }, 0.5f);

            newWeapon("Fire Staff", 72, -10, 5);
            newWeapon("Earth Staff", 66, -15, 5);
            newWeapon("Battle Axe", 55, -5, 5);
            newWeapon("Demon Blade", 88, -40, 5);//RARE
            newWeapon("Great Zweihander", 61, -10, 5);

            newWeapon("Elder Staff", 700, 0, 6);
            newWeapon("Elder Blade", 2500, 0, 6);//LEGENDARY
            newWeapon("Elder Bow", 650, 0, 6);
            newWeapon("Fist", 1, 0, 6);

            //ARMOR
            newArmor("Nakey", 0, 0);

            newArmor("Wolfskin Armor", 15, 1);
            newArmor("Orcskin Armor", 23, 1);
            newArmor("Ent Armor", 18, 1);

            newArmor("Bone Armor", 31, 2);
            newArmor("Leather Armor", 34, 2);

            newArmor("Sea Dweller Armor", 39, 3);
            newArmor("Shell Armor", 46, 3);

            newArmor("Hell Armor", 58, 4);
            newArmor("Chain Armor", 65, 4);
            newArmor("Inferno Armor", 97, 4);//LEGENDARY

            newArmor("Steel Armor", 76, 5);
            newArmor("Dragonian Armor", 99, 5);//LEGENDARY
            newArmor("Magic Armor", 84, 5);

            newArmor("Elder Armor", 93, 6);

            //ITEMS
            newItem("Health Potion", 55, 7, 5);
            newItem("Large Health Potion", 100, 7, 3);
            newItem("Wolf Meat", 20, 1, 10);
            newItem("Orc Meat", 15, 1, 10);
            newItem("Spider Meat", 10, 2, 10);
            newItem("Bone Meat", 45, 2, 10);
            newItem("Sea Dweller Meat", 28, 3, 10);
            newItem("Hell Meat", 2, 4, 10);
            newItem("Shell Meat", 29, 3, 10);
            newItem("Ent Meat", 30, 1, 10);
            newItem("Elder Meat", 125, 6, 10);
            newItem("Chain Meal", 10, 4, 10);
            newItem("Steel Meal", 5, 4, 10);
            newItem("Dragon Meat", 120, 5, 10);
            newItem("Hippogriff Meat", 125, 5, 10);
            newItem("Wyrm Meat", 4000, 5, 10);//LEGENDARY
        }
    }

}
