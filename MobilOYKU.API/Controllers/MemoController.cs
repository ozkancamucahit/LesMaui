using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Models;

namespace MobilOYKU.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public sealed class MemoController : ControllerBase
	{
		private readonly IMemoData memoData;


		#region CTOR
		public MemoController(IMemoData memoData)
        {
			this.memoData = memoData;
		}
		#endregion


		[HttpPost]
		public async Task<IActionResult> SaveMemo(MemoCreateDTO memo)
		{
			try
			{
				memoData.SaveMemo(memo);
				return Created();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpPost]
		public async Task<IActionResult> RemoveMemo(MemoDeleteDTO memo)
		{
			try
			{
				memoData.RemoveMemo(memo);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpGet]
		[Route("{UserName}")]
		public async Task<ActionResult<IEnumerable<MemoReadDTO>>> UserMemos(string UserName)
		{
			try
			{
				var result =  memoData.GetUserMemos(UserName);

				if (!result.Any())
				{
					return NoContent();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


    }
}
