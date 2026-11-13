using System.Threading.Tasks;
using KooliProjekt.Application.Features.ProductImages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ProductFilesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProductFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{id}")]
        public async Task<IActionResult> Add(int id,
                                             IFormFile file,
                                             [FromForm] string altText = null,
                                             [FromForm] int sortOrder = 0,
                                             [FromForm] bool isMain = false)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            using var inputStream = file?.OpenReadStream();

            var command = new AddFileCommand
            {
                Id = id,
                FileName = file?.FileName,
                AltText = altText,
                SortOrder = sortOrder,
                IsMain = isMain,
                InputStream = inputStream
            };

            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var command = new GetFileCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.HasErrors || result.Value == null)
            {
                return Result(result);
            }

            return File(result.Value.Stream, result.Value.ContentType, result.Value.FileName);
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> List(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new ListFilesQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var command = new DeleteFileCommand { Id = id };
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
