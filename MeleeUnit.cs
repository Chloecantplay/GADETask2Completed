﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADETask1
{
    [Serializable]
    public class MeleeUnit : Unit
    {
        public bool IsDead{get;set;}

        public int xPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int yPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }
        public int health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int speed
        {
            get { return base.Speed; }
            set { base.Speed = value; }
        }
        public int attack
        {
            get { return base.Attack; }
            set { base.Attack = value; }
        }

        public int attackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
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

        public bool isAttack
        {
            get { return base.IsAttack; }
            set { base.IsAttack = value; }
        }

        public int maxHealth
        {
            get { return base.maxHealth; }
        }

         public MeleeUnit(int x, int y,int health, int speed, int attack, int team, string symbol)
        {
            xPos=x;
            yPos=y;
            base.maxHealth = health;
            Speed = speed;
            base.Attack = attack;
            attackRange=2;
            base.Team = team;
            base.symbol = symbol;
            base.health = health;
        }

        int speedCheck = 1;

        public override void Combat(Unit attacker) //This method allows the unit to take damage
        {
            
            if (attacker is MeleeUnit)
            {
                base.health = base.health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                base.health = base.health - (ru.attack - ru.attackRange);
            }

            if(base.health <= 0)
            {
                Death(); //it does the big deaded
            }
        }

        public override void Death()// replaces the symbol and sets the isdead bool to true
        {
            symbol="X";
            IsDead=true;
        }

        public override (Unit,int) EnemyDistance(List<Unit> units)// Determines the distance to the enemy
        {
           int shortest = 100;
            Unit closest = this;
                                
            foreach(Unit u in units)
            {
                if(u is MeleeUnit && u != this)
                {
                    MeleeUnit otherMu = (MeleeUnit)u;
                    int distance = Math.Abs(this.xPos - otherMu.xPos) 
                               + Math.Abs(this.yPos - otherMu.yPos);
                    if(distance  < shortest)
                    {
                        shortest = distance;
                        closest = otherMu;
                    }
                }
                else if(u is RangedUnit && u != this)
                {
                    RangedUnit otherRu = (RangedUnit)u;
                    int distance = Math.Abs(this.xPos - otherRu.xPos) 
                               + Math.Abs(this.yPos - otherRu.yPos);
                    if(distance  < shortest)
                    {
                        shortest = distance;
                        closest = otherRu;
                    }
                }
                
            }
            return (closest,shortest);
        }

        public override void Move(int dir)
        {
            switch(dir)
            {
               case 0:yPos--;break;//North
               case 1:xPos++;break;//East
               case 2:yPos++;break;//South
               case 3:xPos--;break;//West
                    default:break;
            }                      
        }

        public override bool RangeCheck(Unit other)//Checks if the enemy is in range of attack
        {
            int distance = 0;
            int oX = 0;
            int oY = 0;
            if (other is MeleeUnit)
            {
                oX = ((MeleeUnit)other).xPos;
                oY = ((MeleeUnit)other).yPos;
            }
            else if (other is RangedUnit)
            {
                oX = ((RangedUnit)other).xPos;
                oY = ((RangedUnit)other).yPos;
            }

            distance = Math.Abs(xPos - oX) + Math.Abs(yPos - oY);
            if(distance <= attackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Info()// Displays the information on the building
        {
           string temp = "";
            temp += "Warrior: ";
            temp += "{" + base.symbol + "}";
            temp += "(" + base.xPos + "," + base.yPos + ")";
            temp += base.health + ", " + Attack + ", " + base.attackRange + ", " + Speed;
            temp += (IsDead ? " This unit is dead" : " This unit is alive...somehow");
            return temp;
        }

        public int Distance(Unit u)// determines the distance to the nearset enemy
        {
            int Distance;
            int ySqr;
            int xSqr;

            if (u.GetType() == typeof(MeleeUnit))
            {
                xSqr = (int)Math.Pow(((MeleeUnit)u).xPos - xPos, 2);
                ySqr = (int)Math.Pow(((MeleeUnit)u).yPos - yPos, 2);

                Distance = (int)Math.Sqrt(xSqr + ySqr);

                return Distance;
            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                xSqr = (int)Math.Pow(((RangedUnit)u).xPos - xPos, 2);
                ySqr = (int)Math.Pow(((RangedUnit)u).yPos - yPos, 2);

                Distance = (int)Math.Sqrt(xSqr + ySqr);

                return Distance;
            }
            else
            {
                return 0;
            }
        }

       

    }
}
