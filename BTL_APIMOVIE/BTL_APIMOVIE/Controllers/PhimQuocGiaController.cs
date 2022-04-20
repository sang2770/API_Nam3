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

        // POST api/<PhimQuocGiaController>
        [HttpPost]
        public async Task<ActionResult<TbPhimQuocgia>> PostTbPhimQuocgia(int Ma, int Maphim, int Maquocgia)
        {
            TbPhimQuocgia tbPhimQuocgia =new TbPhimQuocgia(Ma,Maphim,Maquocgia);
            _context.TbPhimQuocgia.Add(tbPhimQuocgia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPhimQuocgia", new { id = tbPhimQuocgia.Ma }, tbPhimQuocgia);
        }

        // PUT api/<PhimQuocGiaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhimQuocGiaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
