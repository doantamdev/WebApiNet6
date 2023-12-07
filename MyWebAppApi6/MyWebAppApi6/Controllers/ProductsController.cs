using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAppApi6.Repositories;

namespace MyWebAppApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;

        public ProductsController(IHangHoaRepository hangHoaRepository) 
        {
            _hangHoaRepository = hangHoaRepository;
        }
        [HttpGet]
        public IActionResult GetAllProduct(string? search, double? from, double? to, string? sortBy, int page =1)
        {
            try
            {
                var result = _hangHoaRepository.GetAll(search,from,to,sortBy);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can not get the product");
            }



        }
    }
}
