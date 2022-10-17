using Microsoft.AspNetCore.Mvc;
using FindVan.Domain.Commands;
using FindVan.Domain.Entities;
using FindVan.Domain.Repositores;
using FindVan.Domain.Handlers;

namespace Findvan.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetAll(
            [FromServices]IUserRepository repository
        )
        {
            return repository.GetAll();
        }


        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]UserCommand command,
            [FromServices]UserHandler handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UserCommand command,
            [FromServices] UserHandler handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("set-image")]
        [HttpPut]
        public GenericCommandResult UpdateImage(
            [FromBody] UpdateImageUserCommand command,
            [FromServices] UserHandler handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}
