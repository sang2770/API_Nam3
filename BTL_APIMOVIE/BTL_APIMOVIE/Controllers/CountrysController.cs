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
        [HttpGet("All")]
        public ActionResult GetTbQuocGia()
        {
            var tbcountry = _context.TbQuocgia.ToList();
            return Ok(tbcountry);
        }
        [HttpGet("GetTbquocgiaByMovie/{id}")]
        public ActionResult GetTbquocgiaByMovie(int id)
        {
            var query = from country in _context.TbQuocgia
                        join phim_quocgia in _context.TbPhimQuocgia on country.Maquocgia equals phim_quocgia.Maquocgia
                        where phim_quocgia.Maphim == id
                        select country;
            return Ok(query);
        }
        // GET: api/Category
        [HttpGet]
        public ActionResult GetTbQuocGia(string name, int pageNumber, int pageSize)
        {
            var query = _context.TbQuocgia.Where(n => n.Tenquocgia.Contains(name != null ? name : "")).ToList();
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
