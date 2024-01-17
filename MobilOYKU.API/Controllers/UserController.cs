using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Models;
using System.Net;
using System.Security.Claims;

namespace MobilOYKU.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public sealed class UserController : ControllerBase
	{
		private readonly IUserData userData;


		#region CTOR
		public UserController(IUserData userData)
        {
			this.userData = userData;
		}
		#endregion


		[HttpGet]
		[Route("{userName}", Name = nameof(ByUserName))]
		public IActionResult ByUserName(string userName)
		{
			UserModel result = userData.GetUserByUserName(userName);

			if (String.IsNullOrWhiteSpace(result.UserName))
				return NoContent();

			return Ok(result);

		}
		
		[HttpPost]
		public IActionResult SaveUser(UserCreateDTO user)
		{
			
			var result = userData.SaveUser(user);

			if (result)
				return CreatedAtRoute(nameof(ByUserName), new { userName = user.UserName }, user);
			else
				return BadRequest("COULD NOT CREATE USER => " + user.UserName);	

		}

	}
}
