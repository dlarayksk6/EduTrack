using EduTrack.Application.DTOs;
using EduTrack.Data;
using EduTrack.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Idare")]
    public class ClassLessonsController : BaseController
    {
        private readonly EduTrackDbContext _context;

        public ClassLessonsController(EduTrackDbContext context)
        {
            _context = context;
        }


        [HttpGet("lessons")]
        public async Task<IActionResult> GetLessons()
        {
            var lessons = await _context.Lessons
                .Select(l => new { l.Id, l.Name })
                .ToListAsync();
            return Ok(lessons);
        }


        [HttpPost]
        public async Task<IActionResult> AssignLessonToClass([FromBody] ClassLessonCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schoolId = GetUserSchoolId(); 

            
            var classRoom = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == dto.ClassRoomId && c.SchoolId == schoolId);

            if (classRoom == null)
                return BadRequest("Sınıf bulunamadı veya yetkiniz olmayan bir sınıf.");

           
            var lesson = await _context.Lessons.FindAsync(dto.LessonId);
            if (lesson == null)
                return BadRequest("Ders bulunamadı.");


            var teacher = await _context.Users
                .FirstOrDefaultAsync(t => t.Id == dto.TeacherId && t.Role == "Teacher" && t.SchoolId == schoolId);

            if (teacher == null)
                return BadRequest("Öğretmen bulunamadı veya bu okula ait değil.");

         
            var exists = await _context.ClassLessons
                .AnyAsync(cl => cl.ClassRoomId == dto.ClassRoomId && cl.LessonId == dto.LessonId);

            if (exists)
                return Conflict("Bu ders zaten bu sınıfa atanmış.");

           
            var newClassLesson = new ClassLesson
            {
                ClassRoomId = dto.ClassRoomId,
                LessonId = dto.LessonId,
                TeacherId = dto.TeacherId
            };

            _context.ClassLessons.Add(newClassLesson);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Ders ve öğretmen başarıyla sınıfa atandı." });
        }

    }
}
