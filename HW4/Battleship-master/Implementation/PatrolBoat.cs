using System;

namespace Implementation
{
    public class PatrolBoat : Ship, IEquatable<PatrolBoat>
    {
        private int coorX ;
        private int coorY;
        private int _size;
        private Direction _direction;

#region Equality Members
        public bool Equals(PatrolBoat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return coorX == other.coorX && coorY == other.coorY;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PatrolBoat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (coorX*397) ^ coorY;
            }
        }

        public static bool operator ==(PatrolBoat left, PatrolBoat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PatrolBoat left, PatrolBoat right)
        {
            return !Equals(left, right);
        }
        #endregion

        public PatrolBoat(int x, int y)
        {
            coorX = x;
            coorY = y;
        }
        public PatrolBoat(int x, int y, Direction direction)
        {
            coorX = x;
            coorY = y;
            _direction = direction;
        }

        public PatrolBoat(int x, int y, int size, Direction direction):base(x, y, size, direction)
        {
            coorX = x;
            coorY = y;
            _size = size; 
            _direction = direction;
        }
    }
}