namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data.Students.All().Select(StudentModel.FromStudent);
                                
            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data.Students
                                .All()
                                .Where(h => h.StudentId == id)
                                .Select(StudentModel.FromStudent)
                                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Student does not exist - invalid id");
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.StudentId = newStudent.StudentId;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentToUpdate = this.data.Students.All().FirstOrDefault(s => s.StudentId == id);

            if (studentToUpdate == null)
            {
                return BadRequest("Student with this id: " + id + " does not exists.");
            }

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Level = student.Level;
            this.data.SaveChanges();

            student.StudentId = id;
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var studentToDelete = this.data.Students.All().FirstOrDefault(s => s.StudentId == id);

            if (studentToDelete == null)
            {
                return BadRequest("Student with this id: " + id + " does not exists.");
            }

            this.data.Students.Delete(studentToDelete);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddHomework(int id, int homeworkId)
        {
            var student = this.data.Students.All().FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return BadRequest("Student with this id: " + id + " does not exists.");
            }

            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.HomeworkId == homeworkId);

            if (homework == null)
            {
                return BadRequest("Homework with this id: " + id + " does not exists.");
            }

            student.Homeworks.Add(homework);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int id, Guid courseId)
        {
            var student = this.data.Students.All().FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return BadRequest("Student with this id: " + id + " does not exists.");
            }

            var course = this.data.Courses.All().FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                return BadRequest("Course with this id: " + id + " does not exists.");
            }

            student.Courses.Add(course);
            this.data.SaveChanges();

            return Ok();
        }
    }
}