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
using System.Media;


namespace Tetris_Game
{
    public partial class PlaySceen : UserControl
    {
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush blue = new SolidBrush(Color.Blue);
        Pen pen = new Pen(Color.Black);

        SoundPlayer theme = new SoundPlayer(Properties.Resources.Tetris_theme);

        Boolean leftArrowDown, rightArrowDown, blockStop;

        List<Block> boxes = new List<Block>();
        List<Block> boxesCurrent = new List<Block>();

        Random num = new Random();
        int shape;

        Block bottom1 = new Block(0, 550, 830, 20);
        Block left1 = new Block(35, 0, 15, 977);
        Block right1 = new Block(500, 0, 15, 977);
        Block box;
        Block box2;
        Block box3;

        public PlaySceen()
        {
            InitializeComponent();

            theme.PlayLooping();

            makeBlocks();

        }

        public void makeBlocks()
        {

            shape = num.Next(0, 5);

            switch (shape)
            {
                case 1: //line h
                    box = new Block(50, 0, 50, 50);
                    box2 = new Block(100, 0, 50, 50);
                    box3 = new Block(150, 0, 50, 50);
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 2: //L shape
                    box = new Block(50, 0, 50, 50);
                    box2 = new Block(50, 50, 50, 50);
                    box3 = new Block(100, 0, 50, 50);
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 3: //T shape
                    box = new Block(50, 0, 50, 50);
                    box2 = new Block(100, 50, 50, 50);
                    box3 = new Block(100, 0, 50, 50);
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 4: //line v
                    box = new Block(50, 0, 50, 50);
                    box2 = new Block(50, 50, 50, 50);
                    box3 = new Block(50, 100, 50, 50);
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
            }
        }

        public void doneBlocks()
        {
            foreach (Block b in boxesCurrent)
            {
                b.YSpeed = 0;
                boxes.Add(b);


            }

            boxesCurrent.Clear();

            blockStop = true;

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

            foreach (Block b in boxesCurrent)
            {
                b.move();
                if (bottom1.CollisionBottom(b))
                {
                    doneBlocks();

                    break;
                }
            }

            foreach (Block b in boxesCurrent)
            {
                if (left1.CollisionLeft(b))
                {
                    leftArrowDown = false;

                }
            }

            foreach (Block b in boxesCurrent)
            {
                if (right1.CollisionRight(b))
                {
                    rightArrowDown = false;
                }
            }
            #endregion

            #region arrows

            if (leftArrowDown == true)
            {
                foreach (Block b in boxesCurrent)
                {
                    b.x -= 50;

                }
                leftArrowDown = false;
            }
            if (rightArrowDown == true)
            {
                foreach (Block b in boxesCurrent)
                {
                    b.x += 50;

                }
                rightArrowDown = false;
            }

            #endregion

            #region collision

            foreach (Block b in boxes)
            {
                if (box.Collision(b))
                {
                    doneBlocks();

                    break;

                }
            }
            foreach (Block b in boxes)
            {
                if (box2.Collision(b))
                {
                    doneBlocks();

                    break;

                }
            }
            foreach (Block b in boxes)
            {
                if (box3.Collision(b))
                {
                    doneBlocks();

                    break;

                }
            }




            foreach (Block b in boxes)
            {
                if (b.y <= 15)
                {
                    gameLoop.Stop();
                    theme.Stop();
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    GameOver go = new GameOver();
                    f.Controls.Add(go);

                    go.Focus();

                    break;

                }
            }

            if (blockStop == true)
            {
                makeBlocks();
            }

            #endregion

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(white, bottom1.x, bottom1.y, bottom1.sizeX, bottom1.sizeY);
            foreach (Block b in boxesCurrent)
            {
                e.Graphics.FillRectangle(blue, b.x, b.y, b.sizeX, b.sizeX);
                e.Graphics.DrawRectangle(pen, b.x, b.y, b.sizeX, b.sizeX);

            }
            e.Graphics.FillRectangle(white, left1.x, left1.y, left1.sizeX, left1.sizeY);
            e.Graphics.FillRectangle(white, right1.x, right1.y, right1.sizeX, right1.sizeY);
            foreach (Block b in boxes)
            {
                e.Graphics.FillRectangle(blue, b.x, b.y, b.sizeX, b.sizeX);
                e.Graphics.DrawRectangle(pen, b.x, b.y, b.sizeX, b.sizeX);

            }
        }
    }
}
