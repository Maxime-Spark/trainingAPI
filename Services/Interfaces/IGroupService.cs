using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group?> GetGroupByIdAsync(int id);
        Task AddGroupAsync(Group group);
        Task<bool> UpdateGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(int id);
    }
}
