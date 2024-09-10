using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Repositories;
using MyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public class RegistrationService : IRegistrationService
    {
         private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await _registrationRepository.GetAllRegistrationsAsync();
        }

        public async Task<Registration?> GetRegistrationByIdsAsync(int userId, int activityId)
        {
            return await _registrationRepository.GetRegistrationByIdsAsync(userId, activityId);
        }

        public async Task AddRegistrationAsync(Registration registration)
        {
            await _registrationRepository.AddRegistrationAsync(registration);
        }

        public async Task<bool> DeleteRegistrationAsync(int userId, int activityId)
        {
            return await _registrationRepository.DeleteRegistrationAsync(userId, activityId);
        }
    }
}
