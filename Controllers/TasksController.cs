using Microsoft.AspNetCore.Mvc;
using TrailNetApiChallenge.Context;
using TrailNetApiChallenge.Models;

namespace TrailNetApiChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly OrganizerContext _context;

        public TasksController(OrganizerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var taskBank = _context.Tasks.Find(id);
            if (taskBank == null)
                return NotFound();
            return Ok(taskBank);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var taskBank = _context.Tasks.ToList();
            return Ok(taskBank);
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string Title)
        {
            var taskBank = _context.Tasks.Where(x => x.Title == Title);
            return Ok(taskBank);
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var taskBank = _context.Tasks.Where(x => x.Date.Date == date.Date);
            return Ok(taskBank);
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(EnumStatusTasks status)
        {
            var taskBank = _context.Tasks.Where(x => x.Status == status);
            return Ok(taskBank);
        }

        [HttpPost]
        public IActionResult Create(Tasks tasks)
        {
            if (tasks.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "The task date cannot be empty" });
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tasks.Id }, tasks);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks tasks)
        {
            var taskBank = _context.Tasks.Find(id);

            if (taskBank == null)
                return NotFound();

            if (tasks.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "The task date cannot be empty" });

            taskBank.Title = tasks.Title;
            taskBank.Description = tasks.Description;
            taskBank.Date = tasks.Date;
            taskBank.Status = tasks.Status;

            _context.Tasks.Update(taskBank);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskBank = _context.Tasks.Find(id);

            if (taskBank == null)
                return NotFound();

            _context.Tasks.Remove(taskBank);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
