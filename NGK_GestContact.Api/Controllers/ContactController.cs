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
        public IActionResult Get(int id)
        {
            ICqsResult<Contact> result = _contactRepository.Execute(new GetContactByIdQuery(id));

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }        

        [HttpGet("async/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            ICqsResult<Contact> result = await _contactRepository.ExecuteAsync(new GetContactByIdQuery(id));

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public IActionResult Post(CreateContactDto dto)
        {
            ICqsResult result = _contactRepository.Execute(new CreateContactCommand(dto.Nom, dto.Prenom, dto.Email, dto.Tel));

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("async")]
        public async Task<IActionResult> PostAsync(CreateContactDto dto)
        {
            ICqsResult result = await _contactRepository.ExecuteAsync(new CreateContactCommand(dto.Nom, dto.Prenom, dto.Email, dto.Tel));

            if(result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }        
    }
}
