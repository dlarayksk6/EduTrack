using EduTrack.API.Controllers;
using EduTrack.Application.DTOs;
using EduTrack.Data;
using EduTrack.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Idare")]
public class ClassesController :  BaseController
{
    private readonly EduTrackDbContext _context;

    public ClassesController(EduTrackDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClass([FromBody] ClassCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var schoolId = GetUserSchoolId();

        var existingClass = await _context.Classes
            .FirstOrDefaultAsync(c => c.SchoolId == schoolId && c.Grade == dto.Grade && c.Branch == dto.Branch);

        if (existingClass != null)
            return Conflict($"Bu okulda zaten {dto.Grade}-{dto.Branch} sınıfı var.");

        var newClass = new ClassRoom
        {
            Grade = dto.Grade,
            Branch = dto.Branch,
            SchoolId = schoolId
        };

        _context.Classes.Add(newClass);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Sınıf başarıyla eklendi.", classId = newClass.Id });
    }

    [HttpGet]
    public async Task<IActionResult> GetClasses()
    {
        var schoolId = GetUserSchoolId(); 

        var classes = await _context.Classes
            .Where(c => c.SchoolId == schoolId)
            .Select(c => new {
                c.Id,
                c.Grade,
                c.Branch,
                c.SchoolId
            })
            .ToListAsync();

        return Ok(classes);
    }


}
