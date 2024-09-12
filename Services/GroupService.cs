using MyApi.Models;
using MyApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            // Logique métier éventuelle avant d'appeler le repository
            return await _groupRepository.GetAllGroupsAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            // Logique métier pour vérifier des conditions avant la récupération
            return await _groupRepository.GetGroupByIdAsync(id);
        }

        public async Task AddGroupAsync(Group group)
        {
            // Valider ou modifier le group avant l'ajout
            await _groupRepository.AddGroupAsync(group);
        }

        public async Task<bool> UpdateGroupAsync(Group group)
        {
            // Logique métier, comme vérifier si le group est modifiable
            return await _groupRepository.UpdateGroupAsync(group);
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            // Logique métier pour valider la suppression
            return await _groupRepository.DeleteGroupAsync(id);
        }
    }
}
