using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MyApi.DTOs;
using MyApi.Models;
using MyApi.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IMapper _mapper;

        public RegistrationController(IRegistrationService registrationService, IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationDto>>> GetRegistrations()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            var registrationDtos = _mapper.Map<IEnumerable<RegistrationDto>>(registrations);
            return Ok(registrationDtos);
        }

        [HttpGet("{userId}/{activityId}")]
        public async Task<ActionResult<RegistrationDto>> GetRegistration(int userId, int activityId)
        {
            var registration = await _registrationService.GetRegistrationByIdsAsync(userId, activityId);
            if (registration == null) return NotFound();

            var registrationDto = _mapper.Map<RegistrationDto>(registration);
            return Ok(registrationDto);
        }

        [HttpPost]
        public async Task<ActionResult<RegistrationDto>> CreateRegistration(RegistrationCreationDto registrationDto)
        {
            var registration = _mapper.Map<Registration>(registrationDto);
            await _registrationService.AddRegistrationAsync(registration);

            var createdRegistrationDto = _mapper.Map<RegistrationDto>(registration);
            return CreatedAtAction(nameof(GetRegistration), new { userId = registration.UserId, activityId = registration.ActivityId }, createdRegistrationDto);
        }

        [HttpDelete("{userId}/{activityId}")]
        public async Task<IActionResult> DeleteRegistration(int userId, int activityId)
        {
            var deleted = await _registrationService.DeleteRegistrationAsync(userId, activityId);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
