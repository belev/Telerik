namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class HomeworkController : ApiController
    {
        private IStudentSystemData data;

        public HomeworkController()
            : this(new StudentsSystemData())
        {
        }

        public HomeworkController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data.Homeworks
                                .All()
                                .Select(HomeworkModel.FromHomework);

            return Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.data.Homeworks
                                .All()
                                .Where(h => h.HomeworkId == id)
                                .Select(HomeworkModel.FromHomework)
                                .FirstOrDefault();

            if (homework == null)
            {
                return BadRequest("Homework does not exist - invalid id");
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHomework = new Homework()
            {
                FileUrl = homework.FileUrl,
                TimeSent = homework.TimeSent,
                CourseId = homework.CourseId,
                StudentId = homework.StudentId
            };

            this.data.Homeworks.Add(newHomework);
            this.data.SaveChanges();

            homework.HomeworkId = newHomework.HomeworkId;
            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var homeworkToUpdate = this.data.Homeworks.All().FirstOrDefault(h => h.HomeworkId == id);

            if (homeworkToUpdate == null)
            {
                return BadRequest("Homework with id: " + id + " does not exists.");
            }

            homeworkToUpdate.TimeSent = homework.TimeSent;
            homeworkToUpdate.FileUrl = homework.FileUrl;
            homeworkToUpdate.StudentId = homework.StudentId;
            homeworkToUpdate.CourseId = homework.CourseId;

            this.data.SaveChanges();

            homework.HomeworkId = id;
            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var homeworkToDelete = this.data.Homeworks.All().FirstOrDefault(h => h.HomeworkId == id);

            if (homeworkToDelete == null)
            {
                return BadRequest("Homework with id: " + id + " does not exists.");
            }

            this.data.Homeworks.Delete(homeworkToDelete);
            this.data.SaveChanges();

            return Ok();
        }
    }
}