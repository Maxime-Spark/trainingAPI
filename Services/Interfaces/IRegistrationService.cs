using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<Registration?> GetRegistrationByIdsAsync(int userId, int activityId);
        Task AddRegistrationAsync(Registration registration);
        Task<bool> DeleteRegistrationAsync(int userId, int activityId);
    }
}
