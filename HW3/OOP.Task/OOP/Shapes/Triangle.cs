using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    // TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;
        private double _edge3;


        public Triangle (double edge1, double edge2, double edge3)
        {
            _edge1 = edge1;
            _edge2 = edge2;
            _edge3 = edge3;
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
        }

        protected Triangle() : this(0, 0, 0)
        {
        }

        public override double GetPerimeter()
        {
            if (Multiplier != 0)
            {
                return Multiplier*(_edge1 + _edge2 + _edge3);
            }
            return _edge1 + _edge2 + _edge3;
        }

        protected override double Area()
        {
            var halfPerimeter = GetPerimeter()/2;
           
            return Math.Sqrt(halfPerimeter*(halfPerimeter-_edge1)*(halfPerimeter-_edge2)* 
                (halfPerimeter-_edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName { get; } = "Triangle";
    }
}