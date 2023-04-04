using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Brander.Application.DTOs.Films;
using OP.Brander.Application.Features.ChangeStatusFilmCommand.Commands.ChangeStatusFilmCommand;
using OP.Brander.Application.Features.Film.Queries.GetAllFilmsQuery;
using OP.Brander.Application.Features.CreateFilmCommand.Commands.CreateFilmCommand;
using OP.Brander.Application.Features.DeleteFilmCommand.Commands.DeleteFilmCommand;
using OP.Brander.Application.Features.GetFilmByIdQuery.Queries.GetFilmByIdQuery;
using OP.Brander.Application.Features.UpdateFilmCommand.Commands.UpdateFilmCommand;

namespace OP.Brander.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FilmsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilmsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllFilmsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Titulo = request.Titulo,
                Fecha = request.Fecha,
                Director = request.Director,
                Argumento = request.Argumento,
                Duracion = request.Duracion,
                Genero = request.Genero,
                Formato = request.Formato,
                Estado = request.Estado,
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetFilmByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFilmCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateFilmCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFilmCommand { Id = id }));
        }

        //PUT api/<controller>/3
        [HttpPut("Status/{id}")]
        public async Task<ActionResult> Status(int id)
        {
            if (id == 0)
                return BadRequest();
            return Ok(await Mediator.Send(new ChangeStatusFilmCommand { Id = id }));
        }
    }
}