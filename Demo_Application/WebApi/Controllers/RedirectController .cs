using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("{id}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedirectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RedirectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> RedirectToUrl(int id)
        {
            var record = await _context.URL_tbl.FindAsync(id);
            if (record == null || record.Active == false)
            {
                return NotFound("URL not found or inactive");
            }

            return Redirect(record.URL); // actual redirect
        }
    }
}
