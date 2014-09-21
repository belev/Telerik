namespace BugLogger.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using BugLogger.Services.Models;

    public class BugsController : ApiController
    {
        private IGenericRepository<Bug> bugsRepository;

        public BugsController()
            : this(new GenericRepository<Bug>(new BugLoggerDbContext()))
        {
        }

        public BugsController(IGenericRepository<Bug> bugsRepository)
        {
            this.bugsRepository = bugsRepository;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var bugs = this.bugsRepository
                           .All()
                           .Select(BugModel.FromBug);

            return Ok(bugs);
        }

        [HttpPost]
        public IHttpActionResult Create(BugModel bug)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (string.IsNullOrEmpty(bug.Text))
            {
                return BadRequest("Bug should have text");
            }

            if (bug.LogDate == null)
            {
                bug.LogDate = DateTime.Now;
            }

            bug.Status = BugStatus.Pending;

            var newBug = new Bug()
            {
                Text = bug.Text,
                Status = bug.Status,
                LogDate = bug.LogDate
            };

            this.bugsRepository.Add(newBug);
            this.bugsRepository.SaveChanges();

            bug.BugId = newBug.BugId;
            return Ok(bug);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, BugModel bug)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var existingBug = this.bugsRepository.All().FirstOrDefault(b => b.BugId == id);

            if (existingBug == null)
            {
                return BadRequest("Such bug does not exists.");
            }

            existingBug.Status = bug.Status;
            this.bugsRepository.SaveChanges();

            bug.BugId = existingBug.BugId;
            bug.Text = existingBug.Text;
            bug.LogDate = existingBug.LogDate;
            return Ok(bug);
        }

        [HttpGet]
        public IHttpActionResult AfterDate(string date)
        {
            var asDateTime = DateTime.Parse(date);

            var bugs = this.bugsRepository
                           .All()
                           .Where(b => b.LogDate > asDateTime)
                           .Select(BugModel.FromBug);

            return Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult ByStatus(string status)
        {
            status = status.ToLower();

            BugStatus bugStatus;
            switch (status)
            {
                case "pending":
                    bugStatus = BugStatus.Pending;
                    break;
                case "fixed":
                    bugStatus = BugStatus.Fixed;
                    break;
                case "fortesting":
                    bugStatus = BugStatus.ForTesting;
                    break;
                case "assigned":
                    bugStatus = BugStatus.Assigned;
                    break;
                default:
                    return Ok();
            }

            var bugs = this.bugsRepository
                                .All()
                                .Where(b => b.Status == bugStatus)
                                .Select(BugModel.FromBug);

            return Ok(bugs);
        }
    }
}