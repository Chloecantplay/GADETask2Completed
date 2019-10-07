using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADETask1
{
    [Serializable]

    public partial class Form1 : Form
    {
        GameEngine engine;

        public Form1()
        {
            InitializeComponent();
        }

        private void RoundLabel_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RoundLabel.Text = "Round: " + engine.Round.ToString();
            engine.Update();
            Display();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Timer.Enabled = true;
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, MapBox);
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            engine.Save();
        }

        private void Readbutton_Click(object sender, EventArgs e)
        {
            engine.Load();
            engine.Update();
            Display();
        }
        public void Display()
        {
            Form1 form = new Form1();
            MapBox.Controls.Clear();
            foreach (Unit u in engine.map.Units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.xPos * 20, mu.yPos * 20);
                    b.Text = mu.symbol;
                    if (mu.team == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                else
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.xPos * 20, ru.yPos * 20);
                    b.Text = ru.symbol;
                    if (ru.team == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                b.Click += Unit_Click;
                MapBox.Controls.Add(b);
            }
            foreach (Building b in engine.map.Buildings)
            {
                Button bn = new Button();
                if (b is ResourceBuilding)
                {
                    ResourceBuilding r = (ResourceBuilding)b;

                    bn.Size = new Size(20, 20);
                    bn.Location = new Point(r.xPos * 20, r.yPos * 20);
                    bn.Text = r.symbol;

                    if (r.team == 0)
                    {
                        bn.ForeColor = Color.Red;
                    }
                    else
                    {
                        bn.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    FactoryBuilding f = (FactoryBuilding)b;

                    bn.Size = new Size(20, 20);
                    bn.Location = new Point(f.xPos * 20, f.yPos * 20);
                    bn.Text = f.symbol;

                    if (f.team == 0)
                    {
                        bn.ForeColor = Color.Red;
                    }
                    else
                    {
                        bn.ForeColor = Color.Blue;
                    }
                }
                bn.Click += Building_Click;
                MapBox.Controls.Add(bn);
            }
        }

        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach (Unit u in engine.map.Units)
            {
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.xPos == x && ru.yPos == y)
                    {
                        UnitInfoDisplay.Text = "";
                        UnitInfoDisplay.Text = ru.Info();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.xPos == x && mu.yPos == y)
                    {
                        UnitInfoDisplay.Text = "";
                        UnitInfoDisplay.Text = mu.Info();
                    }
                }
            }


        }
        public void Building_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach (Building bl in engine.map.Buildings)
            {
                if (bl is ResourceBuilding)
                {
                    ResourceBuilding r = (ResourceBuilding)bl;
                    if (r.xPos == x && r.xPos == y)
                    {
                        UnitInfoDisplay.Text = "";
                        UnitInfoDisplay.Text = r.Info();
                    }
                }
                else if (bl is FactoryBuilding)
                {
                    FactoryBuilding f = (FactoryBuilding)bl;
                    if (f.xPos == x && f.yPos == y)
                    {
                        UnitInfoDisplay.Text = "";
                        UnitInfoDisplay.Text = f.Info();
                    }
                }
            }
        }

        private void MapBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
