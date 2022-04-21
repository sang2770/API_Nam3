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

namespace BTL_APIMOVIE.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly APIMOVIESContext _context;
        public static IWebHostEnvironment _webHostEnvironment;

        public MoviesController(IWebHostEnvironment webHostEnvironment)
        {
            _context = new APIMOVIESContext();
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult GetTbPhims(string name, int pageNumber, int pageSize)
        {
            var query = _context.TbPhims.Where(n => n.Tenphim.Contains(name != null ? name : "")).ToList();
            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pageNumber > 0 ? pageNumber : 1;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pageSize > 0 ? pageSize : 1;

            // tất cả bản ghi 
            int TotalCount = query.Count(); ;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var items = query.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? true : false;

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? true : false;

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage,
                data = items
            };
            return Ok(paginationMetadata);
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
            var tbPhim = await _context.TbPhims.Where(n => n.Tenphim.Contains(name)).ToListAsync();

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
            foreach (var item in query)
            {
                tbPhims.Add(item);
            }
            return tbPhims;
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
        public async Task<IActionResult> PutTbPhim(int id, [FromForm] TbPhim tbPhim, [FromForm] FileUpload objectfile)
        {
            tbPhim.Maphim = id;
            try
            {
                if (objectfile.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Image\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectfile.files.FileName))
                    {
                        objectfile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        tbPhim.Anh = "https://localhost:7053/Image/" + objectfile.files.FileName;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw;
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
        public async Task<ActionResult<TbPhim>> PostTbPhim([FromForm] TbPhim tbPhim, [FromForm] FileUpload objectfile)
        {
            try
            {
                if (objectfile.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Image\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectfile.files.FileName))
                    {
                        objectfile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        tbPhim.Anh = "https://localhost:7053/Image/" + objectfile.files.FileName;
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }

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
      
        
    }
}
