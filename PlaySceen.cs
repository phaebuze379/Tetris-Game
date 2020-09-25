using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tetris_Game
{
    public partial class PlaySceen : UserControl
    {



        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush blue = new SolidBrush(Color.Blue);
        Pen pen = new Pen(Color.White);

       
        Rectangle left;
        Rectangle right;

        Boolean leftArrowDown, rightArrowDown;

        List<Block> boxes = new List<Block>();

        Random num = new Random();
        int place;

        Block bottom1 = new Block(0, 550, 830, 20);
        Block box;

        public PlaySceen()
        {
            InitializeComponent();
            makeLines();
            makeBlocks();

        }



        public void makeLines()
        {


            left.X = 20;
            left.Y = 0;
            left.Width = 15;
            left.Height = this.Height;

            right.X = this.Width - 15 - 20;
            right.Y = 0;
            right.Width = 15;
            right.Height = this.Height;
        }

        public void makeBlocks()
        {
            place = num.Next(35, this.Width - 35 - 35);
            box = new Block(place, 0, 35);
            boxes.Add(box);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;

            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;

            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {

            
            #region move

            foreach (Block b in boxes)
            {
                b.move(5);
                if (bottom1.Collision(b))
                {

                    b.move(-5);
                    //makeBlocks();
                }

            }
            

            //makeBlocks();

            #endregion

            #region arrows

            if (leftArrowDown == true)
            {
                label1.Text = "true";
                box.x -= 5;
            }
            else
            {

            }

            if (rightArrowDown == true)
            {
                box.x += 5;
            }
            else
            {

            }


            #endregion
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(white, bottom1.x, bottom1.y, bottom1.sizeX, bottom1.sizeY);
            e.Graphics.FillRectangle(white, left);
            e.Graphics.FillRectangle(white, right);
            foreach (Block b in boxes)
            {

                e.Graphics.FillRectangle(blue, b.x, b.y, b.sizeX, b.sizeX);

            }


        }


    }
}
