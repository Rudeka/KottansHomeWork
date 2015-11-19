using System;

namespace Implementation
{
    public class Cruiser : Ship, IEquatable<Cruiser>
    {
        private readonly int coorX;
        private readonly int coorY;
        private int _size;
        private readonly Direction _direction;

#region Equality members
        public bool Equals(Cruiser other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return coorX == other.coorX && coorY == other.coorY && _direction == other._direction;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cruiser) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = coorX;
                hashCode = (hashCode*397) ^ coorY;
                hashCode = (hashCode*397) ^ (int) _direction;
                return hashCode;
            }
        }

        public static bool operator ==(Cruiser left, Cruiser right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cruiser left, Cruiser right)
        {
            return !Equals(left, right);
        }
        #endregion

        public Cruiser(int x, int y, int size = 2)
        {
            coorX = x;
            coorY = y;
            _size = size;
        }
        public Cruiser(int x, int y, Direction direction)
        {
            coorX = x;
            coorY = y;
            _direction = direction;
        }

        public Cruiser(int x, int y, int size, Direction direction):base(x, y, size, direction)
        {
            coorX = x;
            coorY = y;
            _size = size;
            _direction = direction;
        }

    }
}