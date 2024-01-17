using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.DTOS;

namespace MobilOYKU.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public sealed class PhotoController : ControllerBase
	{
		private readonly IPhotoData photoData;

		#region CTOR
		public PhotoController(IPhotoData photoData)
        {
			this.photoData = photoData;
		}
		#endregion


		[HttpPost]
		public async Task<IActionResult> SavePhoto(PhotoCreateDTO photo)
		{
			try
			{
				var result = photoData.SavePhoto(photo);

				if (result)
					return Ok();
				else 
					return BadRequest("COULD NOT SAVE PHOTO");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpPost]
		public async Task<IActionResult> RemovePhoto(PhotoDeleteDTO photo)
		{
			try
			{
				var result = photoData.RemovePhoto(photo);

				if (result)
					return Ok();
				else 
					return BadRequest("COULD NOT SAVE PHOTO");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
