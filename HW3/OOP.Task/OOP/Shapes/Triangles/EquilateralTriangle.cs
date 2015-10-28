using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        private readonly double _edge1;

        public EquilateralTriangle (double edge1)
        {
            _edge1 = edge1;
        }
        
        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
        }

        public override double GetPerimeter()
        {
            if (Multiplier != 0)
            {
                return Multiplier * _edge1 * 3;
            }
            return _edge1 *3;
        }

        public override string ShapeName { get; } = "EquilateralTriangle";
    }
}