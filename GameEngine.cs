using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADETask1
{
    [Serializable]
    public class GameEngine
    {
        
        public Map map;
        private int round;
        private int resources;
        Random r = new Random();
        GroupBox MapBox;

        public int Round
        {
            get { return round; }
        }
       public int Resources
        {
            get { return resources; }
        }

        public GameEngine(int numUnits, GroupBox gMap)
        {
            MapBox = gMap;
            map = new Map(numUnits);
            map.Generate();
           

            round = 1; 
        }

        public void Update()
        {
            foreach (Building b in map.Buildings)
            {
                if (b is FactoryBuilding)
                {
                    FactoryBuilding f = (FactoryBuilding)b;
                    if (f.Production_Speed % round == 0)
                    {
                        map.Units.Add(f.SpawnUnit());
                    }
                }
                if (b is ResourceBuilding)
                {
                    ResourceBuilding rs = (ResourceBuilding)b;
                    rs.GenerateResources();
                }
            }
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.health <= mu.maxHealth * 0.25) // Running Away
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.EnemyDistance(map.Units);

                        //Check In Range
                        if (distanceTo <= mu.attackRange)
                        {
                            mu.isAttack = true;
                            mu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.xPos > closestMu.xPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.xPos < closestMu.xPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.yPos > closestMu.yPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.yPos < closestMu.yPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.xPos > closestRu.xPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.xPos < closestRu.xPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.yPos > closestRu.yPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.yPos < closestRu.yPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];
                    //if (ru.health <= ru.maxHealth * 0.25) // Running Away is commented out to make for a more interesting battle - and some insta-deaths
                    //{
                    //    ru.Move(r.Next(0, 4));
                    //}
                    //else
                    //{
                        (Unit closest, int distanceTo) = ru.EnemyDistance(map.Units);
                      
                        //Check In Range
                        if (distanceTo <= ru.attackRange)
                        {
                            ru.isAttack = true;
                            ru.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (ru.xPos > closestMu.xPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.xPos < closestMu.xPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.yPos > closestMu.yPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.yPos < closestMu.yPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (ru.xPos > closestRu.xPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.xPos < closestRu.xPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.yPos > closestRu.yPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.yPos < closestRu.yPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                        }

                   // }

                }
            }
            
            round++;
            
        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.xPos - end.xPos) + Math.Abs(start.yPos - end.yPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.xPos - end.xPos) + Math.Abs(start.yPos - end.yPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.xPos - end.xPos) + Math.Abs(start.yPos - end.yPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.xPos - end.xPos) + Math.Abs(start.yPos - end.yPos);
            }
            return distance;
        }
        public void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("Map.bat", FileMode.Create, FileAccess.Write, FileShare.None);

            using (fileStream)
            {
                binaryFormatter.Serialize(fileStream, map);

                MessageBox.Show("Saved");
            }
        }

        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("Map.bat", FileMode.Open, FileAccess.Read, FileShare.None);

            using (fileStream)
            {
                map = (Map)formatter.Deserialize(fileStream);

                MessageBox.Show("Game Loaded");
            }
        }

    }
}
