using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADETask1
{
    [Serializable]
    public class FactoryBuilding : Building
    {
       
        public bool IsDead { get; set; }
        private int unit_type;
        public int Unit_type
        {
            get { return unit_type; }
            set { unit_type = value; }
        }

        private int production_speed;

        public int Production_Speed
        {
            get { return production_speed; }
            set { production_speed = value; }
        }
        private int spawnPoint;

        public int SpawnPoint
        {
            get { return spawnPoint; }
            set { spawnPoint = value; }
        }

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


        public FactoryBuilding(int x, int y, int hp, int team, string symbol,int unittype,int speed)
        {
            xPos = x;
            yPos = y;
            base.maxHp = hp;
            base.Team = team;
            base.symbol = symbol;
            Production_Speed = speed;
            Unit_type = unittype;
        }
        public override void Destroyed()//This method allows for buildings to be destroyed
        {
            symbol = "X";
            IsDead = true;
        }

        public override string Info()
        {
            string temp = "";
            temp += "Factory Building";
            if (Unit_type == 0) //this will show which unit the building produces
            {
                temp += "Producing Melee Units";
            }
            else
            {
                temp += "Producing Ranged Units";
            }
            temp += "{" + base.symbol + "}";
            temp += "(" + xpos + "," + ypos + ")";
            temp += (IsDead ? " This building is destroyed" : " This building is fully operational");
            return temp;
        }
        public Unit SpawnUnit()// this method allows the building to produce melee and ranged units on either team
        {
            if (Team == 0)
            {
                Unit unit;
                if(Unit_type == 0)
                {
                    MeleeUnit m = new MeleeUnit(xpos, ypos+1, 100, 1, 2,0, "M");
                    unit = m;
                }
                else
                {
                    RangedUnit ru = new RangedUnit(xpos, ypos, 100, 1, 20, 5,0,  "R");
                    unit=ru;
                }
                return unit;
            }
            else
            {
                Unit unit;
                if (Unit_type == 0)
                {
                    MeleeUnit m = new MeleeUnit(xpos, ypos + 1, 100, 1, 2, 1, "M");
                    unit = m;
                }
                else
                {
                    RangedUnit ru = new RangedUnit(xpos, ypos, 100, 1, 20, 5, 1, "R");
                    unit = ru;
                }
                return unit;
            }
        }
        
    }
}
