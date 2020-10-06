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
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if botton is pressed, go back to PlayScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            PlaySceen ps = new PlaySceen();
            f.Controls.Add(ps);

            ps.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //go to GameScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);

            gs.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //close program
            Application.Exit();
        }
    }
}
