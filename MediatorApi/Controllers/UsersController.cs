using MediatorApi.Commands;
using MediatorApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator Mediatr;

        public UsersController(IMediator mediatr)
        {
            Mediatr = mediatr;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediatr.Send(new UserListQuery());
            return Ok(result);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediatr.Send(new UserGetByIdQuery(id));
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddUserCommand command)
        {
            var result = await Mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await Mediatr.Send(command);
            return Ok(result);
        }
        [HttpPut("UpdateUsername")]
        public async Task<IActionResult> UpdateUsername(UpdateUsernameCommand command)
        {
            var result = await Mediatr.Send(command);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediatr.Send(new DeleteUserCommand(id));
            return Ok(result);
        }
    }
}
