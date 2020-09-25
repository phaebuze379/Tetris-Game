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
        public int x, y, sizeX, sizeY;

        public Block(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            sizeX = _size;
        }

        public Block(int _x, int _y, int _sizeX, int _sizeY)
        {
            x = _x;
            y = _y;
            sizeX = _sizeX;
            sizeY = _sizeY;
        }

        public void move(int _speed)
        {
            y += _speed;
        }

        public Boolean Collision(Block b)
        {
            Rectangle box = new Rectangle(b.x, b.y, b.sizeX, b.sizeX);
            Rectangle bottom = new Rectangle(0, 550, 830, 20);

            return box.IntersectsWith(bottom);

        }
    }
}
