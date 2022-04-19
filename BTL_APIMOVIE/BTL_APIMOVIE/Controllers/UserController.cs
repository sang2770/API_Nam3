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
    [Route("api/[controller]")]
    //[Authorize(Roles = Role.Admin)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public UserController(APIMOVIESContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: api/User
        public ActionResult GetTbNguoidungs(string name,int pageNumber, int pageSize)
        {

            var query = _context.TbNguoidungs.Where(n=>n.Tendangnhap.Contains(name!=null?name:"")).ToList();
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
