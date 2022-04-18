#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTL_APIMOVIE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTL_APIMOVIE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        // GET: api/<CountrysController>
        private readonly APIMOVIESContext _context;

        public CountrysController(APIMOVIESContext context)
        {
            _context = new APIMOVIESContext();
        }
        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbQuocgia>>> GetTbQuocGia()
        {
            return await _context.TbQuocgia.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbQuocgia>> GetTbQuocGia(int id)
        {
            var tbQuocgia = await _context.TbQuocgia.FindAsync(id);

            if (tbQuocgia == null)
            {
                return NotFound();
            }

            return tbQuocgia;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbQuocgia(int id, TbQuocgia tbQuocgia)
        {
            if (id != tbQuocgia.Maquocgia)
            {
                return BadRequest();
            }

            _context.Entry(tbQuocgia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbQuocgiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbQuocgia>> PostTbLoaiphim(TbQuocgia tbQuocgia)
        {
            _context.TbQuocgia.Add(tbQuocgia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbQuocGia", new { id = tbQuocgia.Maquocgia }, tbQuocgia);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetTbQuocGia(int id)
        {
            var tbQuocgia = await _context.TbQuocgia.FindAsync(id);
            if (tbQuocgia== null)
            {
                return NotFound();
            }
            
            List<TbPhimQuocgia> tbPhimQuocgias = _context.TbPhimQuocgia.Where(n => n.Maquocgia == id).ToList();
            foreach (TbPhimQuocgia item in tbPhimQuocgias)
            {
                _context.TbPhimQuocgia.Remove(item);
            }
            _context.TbQuocgia.Remove(tbQuocgia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbQuocgiaExists(int id)
        {
            return _context.TbQuocgia.Any(e => e.Maquocgia == id);
        }
    }
}
