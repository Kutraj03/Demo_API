using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public URLApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetURL()
        {
            return Ok(await _context.URL_tbl.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetURL(int id)
        {
            var product = await _context.URL_tbl.FindAsync(id);
            if (product == null) 
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddUrl([FromBody] URL_tblViewmodel Viewmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new URL_tbl
            {
                URL = Viewmodel.URL,
                Active = Viewmodel.Active,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            };

            _context.URL_tbl.Add(model);
            await _context.SaveChangesAsync(); 

            
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
            model.Display_URL = $"{baseUrl}/{model.Id}";

            await _context.SaveChangesAsync(); 
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUrl(int id, [FromBody] URL_tbl model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var existingUrl = await _context.URL_tbl.FindAsync(id);
            if (existingUrl == null)
                return NotFound();

            // Update values
            existingUrl.URL = model.URL;
            existingUrl.Active = model.Active;

            await _context.SaveChangesAsync();

            return Ok(existingUrl);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var urlRecord = await _context.URL_tbl.FindAsync(id);
            if (urlRecord == null)
                return NotFound();

            _context.URL_tbl.Remove(urlRecord);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Record with Id {id} deleted successfully" });
        }


    }
}
