using Microsoft.AspNetCore.Mvc;
using Waes.Api.Models;
using Waes.Api.Helpers;

namespace WaesApi.Controllers
{
    [Route("v1/[controller]")]
    public class DiffController : Controller
    {
        readonly ICompare compare;

        public DiffController(ICompare compare)
        {
            this.compare = compare;
        }

        /// <summary>
        /// Route for handling input of values that will be diff'ed. Call either /left or /right. 
        /// </summary>
        /// <returns>A result indicating the http status code</returns>
        /// <param name="id">Id of the string to be diffed</param>
        /// <param name="direction">The direction is defined by the route called</param>
        /// <param name="input">The string to be diffed</param>
        [HttpPost("{id}/{direction}")]
        public IActionResult Insert(int id, string direction, [FromBody]string input)
        {
            string decodedJson = Decoder.Decode(input.ToString());
            compare.Insert(id, direction, decodedJson);
            return Ok();
        }

        /// <summary>
        /// Get the compare for the two strings provided with the same Id
        /// </summary>
        /// <returns>A JsonResult containing the serialization of a DiffResultView, containing the Result of the comparison </returns>
        /// <param name="id">Id for the strings compared</param>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var compareResult = compare.GetResult(id);

            var response = new
            {
                Result = compareResult.Result
            };

            return new JsonResult(response);

        }
    }
}
