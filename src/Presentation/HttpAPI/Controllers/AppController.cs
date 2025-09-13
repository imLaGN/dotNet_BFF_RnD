using Microsoft.AspNetCore.Mvc;

namespace HttpAPI.Controllers
{
	[ApiController]
	public class AppController
	{
		[HttpGet("/")]
		public IActionResult Get() => new JsonResult(new { Message = "Hello World!" });
	}
}
