#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTL_APIMOVIE.Models;
using Microsoft.AspNetCore.Authorization;

namespace BTL_APIMOVIE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public CommentController()
        {
            _context = new APIMOVIESContext();
        }

        // GET: api/Comment
        [Route("/api/Coment/{MaPhim}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBinhluan>>> GetTbBinhluans(int MaPhim)
        {
            return await _context.TbBinhluans.Where(n=>n.Maphim==MaPhim).ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBinhluan>> GetTbBinhluan(int id)
        {
            var tbBinhluan = await _context.TbBinhluans.FindAsync(id);

            if (tbBinhluan == null)
            {
                return NotFound();
            }

            return tbBinhluan;
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBinhluan(int id, int MaTaiKhoan, TbBinhluan tbBinhluan)
        {
            if (id != tbBinhluan.Mabinhluan || MaTaiKhoan!=tbBinhluan.Mataikhoan)
            {
                return BadRequest();
            }

            _context.Entry(tbBinhluan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBinhluanExists(id))
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

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBinhluan>> PostTbBinhluan(TbBinhluan tbBinhluan)
        {
            _context.TbBinhluans.Add(tbBinhluan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbBinhluan", new { id = tbBinhluan.Mabinhluan }, tbBinhluan);
        }
        [Authorize]
        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBinhluan(int id, int MaTaiKhoan)
        {
            var tbBinhluan = await _context.TbBinhluans.FindAsync(id) ;
            
            if (tbBinhluan == null || tbBinhluan.Mataikhoan==MaTaiKhoan)
            {
                return NotFound();
            }

            _context.TbBinhluans.Remove(tbBinhluan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBinhluanExists(int id)
        {
            return _context.TbBinhluans.Any(e => e.Mabinhluan == id);
        }
    }
}
