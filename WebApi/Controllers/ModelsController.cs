using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Response;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pagerequest)
        {
            GetListModelQuery request = new() { PageRequest = pagerequest };
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pagerequest, [FromBody] DynamicQuery dynamicQuery)
        {
            GetListByDynamicModelQuery request = new() { PageRequest = pagerequest,DynamicQuery=dynamicQuery };
            GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
