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
using BTL_APIMOVIE.Auth;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTL_APIMOVIE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhimLoaiPhimController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public PhimLoaiPhimController(APIMOVIESContext context)
        {
            _context = new APIMOVIESContext();
        }
        [HttpGet]
        public ActionResult GetTbPhimLoaiPhims()
        {
            var tbphimloai = _context.TbPhimLoaiPhims.ToList();
            return Ok(tbphimloai);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhimLoaiPhim>> GetTbPhimLoaiPhims(int id)
        {
            var tbPhimLoaiPhims = await _context.TbPhimLoaiPhims.FindAsync(id);

            if (tbPhimLoaiPhims == null)
            {
                return NotFound();
            }

            return tbPhimLoaiPhims;
        }


        [Authorize(Roles = Role.Admin)]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPhimLoaiPhim>> PostTbPhimLoaiPhims(int Ma,int Maphim,int Maloaiphim)
        {
            TbPhimLoaiPhim tbPhimLoaiPhim = new TbPhimLoaiPhim(Ma, Maphim, Maloaiphim);
            _context.TbPhimLoaiPhims.Add(tbPhimLoaiPhim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPhimLoaiPhims", new { id = tbPhimLoaiPhim.Ma }, tbPhimLoaiPhim);
        }
        [Authorize(Roles = Role.Admin)]

        // DELETE: api/Category/5
        [HttpDelete("{maphim}/{maloai}")]
        public async Task<IActionResult> DeleteTbPhimLoaiPhims(int maphim,int maloai)
        {
            int id = _context.TbPhimLoaiPhims.Where(n=>n.Maphim == maphim).Where(n=>n.Maloaiphim==maloai).FirstOrDefault().Ma;
            var tbPhimLoaiPhims = await _context.TbPhimLoaiPhims.FindAsync(id);
            if (tbPhimLoaiPhims == null)
            {
                return NotFound();
            }
            

            _context.TbPhimLoaiPhims.Remove(tbPhimLoaiPhims);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
