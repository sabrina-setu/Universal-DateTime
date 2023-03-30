using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using UnivarsalTime.DbContexts;
using UnivarsalTime.Entities;

namespace UnivarsalTime.Controller;

[Route("api/[controller]")]
[ApiController]
public class TimesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public TimesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync(Informations information)
    {
        _context.Informations.Add(information);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var informations = await _context.Informations.ToListAsync();
        return Ok(informations);
    }

    [HttpGet("{id}")]
    public async Task<Informations?> GetByIdAsync(int id)
    {
        return await _context.Informations.FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(int id, Informations informations)
    {
        var c = await _context.Informations.FirstOrDefaultAsync(x => x.Id == id);
        c.Name = informations.Name;
        _context.Informations.Update(c);
        var rows = await _context.SaveChangesAsync();
        if (rows <= 0) throw new Exception("Could not update..");
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(int id)
    {
        var c = await _context.Informations.FirstOrDefaultAsync(x => x.Id == id);
        _context.Entry<Informations>(c).State = EntityState.Deleted;
        var rows = await _context.SaveChangesAsync();
        if (rows <= 0) throw new Exception("Could not delete..");
    }
}
