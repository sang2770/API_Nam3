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
using Newtonsoft.Json;

namespace BTL_APIMOVIE.Controllers
{
    [Authorize]
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
        [Route("/api/CommentByMovie/{MaPhim}")]
        [HttpGet]
        public ActionResult GetTbBinhluans(int MaPhim, int pageNumber, int pageSize)
        {
            var query = (from comment in _context.TbBinhluans
                        join tk in _context.TbNguoidungs
                        on comment.Mataikhoan equals tk.Mataikhoan
                        where comment.Maphim == MaPhim
                        orderby comment.Mabinhluan descending
                        select new
                        {
                            mabinhluan = comment.Mabinhluan,
                            tentaikhoan = tk.Tendangnhap,
                            noidung = comment.Noidung,
                            thoigian = comment.Thoigian,
                            mataikhoan=tk.Mataikhoan
                        }).AsQueryable();
            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pageNumber>0?pageNumber:1;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pageSize>0?pageSize:5;

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
                data=items
            };
            return Ok(paginationMetadata);
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
        public async Task<IActionResult> PutTbBinhluan(int id, int mataikhoan, int maphim, string noidung, string thoigian)
        {
            var tbBinhluan = await _context.TbBinhluans.FindAsync(id);

            if (tbBinhluan == null || tbBinhluan.Mataikhoan != mataikhoan || tbBinhluan.Maphim!=maphim)
            {
                return NotFound();
            }
            tbBinhluan.Noidung = noidung;
            tbBinhluan.Thoigian = DateTime.Parse(thoigian);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBinhluan>> PostTbBinhluan(int mataikhoan,int maphim,string noidung,string thoigian)
        {
            TbBinhluan tbBinhluan = new TbBinhluan(mataikhoan, maphim, noidung, DateTime.Parse(thoigian));
            _context.TbBinhluans.Add(tbBinhluan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbBinhluan", new { id = tbBinhluan.Mabinhluan }, tbBinhluan);
        }
        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBinhluan(int id, int MaTaiKhoan)
        {
            var tbBinhluan = await _context.TbBinhluans.FindAsync(id) ;
            
            if (tbBinhluan == null || tbBinhluan.Mataikhoan!=MaTaiKhoan)
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
