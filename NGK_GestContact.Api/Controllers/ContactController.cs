using Microsoft.AspNetCore.Mvc;
using NGK_GestContact.Api.Domain.Commands;
using NGK_GestContact.Api.Domain.Entities;
using NGK_GestContact.Api.Domain.Queries;
using NGK_GestContact.Api.Domain.Repositories;
using NGK_GestContact.Api.Dtos;
using Tools.Cqs.Results;

namespace NGK_GestContact.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ICqsResult<Contact> result = await _contactRepository.ExecuteAsync(new GetContactByIdQuery(id));

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateContactDto dto)
        {
            ICqsResult result = await _contactRepository.ExecuteAsync(new CreateContactCommand(dto.Nom, dto.Prenom, dto.Email, dto.Tel));

            if(result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }        
    }
}
