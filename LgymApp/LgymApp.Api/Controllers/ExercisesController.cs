using LgymApp.Api.Data;
using LgymApp.Domain.Entities;
using LgymApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LgymApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ExercisesController>
        [HttpGet]
        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _context.Set<Exercise>().ToListAsync();
        }

        // GET api/<ExercisesController>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return _context.Set<Exercise>().Find(id)!.Name;
        }

        // POST api/<ExercisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _context.Add(new Exercise(value, BodyPartsEnum.Chest, "desc"));
            _context.SaveChanges();
        }

        // PUT api/<ExercisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExercisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
