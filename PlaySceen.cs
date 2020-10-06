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
        #region global variables
        //colour brushes
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush blue = new SolidBrush(Color.Blue);
        SolidBrush lightBlue = new SolidBrush(Color.SkyBlue);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush green = new SolidBrush(Color.SpringGreen);
        SolidBrush yellow = new SolidBrush(Color.Yellow);
        Pen pen = new Pen(Color.Black);

        //music
        SoundPlayer theme = new SoundPlayer(Properties.Resources.Tetris_theme);

        //booleans
        Boolean leftArrowDown, rightArrowDown, blockStop, reset;

        //creating lists for moving blocks and blocks that are stopped
        List<Block> boxes = new List<Block>(); //stopped blocks
        List<Block> boxesCurrent = new List<Block>(); //moving blocks
       


        //creating random number for different shapes
        Random num = new Random();
        int shape;

        //making the sides of arena
        Block bottom1 = new Block(35, 600, 480, 20);
        Block left1 = new Block(35, 0, 15, 600);
        Block right1 = new Block(500, 0, 15, 600);
        //blocks for falling shapes
        Block box;
        Block box2;
        Block box3;

        #endregion

        public PlaySceen()
        {
            InitializeComponent();

            //play the song on a loop
            theme.PlayLooping();

            //start by making a shape, go to makeBlocks()
            makeBlocks();

        }

        public void makeBlocks()
        {
            //pick a number to decide what shape (between 1 and 4)
            shape = num.Next(0, 5);

            switch (shape)
            {
                case 1: // create a line horizontal
                    box = new Block(250, 0, 50, 50);
                    box2 = new Block(300, 0, 50, 50);
                    box3 = new Block(350, 0, 50, 50);
                    //add the boxes to list
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 2: //crate an L shape
                    box = new Block(250, 0, 50, 50);
                    box2 = new Block(250, 50, 50, 50);
                    box3 = new Block(300, 0, 50, 50);
                    //add the boxes to list
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 3: //create an L shape the other way
                    box = new Block(250, 0, 50, 50);
                    box2 = new Block(300, 50, 50, 50);
                    box3 = new Block(300, 0, 50, 50);
                    //add the boxes to list
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
                case 4: //create a line vertical
                    box = new Block(250, 0, 50, 50);
                    box2 = new Block(250, 50, 50, 50);
                    box3 = new Block(250, 100, 50, 50);
                    //add the boxes to list
                    boxesCurrent.Add(box);
                    boxesCurrent.Add(box2);
                    boxesCurrent.Add(box3);
                    blockStop = false;
                    break;
            }
        }

        public void doneBlocks()
        {
            //for each block falling
            foreach (Block b in boxesCurrent)
            {
                //make the speed zero
                b.YSpeed = 0;
                //add to stopped list
                boxes.Add(b);
            }
            //clear the moving blocks list
            boxesCurrent.Clear();

            blockStop = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player presses keys
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
            //player releases keys
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

            //move each block that is in the moving list
            foreach (Block b in boxesCurrent)
            {
                b.move();

            }

            //if the shape comes in contact with the bottom
            foreach (Block b in boxesCurrent)
            {
                if (bottom1.CollisionBottom(b))
                {
                    //go to doneBlocks()
                    doneBlocks();
                    break;
                }
            }

            //if shape comes in contact with the sides, don't let it go farther
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

            //when left arrow is pressed 
            if (leftArrowDown == true)
            {
                foreach (Block b in boxesCurrent)
                {
                    //move each block in the moving block list
                    b.x -= 50;

                }
                reset = false;

                //if moving blocks come in contact with the stopped blocks on the side
                foreach (Block b in boxesCurrent)
                {
                    foreach (Block c in boxes)
                    {
                        if (b.Collision(c))
                        {
                            reset = true;
                            break;
                        }
                    }
                }
                if (reset)
                {
                    foreach (Block b in boxesCurrent)
                    {
                        //change the direction
                        b.x += 50;
                    }

                }
                leftArrowDown = false;
            }

            //when right arrow is pressed
            if (rightArrowDown == true)
            {
                foreach (Block b in boxesCurrent)
                {
                    b.x += 50;

                }
                reset = false;

                foreach (Block b in boxesCurrent)
                {
                    foreach (Block c in boxes)
                    {
                        if (b.Collision(c))
                        {
                            reset = true;
                            break;
                        }
                    }
                }
                if (reset)
                {
                    foreach (Block b in boxesCurrent)
                    {
                        b.x -= 50;
                    }

                }
                rightArrowDown = false;
            }


            #endregion

            #region collision
            reset = false;

            //if blocks come into contact with stopped blocks
            foreach (Block b in boxesCurrent)
            {
                foreach (Block c in boxes)
                {
                    if (b.Collision(c))
                    {
                        //boolean for lack of errors
                        reset = true;
                        break;

                    }
                }
            }

            if (reset)
            {
                //go to done blocks
                doneBlocks();
            }


            foreach (Block c in boxes)
            {
                //if blocks reach the top
                if (c.y <= 15)
                {
                    //game over, go to GameOver screen
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

            //if blocks are stopped
            if (blockStop == true)
            {
                //go to makeBlocks()
                makeBlocks();
            }

            #endregion

            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw lines on sides and bottom
            e.Graphics.FillRectangle(white, bottom1.x, bottom1.y, bottom1.sizeX, bottom1.sizeY);
            e.Graphics.FillRectangle(white, left1.x, left1.y, left1.sizeX, left1.sizeY);
            e.Graphics.FillRectangle(white, right1.x, right1.y, right1.sizeX, right1.sizeY);

            //falling boxes
            foreach (Block b in boxesCurrent)
            {
                //fill colour depending on input
                switch (GameScreen.colour)
                {
                    case 0:
                        e.Graphics.FillRectangle(lightBlue, b.x, b.y, b.sizeX, b.sizeX);
                        break;
                    case 1:
                        e.Graphics.FillRectangle(green, b.x, b.y, b.sizeX, b.sizeX);
                        break;
                    case 2:
                        e.Graphics.FillRectangle(yellow, b.x, b.y, b.sizeX, b.sizeX);
                        break;
                    case 3:
                        e.Graphics.FillRectangle(red, b.x, b.y, b.sizeX, b.sizeX);
                        break;
                }

                //outline
                e.Graphics.DrawRectangle(pen, b.x, b.y, b.sizeX, b.sizeX);

            }

            //stopped boxes
            foreach (Block b in boxes)
            {
                //fill colour
                e.Graphics.FillRectangle(blue, b.x, b.y, b.sizeX, b.sizeX);
                //outline
                e.Graphics.DrawRectangle(pen, b.x, b.y, b.sizeX, b.sizeX);

            }
        }
    }
}