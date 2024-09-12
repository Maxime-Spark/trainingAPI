using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;
using System.Threading.Tasks;

using MyApi.Models;
using MyApi.Services;
using MyApi.DTOs;

using AutoMapper;


namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            
            // Utiliser AutoMapper pour transformer la liste d'entités en DTOs
            var groupDtos = _mapper.Map<IEnumerable<GroupDto>>(groups);

            return Ok(groupDtos);
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroup(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            // Mapper l'entité Group vers GroupDto
            var groupDto = _mapper.Map<GroupDto>(group);

            return Ok(groupDto);
        }

        // POST: api/Group
        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup(GroupCreationDto groupDto)
        {
            // Mapper le DTO vers l'entité Group
            var group = _mapper.Map<Group>(groupDto);

            await _groupService.AddGroupAsync(group);

            // Retourner l'entité créée sous forme de DTO
            var createdGroupDto = _mapper.Map<GroupDto>(group);

            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, createdGroupDto);
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, GroupEditionDto groupDto)
        {
            if (id != groupDto.Id)
            {
                return BadRequest();
            }

            // Mapper le DTO vers l'entité Group à mettre à jour
            var group = _mapper.Map<Group>(groupDto);

            var updated = await _groupService.UpdateGroupAsync(group);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var deleted = await _groupService.DeleteGroupAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
