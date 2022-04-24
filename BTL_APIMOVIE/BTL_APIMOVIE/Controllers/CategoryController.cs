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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public CategoryController(APIMOVIESContext context)
        {
            _context = new APIMOVIESContext();
        }
        [HttpGet("All")]
        public ActionResult GetTbLoaiphim()
        {
            var tbloai = _context.TbLoaiphims.ToList();
            return Ok(tbloai);
        }
        // GET: api/Category
        [HttpGet]
        public ActionResult GetTbLoaiphims(string name, int pageNumber, int pageSize)
        {
            var query = _context.TbLoaiphims.Where(n => n.Tenloaiphim.Contains(name != null ? name : "")).ToList();
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
        [HttpGet("GetTbLoaiphimByMovie/{id}")]
        public ActionResult GetTbLoaiphimByMovie(int id)
        {
            var query = from category in _context.TbLoaiphims
                        join phim_loaiphim in _context.TbPhimLoaiPhims on category.Maloaiphim equals phim_loaiphim.Maloaiphim
                        where phim_loaiphim.Maphim == id
                        select category;
            return Ok(query);
        }

        [Authorize(Roles = Role.Admin)]
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
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<TbLoaiphim>> PostTbLoaiphim(TbLoaiphim tbLoaiphim)
        {
            _context.TbLoaiphims.Add(tbLoaiphim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbLoaiphim", new { id = tbLoaiphim.Maloaiphim }, tbLoaiphim);
        }
        [Authorize(Roles = Role.Admin)]
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
