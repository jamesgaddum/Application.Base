using System.Threading.Tasks;
using Application.Base.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Base.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(string id)
        {
            return await _mediator.Send(new GetUserQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUser), user);
        }
    }
}
