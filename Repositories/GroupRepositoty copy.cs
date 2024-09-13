using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Repositories
{
    public class ActivityAccessRepository : IActivityAccessRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityAccessRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Récupérer tous les activityAccess
        public async Task<IEnumerable<ActivityAccess>> GetAllActivityAccessesAsync()
        {
            return await _context.ActivityAccesses
                .ToListAsync();
        }

        // Récupérer un activityAccess par ID
        public async Task<ActivityAccess?> GetActivityAccessByIdAsync(int id)
        {
            return await _context.ActivityAccesses
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Ajouter un nouveau activityAccess
        public async Task AddActivityAccessAsync(ActivityAccess activityAccess)
        {
            await _context.ActivityAccesses.AddAsync(activityAccess);
            await _context.SaveChangesAsync();
        }

        // Supprimer un activityAccess
        public async Task<bool> DeleteActivityAccessAsync(int id)
        {
            var activityAccess = await _context.ActivityAccesses.FindAsync(id);
            if (activityAccess == null)
            {
                return false; // Le activityAccess n'existe pas
            }

            _context.ActivityAccesses.Remove(activityAccess);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
