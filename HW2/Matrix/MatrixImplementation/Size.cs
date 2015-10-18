using System;

namespace MatrixImplementation
{
    public struct Size : IEquatable<Size>
    {

#region Equality members 
        public bool Equals(Size other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return width == other.width && height == other.height && IsSquare == other.IsSquare;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Size)) return false;
            return Equals((Size) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = width;
                hashCode = (hashCode*397) ^ height;
                hashCode = (hashCode*397) ^ IsSquare.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Size left, Size right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !Equals(left, right);
        }
#endregion

        private int width;
        private int height;

        private bool isSquare;
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
            isSquare = width == height;
        }

        public int Width => width;
        public int Height => height;
        public bool IsSquare => isSquare;

        //public bool IsSquare()
        //{
        //    return Width == Height;
        //}
    }
}