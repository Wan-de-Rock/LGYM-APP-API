using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
using LgymApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LgymApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public ExercisesController(ApplicationDbContext context)
    {
        _ctx = context;
    }
    // GET: api/<ExercisesController>
    [HttpGet]
    public async Task<IEnumerable<Exercise>> Get()
    {
        return await _ctx.Set<Exercise>().ToListAsync();
    }

    // GET api/<ExercisesController>/5
    [HttpGet("{id}")]
    public string Get(Guid id)
    {
        return _ctx.Set<Exercise>().Find(id)!.Name;
    }

    // POST api/<ExercisesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        _ctx.Add(new Exercise(value, BodyPartsEnum.Chest, "desc"));
        _ctx.SaveChanges();
    }

    // PUT api/<ExercisesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ExercisesController>/5
    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        (await _ctx.Set<Exercise>().FindAsync()).SetDeleted();
    }
}
