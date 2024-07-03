using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    public class ErrorTestController : BaseApiController
    {
        private readonly ApplicationDBContext _db;

        public ErrorTestController(ApplicationDBContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetNotAuthorized()
        {
            return "Not authorized";
        }

        [HttpGet("not-found")]
        public ActionResult<Usuario> GetNotFound()
        {
            var userObject = _db.Users.Find(-1);
            if (userObject == null) return NotFound();
            return userObject;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var userObject = _db.Users.Find(-1);
            var userString = userObject.ToString();
            return userString;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Request are not valid");
        }
    }
}
