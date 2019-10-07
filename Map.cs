using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADETask1
{
    [Serializable]
    public class Map
    {
       
        List<Building> buildings;
        List<Unit> units;
        Random random = new Random();
        int NumBuildings = 0;
        

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }
        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public Map(int n)
        {
            buildings = new List<Building>();
            units = new List<Unit>();
            NumBuildings = n;
           
        }

        public void Generate()
        {
            for(int i = 0; i < NumBuildings; i++)
            {
                if (random.Next(0, 2) == 0)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        ResourceBuilding r = new ResourceBuilding(random.Next(0, 20), random.Next(0, 20), 20, 0, "{}",random.Next(400,500));
                        Buildings.Add(r);
                    }
                    else
                    {
                        FactoryBuilding f = new FactoryBuilding(random.Next(0, 20), random.Next(0, 20), 15, 0, "[]", random.Next(0, 2), 4);
                        Buildings.Add(f);
                    }
                }
                else
                {
                    if (random.Next(0, 2) == 0)
                    {
                        ResourceBuilding r = new ResourceBuilding(random.Next(0, 20), random.Next(0, 20), 20, 1, "{}",random.Next(400,500));
                        Buildings.Add(r);
                    }
                    else
                    {
                        FactoryBuilding f = new FactoryBuilding(random.Next(0, 20), random.Next(0, 20), 15, 1, "[]", random.Next(0, 2), 4);
                        Buildings.Add(f);
                    }
                }
            }
        }

        
    }
}
