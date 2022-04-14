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
    public class UserController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public UserController(APIMOVIESContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNguoidung>>> GetTbNguoidungs()
        {
            return await _context.TbNguoidungs.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNguoidung>> GetTbNguoidung(int id)
        {
            var tbNguoidung = await _context.TbNguoidungs.FindAsync(id);

            if (tbNguoidung == null)
            {
                return NotFound();
            }

            return tbNguoidung;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNguoidung(int id, TbNguoidung tbNguoidung)
        {
            if (id != tbNguoidung.Mataikhoan)
            {
                return BadRequest();
            }

            _context.Entry(tbNguoidung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNguoidungExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbNguoidung>> PostTbNguoidung(TbNguoidung tbNguoidung)
        {
            _context.TbNguoidungs.Add(tbNguoidung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbNguoidung", new { id = tbNguoidung.Mataikhoan }, tbNguoidung);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNguoidung(int id)
        {
            var tbNguoidung = await _context.TbNguoidungs.FindAsync(id);
            if (tbNguoidung == null)
            {
                return NotFound();
            }

            _context.TbNguoidungs.Remove(tbNguoidung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNguoidungExists(int id)
        {
            return _context.TbNguoidungs.Any(e => e.Mataikhoan == id);
        }
    }
}
