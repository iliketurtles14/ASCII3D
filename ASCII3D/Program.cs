using System;
using System.Numerics;
namespace ASCII3D
{
    class Program
    {
        private static Vector2 resolution;
        private static List<Shape> worldShapes;
        private static char[,] screen;
        private static Vector3 camPos;
        private static Vector2 lookAngles;
        private static int lookDistance;
        private static void Main(string[] args)
        {
            resolution = new Vector2(20, 20);
            screen = new char[Convert.ToInt32(resolution.X), Convert.ToInt32(resolution.Y)];
            camPos = new Vector3(0, 0, 0);
            lookAngles = new Vector2(0, 0);

            RenderLoop();
        }
        private static void RenderLoop()
        {
            CastRay(camPos, lookAngles);
            
            while (true)
            {
                Console.Clear();
                string renderStr = "";
                for(int y = 0; y < resolution.Y; y++)
                {
                    for(int x = 0; x < resolution.X; x++)
                    {
                        renderStr += "o";
                        screen[y, x] = 'o';
                    }
                    renderStr += "\n";
                }

                Console.Write(renderStr);
                Thread.Sleep(16);
            }
        }
        private static char CastRay(Vector3 point, Vector2 angles)
        {
            // .:-=+*#%@

            //make a math function for the line that is cast from the point var in the direction of angles
            //if hit any shape, get the distance and compare that with the lookDistance.
            //based on the distance, return a char

            //doing first line (x angle)
            float run = MathF.Cos(angles[0]);
            float rise = MathF.Sin(angles[0]);
            float slope = rise / run;

            List<Vector3> line1Points = new List<Vector3>();

            for(int i = 0; i < lookDistance; i++)
            {
                line1Points.Add(new Vector3(i, i * slope, 0));
            }

            //doing second line (z angle)
            run = MathF.Cos(angles[1]);
            rise = MathF.Sin(angles[1]);
            slope = rise / run;

            List<Vector3> line2Points = new List<Vector3>();

            for(int i = 0; i < lookDistance; i++)
            {
                line2Points.Add(new Vector3(i, 0, i * slope));
            }

            //combine lines
            List<Vector3> linePoints = new List<Vector3>();
            for(int i = 0; i < lookDistance; i++)
            {
                linePoints.Add(new Vector3(i, line1Points[i].Y, line2Points[i].Z));
            }

            for(int i = 0; i < lookDistance; i++)
            {
                Vector3 realPoint = linePoints[i] + point;
                foreach(Shape shape in worldShapes)
                {

                }
            }
        }
        private static List<Vector3> GetShapePoints(Shape shape)
        {
            for(int i = 0; i < shape.points.Count; i++)
            {

            }
        }
    }
}