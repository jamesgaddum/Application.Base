using System.Threading.Tasks;
using Application.Base.Application;
using Application.Base.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Base.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<User> GetUser(GetUserQuery query)
        {
            return await  _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), user);
        }
    }
}
