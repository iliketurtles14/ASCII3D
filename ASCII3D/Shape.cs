using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASCII3D
{
    internal class Shape
    {
        public List<Vector3> points; //these are the corners of the shape. a square would have 4 of these points. these points lie within the world.
        public Shape(List<Vector3> points)
        {
            points = this.points;
        }
    }
}
