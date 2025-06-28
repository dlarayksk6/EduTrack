using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduTrack.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected int GetUserSchoolId()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "SchoolId");
            return claim != null ? int.Parse(claim.Value) : 0;
        }
    }
}
