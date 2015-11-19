using System.Security.Cryptography;

namespace Implementation
{
    public class Submarine : Ship
    {
        private int coorX;
        private int coorY;
        private int _size;
        private Direction _direction;

        public Submarine (int x, int y, int size = 3) : base (x, y)
        {
            coorX = x;
            coorY = y;
            _size = size;
        }
        public Submarine (int x, int y, Direction direction, int size = 3) : base(x, y, direction, size)
        {
            coorX = x;
            coorY = y;
            _size = size;
            _direction = direction;
        }

        public Submarine(int x, int y, int size, Direction direction) : base(x, y, size, direction)
        {
            coorX = x;
            coorY = y;
            _size = size;
            _direction = direction;
        }
    }
}