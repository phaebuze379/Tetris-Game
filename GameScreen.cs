
//Project title: TETRIS
//Phaedra Buzek
//ICS 4U
//October 6, 2020

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Game
{
    public partial class GameScreen : UserControl
    {
       public static int colour;
        
        public GameScreen()
        {
            InitializeComponent();
            //don't show instructions
            label2.Visible = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //assign the number selected to a variable
            colour = Convert.ToInt16(numericUpDown1.Value);

            //go to PlayScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            PlaySceen ps = new PlaySceen();
            f.Controls.Add(ps);

            ps.Focus();
        }

        private void instructionButton_Click(object sender, EventArgs e)
        {
            //show instructions if you click the buttom
            label2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show colour options
            label3.Visible = true;
            label4.Visible = true;
            numericUpDown1.Visible = true;

        }
    }
}
