using System;
using System.Numerics;
using System.Windows.Input;
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
        private static float fov;
        private static void Main(string[] args)
        {
            resolution = new Vector2(20, 20);
            screen = new char[Convert.ToInt32(resolution.X), Convert.ToInt32(resolution.Y)];
            camPos = new Vector3(0, 0, 0);
            lookAngles = new Vector2(0, 0);

            RenderLoop();
        }
        private static void LookLoop()
        {
            while (true)
            {
                
            }
        }
        private static void RenderLoop()
        {
            
            while (true)
            {
                Console.Clear();
                string renderStr = "";
                for(int y = 0; y < resolution.Y; y++)
                {
                    for(int x = 0; x < resolution.X; x++)
                    {
                        char c = CastRay(camPos, lookAngles);
                        
                        renderStr += c;
                        screen[y, x] = c;
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

            /*
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
            }*/
            //cos(-a+45)x-sin(-a+45)y=sin(-a+45)x+cos(-a+45)y=sin(-2b+90)x+cos(-2b+90)z is the function for a 3d line where a and b are angles in degrees

            //float a = angles.X;
            //float b = angles.Y;
            //float x;
            //float y;
            //float z;

            //float A = MathF.Cos(degToRad(-a + 45f)) * x - MathF.Sin(degToRad(-a + 45f)) * y;
            //float B = MathF.Sin(degToRad(-a + 45f)) * x + MathF.Cos(degToRad(-a + 45f)) * y;
            //float C = MathF.Sin(degToRad(-2 * b + 90f)) * x + MathF.Cos(degToRad(-2 * b + 90f)) * z;

            List<Vector3> testPoints = new List<Vector3>
            {
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 1),
                new Vector3(0, 0, 2),
                new Vector3(1, 0, 0),
                new Vector3(1, 0, 1),
                new Vector3(1, 0, 2),
                new Vector3(2, 0, 0),
                new Vector3(2, 0, 1),
                new Vector3(2, 0, 2)
            };

            for(int i = 0; i < lookDistance; i++)
            {
                Vector3 linePoint = GetZPoint(angles, i, point);

                foreach(Shape shape in worldShapes)
                {
                    foreach(Vector3 shapePoint in testPoints)
                    {
                        float distance = Vector3.Distance(linePoint, shapePoint);
                        if(distance > 1)
                        {
                            continue;
                        }

                        return '%';
                    }
                }
            }
            return ' ';
            
        }
        //private static List<Vector3> GetShapePoints(Shape shape)
        //{
        //}
        private static float DegToRad(float angle)
        {
            return (MathF.PI * angle) / 90f;
        }
        private static Vector3 GetZPoint(Vector2 angles, float dist, Vector3 point)
        {
            float theta = DegToRad(angles.X);

            float x = dist * MathF.Cos(theta) + point.X;
            float y = dist * MathF.Sin(theta) + point.Y;

            float a = DegToRad(-angles.X + 45f);
            float b = DegToRad(-2 * angles.Y + 90f);

            float z =  ((MathF.Sin(a) * x) + (MathF.Cos(a) * y) - (MathF.Sin(b) * x)) / (MathF.Cos(b));

            return new Vector3(x, y, z);
        }
    }
}