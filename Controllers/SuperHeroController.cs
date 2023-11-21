using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _dataContext.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetHeroById(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return NotFound("hero not found");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHero(SuperHero hero)
        {
            await _dataContext.SuperHeroes.AddAsync(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetAllHeroes());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Update(hero); await _dataContext.SaveChangesAsync();
            return Ok(await GetAllHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return NotFound("hero not found");
            }

            _dataContext.SuperHeroes.Remove(hero);

            await _dataContext.SaveChangesAsync();
            return Ok(await GetAllHeroes());
        }
    }
}
