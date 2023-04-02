using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Text_Game.Classes
{

    public class Map
    {
        public Stage currentStage = Stage.first;

        public enum Stage
        {
            first = 1,
            second,
            third,
            fourth,
            fifth,
            last
        }

        public void setStage(Stage newStage)
        {
            currentStage = newStage;
        }

        public Stage getStage()
        {
            return currentStage;
        }

        public void checkStage()
        {
            switch (Game.player.lvl)
            {
                case 1:
                case 2:
                case 3:
                    currentStage = Stage.first;//HEALTH AT 100 MAX XP 100
                    break;
                case 4:
                case 5:
                case 6:
                    currentStage = Stage.second;//HEALTH AT 133.1 MAX XP 800
                    break;
                case 7:
                case 8:
                case 9:
                    currentStage = Stage.third;//HEALTH AT 177.16 MIN XP 6400
                    break;
                case 10:
                case 11:
                case 12:
                    currentStage = Stage.fourth;//PLAYER HEALTH AT 235.79 MAX XP 51,200
                    break;
                case 13:
                case 14:
                case 15:
                    currentStage = Stage.fifth;//PLAYER HEALTH AT 313.84 MAX XP 409,600
                    break;
                case 16:
                case 17:
                case 18:
                    currentStage = Stage.last;//PLAYER HEALTH AT 417.72 MAX XP 3,276,800
                    break;
                default:
                    currentStage = Stage.last;
                    break;
            }
            if (currentStage == Map.Stage.first)
            {
                //SETTING STAGE ENEMIES
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(1);

                //SETTING STAGE ITEMS
                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(1);
                Game.player.stageItemsAvailable.Add(Item.getItem("health potion"));
            }
            else if (currentStage == Map.Stage.second)
            {
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(2);

                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(2);
                Item.AddAllItemsInStage(7);
            }
            else if (currentStage == Map.Stage.third)
            {
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(3);

                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(3);
                Item.AddAllItemsInStage(7);
            }
            else if (currentStage == Map.Stage.fourth)
            {
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(4);

                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(4);
                Item.AddAllItemsInStage(7);
            }
            else if (currentStage == Map.Stage.fifth)
            {
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(5);

                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(5);
                Item.AddAllItemsInStage(7);
            }
            else if (currentStage == Map.Stage.last)
            {
                Enemy.stageEnemies.Clear();
                Enemy.currentEnemy.AddAllEnemiesInStage(6);

                Game.player.stageItemsAvailable.Clear();
                Item.AddAllItemsInStage(6);
                Item.AddAllItemsInStage(7);
            }
        }
    }

}
