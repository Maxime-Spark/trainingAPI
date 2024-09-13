using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MyApi.DTOs;
using MyApi.Models;
using MyApi.Services;

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
        // [Authorize]
        public async Task<ActionResult<IEnumerable<RegistrationRawDto>>> GetRegistrations()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            var registrationRawDtos = _mapper.Map<IEnumerable<RegistrationRawDto>>(registrations);
            return Ok(registrationRawDtos);
        }

        [HttpGet("{userId}/{activityId}")]
        // [Authorize]
        public async Task<ActionResult<RegistrationRawDto>> GetRegistration(int userId, int activityId)
        {
            var registration = await _registrationService.GetRegistrationByIdsAsync(userId, activityId);
            if (registration == null) return NotFound();

            var registrationRawDto = _mapper.Map<RegistrationRawDto>(registration);
            return Ok(registrationRawDto);
        }

        [HttpPost]
        // [Authorize]
        public async Task<ActionResult<RegistrationRawDto>> CreateRegistration(RegistrationCreationDto registrationRawDto)
        {
            var registration = _mapper.Map<Registration>(registrationRawDto);
            await _registrationService.AddRegistrationAsync(registration);

            var createdRegistrationDto = _mapper.Map<RegistrationRawDto>(registration);
            return CreatedAtAction(nameof(GetRegistration), new { userId = registration.UserId, activityId = registration.ActivityId }, createdRegistrationDto);
        }

        [HttpDelete("{userId}/{activityId}")]
        // [Authorize]
        public async Task<IActionResult> DeleteRegistration(int userId, int activityId)
        {
            var deleted = await _registrationService.DeleteRegistrationAsync(userId, activityId);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
