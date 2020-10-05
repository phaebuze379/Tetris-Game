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

        
        public GameScreen()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            PlaySceen ps = new PlaySceen();
            f.Controls.Add(ps);

            ps.Focus();
        }

        private void instructionButton_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

    }
}
