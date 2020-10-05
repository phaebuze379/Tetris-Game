using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Game
{
    class Block
    {
        public int x, y, sizeX, sizeY, YSpeed;

        public Block(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            sizeX = _size;

            YSpeed = 5;
        }

        public Block(int _x, int _y, int _sizeX, int _sizeY)
        {
            x = _x;
            y = _y;
            sizeX = _sizeX;
            sizeY = _sizeY;

            YSpeed = 5;
        }

        public void move()
        {
            y += YSpeed;
        }

        public Boolean CollisionBottom(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle bottom = new Rectangle(0, 545, 830, 20);

            return box.IntersectsWith(bottom);

        }

        public Boolean CollisionLeft(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle left = new Rectangle(50, 0, 15, 977);

            return box.IntersectsWith(left);

        }

        public Boolean CollisionRight(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle right = new Rectangle(495, 0, 15, 977);

            return box.IntersectsWith(right);

        }

        public Boolean Collision(Block b)
        {
            Rectangle boxRec = new Rectangle(b.x, b.y, 50, 50);
            Rectangle currentRec = new Rectangle(x, y + 5, sizeX, sizeY);

            return boxRec.IntersectsWith(currentRec);

        }

        //public Boolean CollisionSide(Block b)
        //{
        //    //Rectangle boxRec = new Rectangle(b.x, b.y, 50, 50);
        //    //Rectangle currentRec = new Rectangle(x, y + 5, sizeX, sizeY);

            

        //    // return boxRec.IntersectsWith(currentRec);

        //}


    }
}
