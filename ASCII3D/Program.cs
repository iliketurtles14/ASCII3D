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
        private static int fov;
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


        }
    }
}