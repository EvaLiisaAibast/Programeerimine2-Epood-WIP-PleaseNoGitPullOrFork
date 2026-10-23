using KooliProjekt.Application.Infrastructure.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public abstract class ApiControllerBase : Controller
    {
        private static JsonSerializerSettings _serializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

        protected IActionResult Result(OperationResult result)
        {
            var serialized = JsonConvert.SerializeObject(result, _serializerSettings);

            if (result.HasErrors)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = serialized,
                    ContentType = "application/json"
                };
            }

            return Content(serialized, "application/json");
        }

        protected IActionResult Result<T>(OperationResult<T> result)
        {
            var serialized = JsonConvert.SerializeObject(result, _serializerSettings);

            if (result.HasErrors)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = serialized,
                    ContentType = "application/json"
                };
            }

            if (result.Value == null)
            {
                return NotFound();
            }

            return Content(serialized, "application/json");
        }
    }
}