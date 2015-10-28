using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;

        public Rectangle(double edge1, double edge2)
        {
            _edge1 = edge1;
            _edge2 = edge2;
        }

        public Rectangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
        }

        public override double GetPerimeter()
        {
            if (Multiplier != 0)
            {
                return 2 * (_edge1 + _edge2) * Multiplier;
            }
            return 2* (_edge1 + _edge2);
        }

        protected override double Area()
        {
            if (Multiplier != 0)
            {
                return _edge1 * _edge2 * Multiplier;
            }
            return _edge1 * _edge2;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName { get; } = "Rectangle";
    }
}