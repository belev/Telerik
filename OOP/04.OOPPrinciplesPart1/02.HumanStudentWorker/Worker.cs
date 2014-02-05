using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, uint weekSalary, uint worksHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorksHoursPerDay = worksHoursPerDay;
        }

        public uint WeekSalary { get; set; }
        public uint WorksHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            uint worksHoursPerWeek = (5 * this.WorksHoursPerDay);

            decimal moneyPerHour = this.WeekSalary / worksHoursPerWeek;

            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
