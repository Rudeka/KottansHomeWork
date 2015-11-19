namespace Implementation
{
    public class AircraftCarrier : Ship
    {
        private int coorX;
        private int coorY;
        private int _size;
        private Direction _direction;

        public AircraftCarrier(int x, int y, int size = 4) : base (x, y)
        {
            coorX = x;
            coorY = y;
            _size = size;
        }

        public AircraftCarrier(int x, int y, int size, Direction direction) : base(x, y, size, direction)
        {
            coorX = x;
            coorY = y;
            _size = size;
            _direction = direction;
        }
    }
}