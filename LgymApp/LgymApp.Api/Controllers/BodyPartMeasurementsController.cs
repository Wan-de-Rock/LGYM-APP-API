using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
using LgymApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BodyPartMeasurementsController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public BodyPartMeasurementsController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IResult> Get(Guid id)
    {
        var measurement = await _ctx.Set<BodyPartMeasurement>().FindAsync(id);
        if (measurement is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(measurement);
    }

    [HttpGet]
    public async Task<IEnumerable<BodyPartMeasurement>> GetMany(BodyPartMeasurementDto dto)
    {
        var measurementsQuery = _ctx.Set<BodyPartMeasurement>().AsNoTracking();

        if (dto.UserId.HasValue)
        {
            // TODO: check that current user is a trainer, if not - return 403 Forbidden
            //if (!User.IsInRole("Trainer"))
            //    return Results.Forbid();
            measurementsQuery = measurementsQuery.Where(m => m.User.Id == dto.UserId);
        }
        else
            // TODO: change to current user ID
            measurementsQuery = measurementsQuery.Where(m => m.User.Id == Guid.NewGuid());

        if (dto.BodyPart.HasValue)
            measurementsQuery = measurementsQuery.Where(m => m.BodyPart == dto.BodyPart);

        return await measurementsQuery
            .OrderBy(x => x.CreatedAt)
            .DistinctBy(m => m.BodyPart)
            .ToListAsync();
    }

    [HttpPost]
    public async Task Create()
    {
    }

    [HttpPut]
    public async Task Update()
    {
    }

    [HttpDelete]
    public async Task<StatusCodeResult> Delete(Guid id)
    {
        var measurementQuery = _ctx.Set<BodyPartMeasurement>()
            .Where(m => m.Id == id);

        if (!measurementQuery.Any())
            return StatusCode(404);

        // не запишется в контекст, но вернет количество обновленных строк
        await measurementQuery
            .ExecuteUpdateAsync(m => m
                .SetProperty(p => p.IsDeleted, true)
                );

        return StatusCode(204);
    }
}

public record BodyPartMeasurementDto(Guid? UserId, BodyPartsEnum? BodyPart);