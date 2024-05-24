using Diplom.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [HttpGet("GetAllApps")]
        public async Task<List<App>> GetAllApps()
        {
           return await _context.Apps.ToListAsync();
        }
    }
}
