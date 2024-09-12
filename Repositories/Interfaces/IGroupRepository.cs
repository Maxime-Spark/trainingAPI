using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Models;

namespace MyApi.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group?> GetGroupByIdAsync(int id);
        Task AddGroupAsync(Group group);
        Task<bool> UpdateGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(int id);
    }
}
