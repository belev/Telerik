using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Discipline : Comment
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;

        public Discipline(string name, int lecturesCount, int exercisesCount)
        {
            this.Name = name;
            this.LecturesCount = lecturesCount;
            this.ExercisesCount = exercisesCount;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("That's not a discipline name! Invalid name input!");
                }

                this.name = value;
            }
        }
        public int LecturesCount 
        {
            get { return this.lecturesCount; }
            set
            {
                if (value > 0)
                {
                    this.lecturesCount = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for number of lectures!");
                }
            }
        }
        public int ExercisesCount
        {
            get { return this.exercisesCount; }
            set
            {
                if (value > 0)
                {
                    this.exercisesCount = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for number of exercises!");
                }
            }
        }
    }
}
