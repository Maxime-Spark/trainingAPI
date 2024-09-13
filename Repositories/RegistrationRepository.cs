using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Include(r => r.User)
                .Include(r => r.Activity)
                .ToListAsync();
        }

        public async Task<Registration?> GetRegistrationByIdsAsync(int userId, int activityId)
        {
            return await _context.Registrations
                .Include(r => r.User)
                .Include(r => r.Activity)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ActivityId == activityId);
        }

        public async Task AddRegistrationAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRegistrationAsync(int userId, int activityId)
        {
            var registration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ActivityId == activityId);

            if (registration == null) return false;

            _context.Registrations.Remove(registration);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
