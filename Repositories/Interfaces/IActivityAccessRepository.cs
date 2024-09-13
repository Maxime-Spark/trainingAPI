using MyApi.Models;

namespace MyApi.Repositories
{
    public interface IActivityAccessRepository
    {
        Task<IEnumerable<ActivityAccess>> GetAllActivityAccessesAsync();
        Task<ActivityAccess?> GetActivityAccessByIdAsync(int id);
        Task AddActivityAccessAsync(ActivityAccess activityAccess);
        Task<bool> DeleteActivityAccessAsync(int id);
    }
}
