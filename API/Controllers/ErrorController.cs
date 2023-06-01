using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly StoreContext _context;

        public ErrorController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            // generate exception: can't execute ToString() on null / something that doesn't exist
            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }

    }
}
