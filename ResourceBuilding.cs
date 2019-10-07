using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADETask1
{
    [Serializable]
    public class ResourceBuilding : Building
    {
       
        string ResourceType;
        private int resources_Generated = 0;
        int Resources_PerRound=10;
        int Resources_Remaining;

        Random rand = new Random();

        public bool IsDead { get; set; }

        public int xPos
        {
            get { return base.xpos; }
            set { base.xpos = value; }
        }
        public int yPos
        {
            get { return base.ypos; }
            set { base.ypos = value; }
        }

        public int team
        {
            get { return base.Team; }
            set { base.Team = value; }
        }

        public string symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        public int maxHealth
        {
            get { return base.maxHp; }
        }
        public int Hp
        {
            get { return base.hp; }
            set { base.hp = value; }
        }
        public ResourceBuilding(int x, int y,int hp, int team, string symbol,int resources)
        {
            xPos = x;
            yPos = y;
            base.maxHp = hp;
            base.Team = team;
            base.symbol = symbol;
            Resources_Remaining = resources;
        }

        public override void Destroyed()
        {
            symbol = "X";
            IsDead = true;
        }

        public override string Info()
        {
            string temp = "";
            temp += "Resource building";
            temp += "{" + base.symbol + "}";
            temp += "(" + xpos + "," + ypos + ")";
            temp += "Generated Resources: " + resources_Generated;
            temp += (IsDead ? " This building is destroyed\n" : " This building is fully operational\n");
            temp += "Remaining Resources: " + Resources_Remaining;
            return temp;
        }

        public int GenerateResources()
        {
            int Temp = resources_Generated;
            if (!IsDead)
            {     
                if (Resources_Remaining >= Resources_PerRound)
                {
                    resources_Generated += Resources_PerRound;
                    Resources_Remaining -= Resources_PerRound;
                }
                else if (Resources_Remaining > 0)
                {
                    resources_Generated += Resources_Remaining;
                    Resources_Remaining = 0;
                }
            }
            Temp = resources_Generated - Temp; // shows the resources
            return Temp;
        }
    }
}

