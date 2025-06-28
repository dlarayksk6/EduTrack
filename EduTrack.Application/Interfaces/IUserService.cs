using System.Collections.Generic;
using System.Threading.Tasks;
using EduTrack.Domain;

namespace EduTrack.Application.Interfaces
{
    public interface IUserService
    {
        
        Task AddUserAsync(User user);

        
        Task<User?> GetUserByTCAsync(string tc);

        /
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);

        Task<bool> HasAdminForSchoolAsync(int? schoolId);


    
        Task SaveChangesAsync();

        
    }
}
