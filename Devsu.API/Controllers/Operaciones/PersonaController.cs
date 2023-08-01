using Devsu.Application.Features.Operaciones.Personas.Commands.CreatePersona;
using Devsu.Application.Features.Operaciones.Personas.Commands.DeletePersona;
using Devsu.Application.Features.Operaciones.Personas.Commands.UpdatePersona;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers.Operaciones
{
    [Route("api/persona/[action]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreatePersona")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePersona([FromBody] CreatePersonaCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdatePersona")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePersona([FromBody] UpdatePersonaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePersona")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePersona(int id)
        {
            var command = new DeletePersonaCommand
            {
                PersonaId = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
