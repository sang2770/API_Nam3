#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTL_APIMOVIE.Models;

namespace BTL_APIMOVIE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public CategoryController(APIMOVIESContext context)
        {
            _context = new APIMOVIESContext();
        }
        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLoaiphim>>> GetTbLoaiphims()
        {
            return await _context.TbLoaiphims.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLoaiphim>> GetTbLoaiphim(int id)
        {
            var tbLoaiphim = await _context.TbLoaiphims.FindAsync(id);

            if (tbLoaiphim == null)
            {
                return NotFound();
            }

            return tbLoaiphim;
        }
        

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLoaiphim(int id, TbLoaiphim tbLoaiphim)
        {
            if (id != tbLoaiphim.Maloaiphim)
            {
                return BadRequest();
            }

            _context.Entry(tbLoaiphim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLoaiphimExists(id))
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
        public async Task<ActionResult<TbLoaiphim>> PostTbLoaiphim(TbLoaiphim tbLoaiphim)
        {
            _context.TbLoaiphims.Add(tbLoaiphim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbLoaiphim", new { id = tbLoaiphim.Maloaiphim }, tbLoaiphim);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLoaiphim(int id)
        {
            var tbLoaiphim = await _context.TbLoaiphims.FindAsync(id);
            if (tbLoaiphim == null)
            {
                return NotFound();
            }
            List<TbPhimLoaiPhim> tbPhimLoaiPhims = _context.TbPhimLoaiPhims.Where(n => n.Maloaiphim == id).ToList();
            foreach (TbPhimLoaiPhim item in tbPhimLoaiPhims)
            {
                _context.TbPhimLoaiPhims.Remove(item);
            }

            _context.TbLoaiphims.Remove(tbLoaiphim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLoaiphimExists(int id)
        {
            return _context.TbLoaiphims.Any(e => e.Maloaiphim == id);
        }
    }
}
