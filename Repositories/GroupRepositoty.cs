using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Récupérer tous les groups
        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups
                .Include(g => g.Users)
                .ToListAsync();
        }

        // Récupérer un groups par ID
        public async Task<Group?> GetGroupByIdAsync(int id)
        {
            return await _context.Groups
                .Include(g => g.Users)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        // Ajouter un nouveau groups
        public async Task AddGroupAsync(Group Group)
        {
            await _context.Groups.AddAsync(Group);
            await _context.SaveChangesAsync();
        }

        // Mettre à jour un groups existant
        public async Task<bool> UpdateGroupAsync(Group Group)
        {
            var existingGroup = await _context.Groups.FindAsync(Group.Id);

            if (existingGroup == null)
            {
                return false; // L'activité n'existe pas
            }

            existingGroup.Name = Group.Name;

            _context.Groups.Update(existingGroup);
            await _context.SaveChangesAsync();
            return true;
        }

        // Supprimer un groups
        public async Task<bool> DeleteGroupAsync(int id)
        {
            var Group = await _context.Groups.FindAsync(id);
            if (Group == null)
            {
                return false; // Le groups n'existe pas
            }

            _context.Groups.Remove(Group);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
