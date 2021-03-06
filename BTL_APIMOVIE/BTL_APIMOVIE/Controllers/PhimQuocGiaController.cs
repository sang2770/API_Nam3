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
    public class PhimQuocGiaController : ControllerBase
    {
        private readonly APIMOVIESContext _context;

        public PhimQuocGiaController(APIMOVIESContext context)
        {
            _context = new APIMOVIESContext();
        }
        // GET: api/<PhimQuocGiaController>
        [HttpGet]
        public ActionResult GetTbPhimQuocgia()
        {
            var tbPhim_quocgia = _context.TbPhimQuocgia.ToList();
            return Ok(tbPhim_quocgia);
        }

        // GET api/<PhimQuocGiaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [Authorize(Roles = Role.Admin)]

        // POST api/<PhimQuocGiaController>
        [HttpPost]
        public async Task<ActionResult<TbPhimQuocgia>> PostTbPhimQuocgia(int Ma, int Maphim, int Maquocgia)
        {
            TbPhimQuocgia tbPhimQuocgia =new TbPhimQuocgia(Ma,Maphim,Maquocgia);
            _context.TbPhimQuocgia.Add(tbPhimQuocgia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPhimQuocgia", new { id = tbPhimQuocgia.Ma }, tbPhimQuocgia);
        }
        [Authorize(Roles = Role.Admin)]

        // PUT api/<PhimQuocGiaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [Authorize(Roles = Role.Admin)]

        // DELETE api/<PhimQuocGiaController>/5
        [HttpDelete("{maphim}/{maquocgia}")]
        public async Task<IActionResult> DeleteTbPhimQuocgia(int maphim, int maquocgia)
        {
            int id = _context.TbPhimQuocgia.Where(n => n.Maphim == maphim).Where(n => n.Maquocgia==maquocgia).FirstOrDefault().Ma;
            var tbPhimQuocgia = await _context.TbPhimQuocgia.FindAsync(id);
            if (tbPhimQuocgia == null)
            {
                return NotFound();
            }


            _context.TbPhimQuocgia.Remove(tbPhimQuocgia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
