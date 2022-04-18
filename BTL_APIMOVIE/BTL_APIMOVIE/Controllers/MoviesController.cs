﻿#nullable disable
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

namespace BTL_APIMOVIE.Controllers
{
    [Authorize]
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
        [HttpGet("NameMovie/{name}")]
        public async Task<ActionResult<IEnumerable<TbPhim>>> GetTbPhimByName(string name)
        {
            var tbPhim = await _context.TbPhims.Where(n=>n.Tenphim.Contains(name)).ToListAsync();

            if (tbPhim == null)
            {
                return NotFound();
            }

            return tbPhim;
        }
        //tìm theo the loai
        [HttpGet("MoveByCategory/{category}")]
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
        [HttpGet("MovieByCountry/{country}")]
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

        [Authorize(Roles = Role.Admin)]
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
        [Authorize(Roles = Role.Admin)]
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPhim>> PostTbPhim(TbPhim tbPhim)
        {
            _context.TbPhims.Add(tbPhim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPhim", new { id = tbPhim.Maphim }, tbPhim);
        }
        [Authorize(Roles = Role.Admin)]
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhim(int id)
        {
            var tbPhim = await _context.TbPhims.FindAsync(id);
            if (tbPhim == null)
            {
                return NotFound();
            }
            List<TbPhimLoaiPhim> tbPhimLoaiPhims=_context.TbPhimLoaiPhims.Where(n=>n.Maphim==id).ToList();
            foreach(TbPhimLoaiPhim item in tbPhimLoaiPhims)
            {
                _context.TbPhimLoaiPhims.Remove(item);
            }

            List<TbPhimQuocgia> tbPhimQuocgias = _context.TbPhimQuocgia.Where(n => n.Maphim == id).ToList();
            foreach (TbPhimQuocgia item in tbPhimQuocgias)
            {
                _context.TbPhimQuocgia.Remove(item);
            }

            _context.TbPhims.Remove(tbPhim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhimExists(int id)
        {
            return _context.TbPhims.Any(e => e.Maphim == id);
        }
       /* [Route("api/Movies/UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            //Create the Directory.
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Fetch the File Name.
            string fileName = Path.GetFileName(postedFile.FileName);

            //Save the File.
            postedFile.SaveAs(path + fileName);

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }*/

        
    }
}
