using MediatR;
using Microsoft.AspNetCore.Mvc;
using UriReducer.Application.UriReducerFeatures.Add;

namespace UriReducer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UriReducerController : ControllerBase
    {
        private readonly IMediator mediator;

        public UriReducerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AddUriReducerResponse>> Create(AddUriReducerRequest request,
            CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
