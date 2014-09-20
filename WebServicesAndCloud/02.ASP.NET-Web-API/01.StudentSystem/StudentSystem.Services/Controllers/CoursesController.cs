namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Services.Models;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data.Courses
                              .All()
                              .Select(CourseModel.FromCourse);

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult ById(Guid id)
        {
            var course = this.data.Courses.All()
                             .Where(c => c.CourseId == id)
                             .Select(CourseModel.FromCourse)
                             .FirstOrDefault();

            if (course == null)
            {
                return BadRequest("Course with id: " + id + " does not exists.");
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course()
            {
                Description = course.Description,
                Name = course.Name
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.CourseId = newCourse.CourseId;
            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(Guid id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseToUpdate = this.data.Courses.All().FirstOrDefault(c => c.CourseId == id);

            if (courseToUpdate == null)
            {
                return BadRequest("Course with id: " + id + " does not exists.");
            }

            courseToUpdate.Description = course.Description;
            courseToUpdate.Name = course.Name;

            this.data.SaveChanges();

            course.CourseId = id;
            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var courseToDelete = this.data.Courses.All().FirstOrDefault(c => c.CourseId == id);

            if (courseToDelete == null)
            {
                return BadRequest("Course with id: " + id + " does not exists.");
            }

            this.data.Courses.Delete(courseToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(Guid id, int studentId)
        {
            var course = this.data.Courses.All().FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return BadRequest("Course with id: " + id + " does not exists.");
            }

            var student = this.data.Students.All().FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                return BadRequest("Course with id: " + studentId + " does not exists.");
            }

            course.Students.Add(student);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddHomework(Guid id, int homeworkId)
        {
            var course = this.data.Courses.All().FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return BadRequest("Course with id: " + id + " does not exists.");
            }

            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.HomeworkId == homeworkId);

            if (homework == null)
            {
                return BadRequest("Homework with id: " + homeworkId + " does not exists.");
            }

            course.Homeworks.Add(homework);
            this.data.SaveChanges();

            return Ok();
        }
    }
}