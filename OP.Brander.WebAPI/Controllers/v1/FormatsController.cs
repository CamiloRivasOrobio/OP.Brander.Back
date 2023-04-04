using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Brander.Application.DTOs.Formats;
using OP.Brander.Application.Features.Format.Queries.GetAllFormatsQuery;

namespace OP.Brander.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FormatsController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FormatsRequest request)
        {
            return Ok(await Mediator.Send(new GetAllFormatsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Formato = request.Formato,
                Caracteristicas = request.Caracteristicas,
                FormatoPelicula = request.FormatoPelicula,
            }));
        }
    }
}