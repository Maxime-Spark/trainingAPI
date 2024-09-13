using MyApi.Models;

namespace MyApi.Repositories
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<Registration?> GetRegistrationByIdsAsync(int userId, int activityId);
        Task AddRegistrationAsync(Registration registration);
        Task<bool> DeleteRegistrationAsync(int userId, int activityId);
    }
}
