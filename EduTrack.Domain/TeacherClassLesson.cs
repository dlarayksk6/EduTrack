using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Domain;  


public class TeacherClassLesson
{
    public int TeacherId { get; set; }
    public int ClassRoomId { get; set; }
    public int LessonId { get; set; }

    public User? Teacher { get; set; }
    public ClassRoom? Class { get; set; }
    public Lesson? Lesson { get; set; }
}
