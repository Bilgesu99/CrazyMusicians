using Microsoft.AspNetCore.Mvc;
using CrazyMusicians.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrazyMusicians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {
        private static readonly List<Musician> musicians = new List<Musician>
        {
            new Musician { Id = 1, Name = "Tarkan", Genre = "Pop", DebutYear = 1992 },
            new Musician { Id = 2, Name = "Sıla", Genre = "Pop", DebutYear = 2009 },
            new Musician { Id = 3, Name = "Müslüm Gürses", Genre = "Arabesk", DebutYear = 1980 },
            new Musician { Id = 4, Name = "Sezen Aksu", Genre = "Pop", DebutYear = 1975 }
        };

        // GET: api/musicians
        [HttpGet]
        public ActionResult<IEnumerable<Musician>> Get()
        {
            return Ok(musicians);
        }

        // GET: api/musicians/5
        [HttpGet("{id}")]
        public ActionResult<Musician> Get(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            return Ok(musician);
        }

        // POST: api/musicians
        [HttpPost]
        public ActionResult<Musician> Post([FromBody] Musician musician)
        {
            musician.Id = musicians.Max(m => m.Id) + 1; // Yeni ID oluştur
            musicians.Add(musician);
            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Musician updatedMusician)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            musician.Name = updatedMusician.Name;
            musician.Genre = updatedMusician.Genre;
            musician.DebutYear = updatedMusician.DebutYear;
            return NoContent();
        }

        // DELETE: api/musicians/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            musicians.Remove(musician);
            return NoContent();
        }
    }
}
