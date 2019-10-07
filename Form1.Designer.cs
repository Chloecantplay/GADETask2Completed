namespace GADETask1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MapBox = new System.Windows.Forms.GroupBox();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.UnitInfoDisplay = new System.Windows.Forms.TextBox();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Readbutton = new System.Windows.Forms.Button();
            this.Resourceslabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MapBox
            // 
            this.MapBox.Location = new System.Drawing.Point(13, 13);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(726, 610);
            this.MapBox.TabIndex = 0;
            this.MapBox.TabStop = false;
            this.MapBox.Enter += new System.EventHandler(this.MapBox_Enter);
            // 
            // RoundLabel
            // 
            this.RoundLabel.AutoSize = true;
            this.RoundLabel.Location = new System.Drawing.Point(745, 179);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Size = new System.Drawing.Size(54, 17);
            this.RoundLabel.TabIndex = 1;
            this.RoundLabel.Text = "Round:";
            this.RoundLabel.Click += new System.EventHandler(this.RoundLabel_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(916, 26);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(116, 50);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Location = new System.Drawing.Point(916, 107);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(116, 50);
            this.PauseBtn.TabIndex = 3;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // UnitInfoDisplay
            // 
            this.UnitInfoDisplay.Location = new System.Drawing.Point(748, 214);
            this.UnitInfoDisplay.Multiline = true;
            this.UnitInfoDisplay.Name = "UnitInfoDisplay";
            this.UnitInfoDisplay.Size = new System.Drawing.Size(274, 409);
            this.UnitInfoDisplay.TabIndex = 5;
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(758, 26);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(121, 50);
            this.Savebutton.TabIndex = 6;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // Readbutton
            // 
            this.Readbutton.Location = new System.Drawing.Point(758, 108);
            this.Readbutton.Name = "Readbutton";
            this.Readbutton.Size = new System.Drawing.Size(121, 49);
            this.Readbutton.TabIndex = 7;
            this.Readbutton.Text = "Read";
            this.Readbutton.UseVisualStyleBackColor = true;
            this.Readbutton.Click += new System.EventHandler(this.Readbutton_Click);
            // 
            // Resourceslabel
            // 
            this.Resourceslabel.AutoSize = true;
            this.Resourceslabel.Location = new System.Drawing.Point(895, 179);
            this.Resourceslabel.Name = "Resourceslabel";
            this.Resourceslabel.Size = new System.Drawing.Size(84, 17);
            this.Resourceslabel.TabIndex = 8;
            this.Resourceslabel.Text = "Resources: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 672);
            this.Controls.Add(this.Resourceslabel);
            this.Controls.Add(this.Readbutton);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.UnitInfoDisplay);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.MapBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox UnitInfoDisplay;
        private System.Windows.Forms.GroupBox MapBox;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Readbutton;
        private System.Windows.Forms.Label Resourceslabel;
    }
}

