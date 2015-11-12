namespace Implementation
{
    public class Submarine : Ship
    {
        private int coorX;
        private int coorY;
        private int _size ;
        private Direction _direction;
        
        public Submarine(int x, int y, int size, Direction direction) : base(x, y, size, direction)
        {
            coorX = x;
            coorY = y;
            _size = size;
            _direction = direction;
        }
    }
}