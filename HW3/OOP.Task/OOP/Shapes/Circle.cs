using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        double _radius;

	    public Circle(double radius)
        {
            _radius = radius;
        }

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];
		}

        public override string ShapeName { get; } = "Circle";

	    public override double GetPerimeter()
        {
            if (Multiplier != 0) { 
            return Multiplier* 2 * Math.PI * _radius;
            }
            return 2 * Math.PI * _radius;
        }

        protected override double Area()
        {
            if (Multiplier != 0)
            {
                return Math.Pow(Multiplier,2) * Math.PI * Math.Pow(_radius, 2); 
            }
            return Math.PI * Math.Pow(_radius, 2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

    }
}