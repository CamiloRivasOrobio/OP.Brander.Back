using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OP.Brander.Application.DTOs.Genders;
using OP.Brander.Application.Features.Gender.Queries.GetAllGendersQuery;

namespace OP.Brander.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class GendersController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GendersRequest request)
        {
            return Ok(await Mediator.Send(new GetAllGendersQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Id = request.Id,
                Genero = request.Genero,
            }));
        }
    }
}