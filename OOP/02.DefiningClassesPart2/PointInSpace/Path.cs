using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInSpace
{
    //04.Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

    public class Path
    {
        private List<Point> path;

        public Path()
        {
            path = new List<Point>();
        }

        public Path(List<Point> path)
        {
            this.path = path;
        }

        public int Count 
        {
            get { return this.path.Count; }
        }

        public void AddPoint(Point point)
        {
            this.path.Add(point);
        }

        public void RemoveLastPoint()
        {
            this.path.RemoveAt(path.Count - 1);
        }

        public void RemoveFirstPoint()
        {
            this.path.RemoveAt(0);
        }

        public void RemovePointAt(int index)
        {
            if (index > 0 && index < this.path.Count)
            {
                this.path.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException("There is no such element to remove! Invalid index!");
            }
        }

        public Point this[int index] 
        {
            get
            {
                if (index >= 0 && index < this.path.Count)
                {
                    return this.path[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index! The index is out of range!");
                }
            }
            set
            {
                if (index >= 0 && index < this.path.Count)
                {
                    this.path[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index! The index is out of range!");
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < this.path.Count; i++)
            {
                Console.WriteLine(this.path[i].ToString());
            }
        }
    }
}
