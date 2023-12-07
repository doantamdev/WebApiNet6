using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAppApi6.Data;
using MyWebAppApi6.Models;


namespace MyWebAppApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsHangHoa = _context.HangHoas!.ToList();
                return Ok(dsHangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var hanghoa = _context.HangHoas!.SingleOrDefault(lo => lo.MaHh == Guid.Parse(id));
            if (hanghoa != null)
            {
                return Ok(hanghoa);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult CreateNew(HangHoaVM model)
        {
            try
            {
                var hanghoa = new HangHoaData
                {
                    TenHh = model.TenHangHoa,
                    DonGia  = model.DonGia
                };
                _context.Add(hanghoa);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(string id, HangHoaVM model)
        {
            var hanghoa = _context.HangHoas!.SingleOrDefault(lo => lo.MaHh == Guid.Parse(id));
            if (hanghoa != null)
            {
                hanghoa.TenHh = model.TenHangHoa;
                hanghoa.DonGia = model.DonGia;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(string id)
        {
            var hanghoa = _context.HangHoas!.SingleOrDefault(lo => lo.MaHh == Guid.Parse(id));
            if (hanghoa != null)
            {
                _context.Remove(hanghoa);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

