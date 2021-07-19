using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Application.Commands;
using MyBlog.Api.Application.Queries;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> CreateUser([FromBody] CreateUserCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        [HttpGet]
        public async Task<IActionResult> QueryUser([FromQuery] UserQuery query)
        {
            return new JsonResult(await _mediator.Send(query, HttpContext.RequestAborted));
        }
    }
}