using System.Collections.Generic;
using System.Linq;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        private readonly List<double> edges; 

        public RightTriangle(double edge1, double edge2, double edge3)
        {
            
            edges = new List<double> { edge1, edge2, edge3};
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            edges = new List<double> { (double)parameters[ParamKeys.Edge1],
                (double)parameters[ParamKeys.Edge2],
                (double)parameters[ParamKeys.Edge3] }; 
        }

        protected override double Area()
        {
            var sortedEdges = edges.OrderByDescending(a => a).ToList();
            return sortedEdges[1] * sortedEdges[2] / 2;
        }

        public override double GetPerimeter()
        {
            if (Multiplier != 0)
            {
                return edges.Sum()*Multiplier;
            }
            return edges.Sum();
        }

        public override string ShapeName { get; } = "RightTriangle";

    }
}