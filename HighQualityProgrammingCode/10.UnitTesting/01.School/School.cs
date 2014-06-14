namespace _01.School
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class School
    {
        public School(IList<Course> courses = null)
        {
            this.Courses = new List<Course>();

            if (courses != null)
            {
                foreach (var course in courses)
                {
                    this.Courses.Add(course);
                }
            }
        }

        public List<Course> Courses { get; private set; }

        public void AddCourse(Course course)
        {
            if (this.IsCourseExist(course))
            {
                throw new ArgumentException("The course has already been added.");
            }
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (!this.IsCourseExist(course))
            {
                throw new ArgumentException("This course hasn't been added.");
            }

            int courseIndex = 0;
            foreach (var curCourse in this.Courses)
            {
                if (curCourse.Name == course.Name)
                {
                    this.Courses.RemoveAt(courseIndex);
                    break;
                }
                courseIndex++;
            }
        }

        private bool IsCourseExist(Course course)
        {
            return this.Courses.Count(x => x.Name == course.Name) > 0;
        }
    }
}
