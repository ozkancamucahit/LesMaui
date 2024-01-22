using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilOyku.API.Library.DataAccess;
using MobilOyku.API.Library.DTOS;
using MobilOyku.API.Library.Models;
using System.Reflection.Metadata.Ecma335;

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
				var memoId = await memoData.SaveMemo(memo);
				if (memoId != 0)
				{
					return CreatedAtRoute(nameof(GetMemo), new { memoId }, memo);

				}
				else
					return BadRequest("DB ERRROR");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("{memoId}", Name = nameof(GetMemo))]
		public async Task<ActionResult<MemoReadDTO>> GetMemo(int memoId)
		{
			try
			{
				var res = await memoData.GetMemo(memoId);

				if (res.Id == 0)
					return NotFound();
				else
					return Ok(res);
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
				await memoData.RemoveMemo(memo);
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
				var result =  await memoData.GetUserMemos(UserName);

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
