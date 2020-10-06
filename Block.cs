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
        //declaring variables
        public int x, y, sizeX, sizeY, YSpeed;

        //making blocks, take input and store
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

        //move function
        public void move()
        {
            y += YSpeed;
        }

        // collision functions
        public Boolean CollisionBottom(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle bottom = new Rectangle(35, 595, 485, 20);
            //return collision is true
            return box.IntersectsWith(bottom);

        }

        public Boolean CollisionLeft(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle left = new Rectangle(50, 0, 15, 977);
            //return collision is true
            return box.IntersectsWith(left);

        }

        public Boolean CollisionRight(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, 50, 50);
            Rectangle right = new Rectangle(485, 0, 15, 977);
            //return collision is true
            return box.IntersectsWith(right);

        }

        public Boolean Collision(Block b)
        {
            Rectangle boxRec = new Rectangle(b.x, b.y, 50, 50);
            Rectangle currentRec = new Rectangle(x, y + 5, sizeX, sizeY);
            //return collision is true
            return boxRec.IntersectsWith(currentRec);

        }

    }
}
