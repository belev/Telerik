using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInSpace
{
    //04.Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.
    public static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            StreamWriter writer = new StreamWriter(@"..\..\" + fileName);

            using (writer)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    writer.WriteLine(path[i]);
                }
            }
        }

        public static Path LoadPath(string fileName)
        {
            StreamReader reader = new StreamReader(@"..\..\" + fileName);

            Path path = new Path();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] rawPointsDimentation = line.Split(' ');

                    double xCoord = double.Parse(rawPointsDimentation[0]);
                    double yCoord = double.Parse(rawPointsDimentation[1]);
                    double zCoord = double.Parse(rawPointsDimentation[2]);

                    Point point = new Point(xCoord, yCoord, zCoord);

                    path.AddPoint(point);

                    line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        line = reader.ReadLine();
                    }
                }
            }

            return path;
        }
    }
}
