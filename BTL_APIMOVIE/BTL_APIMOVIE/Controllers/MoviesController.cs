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
    public class MoviesController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public MoviesController()
        {
            _context = new APIMOVIESContext();
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPhim>>> GetTbPhims()
        {
            return await _context.TbPhims.ToListAsync();
        }
        // Lấy danh sach phim danh gia cao
        [HttpGet("GetMovieByRate")]
        public async Task<ActionResult<IEnumerable<TbPhim>>> GetMoviebyRate()
        {
            return await _context.TbPhims.Where(n => n.Danhgiaphim >= 5).ToListAsync();
        }
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhim>> GetTbPhim(int id)
        {
            var tbPhim = await _context.TbPhims.FindAsync(id);

            if (tbPhim == null)
            {
                return NotFound();
            }

            return tbPhim;
        }
        [HttpGet("TenPhim/{name}")]
        public async Task<ActionResult<TbPhim>> GetTbPhimByName(string name)
        {
            var tbPhim = await _context.TbPhims.Where(n=>n.Tenphim==name).FirstOrDefaultAsync();

            if (tbPhim == null)
            {
                return NotFound();
            }

            return tbPhim;
        }
        //tìm theo the loai
        [HttpGet("PhimBycategory/{category}")]
        public async Task<ActionResult<IEnumerable<TbPhim>>> GetTbPhimsByCategory(string category)
        {
            List<TbPhim> tbPhims = new List<TbPhim>();
            var query = (from movie in _context.TbPhims
                         join theloai_phim in _context.TbPhimLoaiPhims on movie.Maphim equals theloai_phim.Maphim
                         join theloai in _context.TbLoaiphims on theloai_phim.Maloaiphim equals theloai.Maloaiphim
                         where theloai.Tenloaiphim.Equals(category)
                         select movie).ToList();
            foreach(var item in query)
            {
                tbPhims.Add(item);
            }
            return  tbPhims;
        }
        //tìm theo country
        [HttpGet("PhimBycountry/{country}")]
        public async Task<ActionResult<IEnumerable<TbPhim>>> GetTbPhimsByCountry(string country)
        {
            List<TbPhim> tbPhims = new List<TbPhim>();
            var query = (from movie in _context.TbPhims
                         join phim_quocgia in _context.TbPhimQuocgia on movie.Maphim equals phim_quocgia.Maphim
                         join quocgia in _context.TbQuocgia on phim_quocgia.Maquocgia equals quocgia.Maquocgia
                         where quocgia.Tenquocgia.Equals(country)
                         select movie).ToList();
            foreach (var item in query)
            {
                tbPhims.Add(item);
            }
            return tbPhims;
        }


        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPhim(int id, TbPhim tbPhim)
        {
            if (id != tbPhim.Maphim)
            {
                return BadRequest();
            }

            _context.Entry(tbPhim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhimExists(id))
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

        [HttpPut("Rate/{id}")]
        public async Task<IActionResult> PutRateMovie(int id, TbPhim tbPhim)
        {
            if (id != tbPhim.Maphim)
            {
                return BadRequest();
            }

            _context.Entry(tbPhim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhimExists(id))
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
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPhim>> PostTbPhim(TbPhim tbPhim)
        {
            _context.TbPhims.Add(tbPhim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPhim", new { id = tbPhim.Maphim }, tbPhim);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhim(int id)
        {
            var tbPhim = await _context.TbPhims.FindAsync(id);
            if (tbPhim == null)
            {
                return NotFound();
            }

            _context.TbPhims.Remove(tbPhim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhimExists(int id)
        {
            return _context.TbPhims.Any(e => e.Maphim == id);
        }
    }
}
