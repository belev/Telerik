using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }
        public Teacher(string name, List<Discipline> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            private set
            {
                if (value.Count != 0)
                {
                    this.disciplines = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public void AddDiscipline(Discipline discipline)
        {
            bool isAllreadyTeached = this.disciplines.Count(x => x.Name == discipline.Name) == 0;

            if (!isAllreadyTeached)
            {
                this.disciplines.Add(discipline);
            }
        }
        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.RemoveAll(x => x.Name == discipline.Name);
        }
    }
}
