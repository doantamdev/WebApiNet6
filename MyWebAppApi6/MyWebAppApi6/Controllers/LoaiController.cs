using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAppApi6.Helpers;
using MyWebAppApi6.Models;
using MyWebAppApi6.Repositories;
using NuGet.Packaging.Signing;

namespace MyWebAppApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepo;
        public LoaiController(ILoaiRepository repo)
        {
            _loaiRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoais()
        {
            try
            {
                return Ok(await _loaiRepo.getAllLoaisAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiById(int id)
        {
            var loai = await _loaiRepo.getLoaiAsync(id);
            return loai == null ? NotFound() : Ok(loai);
        }

        [HttpPost]
        [Authorize(Roles =AppRole.Admin)]
        public async Task<IActionResult> AddNewLoai (LoaiVM model)
        {
            try
            {
                var newLoaiId = await _loaiRepo.AddLoaiAsync(model);
                var loai = await _loaiRepo.getLoaiAsync(newLoaiId);
                return loai == null ? NotFound() : Ok(loai);
            }
            catch {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoai(int id, LoaiVM model)
        {
            if(id != model.MaLoai)
            {
                return NotFound();
            }
            await _loaiRepo.UpdateLoaiAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoai([FromRoute] int id)
        {
            await _loaiRepo.DeleteLoaiAsync(id);
            return Ok();
        }
    }
}
