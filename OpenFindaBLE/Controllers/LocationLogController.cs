using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OpenFindaBLE.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "TrackLogController")]
    public class LocationLogController(ApplicationDbContext applicationDbContext) : ControllerBase
    {
        
        [HttpGet(nameof(GetLocationLog))]
        public async Task<IActionResult> GetLocationLog(string userName)
        {
            return NotFound();//エラー対策
        }
        [HttpGet(nameof(GetLocationLog))]
        public async Task<IActionResult> GetLocationLog(Guid dviceId)
        {
            return NotFound();
        }
        [HttpGet(nameof(GetLocationBefore))]
        public async Task<IActionResult> GetLocationBefore(DateTime BeforeTime)
        {
            return NotFound();
        }
        [HttpGet(nameof(GetLocationAfter))]
        public async Task<IActionResult> GetLocationAfter(DateTime AfterTime)
        {
            return NotFound();
        }
        [HttpGet(nameof(GetLocationLog))]
        public async Task<IActionResult> GetLocationLog(DateTime BeforeTime, [FromQuery] DateTime AfterTime)
        {
            return NotFound();
        }
    }
}
