using EAV.api.Builder;
using EAV.api.Configurations;
using EAV.api.Entities.EAV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EAV.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] MyDbContext dbContext, Guid Id)
        {
            var result = await dbContext.Set<CustomEntity>()
                .Include(e => e.Attributes)
                    .ThenInclude(a => a.Values)
                .FirstOrDefaultAsync(e => e.Id == Id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] MyDbContext dbContext)
        {
            var e = new CustomEntity().Build("usuario")
                .AddAttribute("Name", "Nome do usr")
                .AddAttribute("BirthDate", DateTime.Now.AddYears(-20))
                .AddAttribute("Numbers", new int[] { 1, 2, 3, 4 })
                ;

            await dbContext.Set<CustomEntity>().AddAsync(e);
            await dbContext.SaveChangesAsync();

            return Ok(e);
        }
    }
}