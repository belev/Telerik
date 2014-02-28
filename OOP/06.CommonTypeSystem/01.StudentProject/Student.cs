using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentProject
{
    //01.Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail,
    //course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
    //Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int course;

        public Student(string firstName, string middleName, string lastName, int course, string ssn, string address, string phoneNumber, string emailAddress, SpecialtyType specialty, UniversityType university, FacultyType faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Course = course;
            this.SSN = ssn;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name can't be null, empty or whitespace!");
                }
                this.firstName = value;
            }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Middle name can't be null, empty or whitespace!");
                }
                this.middleName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name can't be null, empty or whitespace!");
                }
                this.lastName = value;
            }
        }
        public int Course
        {
            get { return this.course; }
            set
            {
                if (value <= 0 || value >= 7)
                {
                    throw new ArgumentOutOfRangeException("Course can't be negative or bigger than 7!");
                }
                this.course = value;
            }
        }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public SpecialtyType Specialty { get; set; }
        public UniversityType University { get; set; }
        public FacultyType Faculty { get; set; }

        public override bool Equals(object obj)
        {
            Student student = (Student) obj;

            bool areEqual = student != null && this.FirstName == student.FirstName && this.MiddleName == student.MiddleName
                && this.LastName == student.LastName && this.SSN == student.SSN;

            if (areEqual)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            result.AppendLine();
            result.AppendLine("Address: " + this.Address);
            result.AppendLine("Email address: " + this.EmailAddress);
            result.AppendLine("Phone number: " + this.PhoneNumber);
            result.AppendLine("University: " + this.University);
            result.AppendLine("Specialty: " + this.Specialty);
            result.AppendLine("Faculty: " + this.Faculty);
            result.AppendFormat("SSN and course: {0} {1}", this.SSN, this.Course);

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(Student.Equals(first, second));
        }

        //02.Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.Course, this.SSN, this.Address, this.PhoneNumber, this.EmailAddress, this.Specialty, this.University, this.Faculty);
        }

        //03.Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order)
        //and by social security number (as second criteria, in increasing order).

        /// <summary>
        /// Check first name with CompareTo. If they are not equal than return the value from CompareTo
        /// Else check next name and so on
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            int firstNameCompare = this.FirstName.CompareTo(other.FirstName);

            if (firstNameCompare != 0)
            {
                return firstNameCompare;
            }
            else
            {
                int middleNameCompare = this.MiddleName.CompareTo(other.MiddleName);

                if (middleNameCompare != 0)
                {
                    return middleNameCompare;
                }
                else
                {
                    int lastNameCompare = this.LastName.CompareTo(other.LastName);

                    if (lastNameCompare != 0)
                    {
                        return lastNameCompare;
                    }
                    else
                    {
                        int SSNCompare = this.SSN.CompareTo(other.SSN);

                        return SSNCompare;
                    }
                }
            }
        }
    }
}
