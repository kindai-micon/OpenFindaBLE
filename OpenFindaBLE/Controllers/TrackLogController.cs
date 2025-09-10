using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OpenFindaBLE.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackLogController(ApplicationDbContext dbContext) : ControllerBase
    {
        
        [Authorize(Policy = "TrackLogController")]

        [HttpPost(nameof(GetLocationLog))]
        public async Task<List<string>> GetLocationLog(Guid id)
        {
            var logs = await dbContext.TrackLogs.Where(x => x.Id == id).ToListAsync();
            var locations = new List<string>();
            logs.ForEach(x =>
            {
                var location = $"{x.Longitude},{x.Latitude}";
                locations.Add(location);
            });
            if (logs == null)
            {
                return null;
            }
            
            return locations;
        }
    }
}
