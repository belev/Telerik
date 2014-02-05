using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class School
    {
        private List<Class> classes;

        public School(List<Class> classes)
        {
            this.Classes = classes;
        }

        public List<Class> Classes 
        {
            get
            {
                return this.classes;
            }
            private set
            {
                this.classes = value;
            }
        }
    }
}
