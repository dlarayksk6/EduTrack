using EduTrack.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Idare")]
    public class AdminNotesController : BaseController
    {
        private readonly EduTrackDbContext _context;

        public AdminNotesController(EduTrackDbContext context)
        {
            _context = context;
        }


        [HttpGet("admin-class-notes/{classId}")]
        public async Task<IActionResult> GetStudentsWithNotes(int classId)
        {
            var schoolId = GetUserSchoolId(); 

           
            var classExists = await _context.Classes
                .AnyAsync(c => c.Id == classId && c.SchoolId == schoolId);

            if (!classExists)
                return Forbid("Bu sınıfa erişim yetkiniz yok.");

            var students = await _context.Users
                .Where(u => u.Role == "Student"
                    && _context.ClassUsers.Any(cu => cu.UserId == u.Id && cu.ClassRoomId == classId))
                .Select(u => new
                {
                    u.Id,
                    u.Name,
                    Notes = _context.Notes
                        .Where(n => n.ClassUserUserId == u.Id && n.ClassUserClassId == classId)
                        .Select(n => new
                        {
                            n.Id,
                            n.Score,
                            LessonName = n.ClassLesson.Lesson.Name
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(students);
        }


    }
}
