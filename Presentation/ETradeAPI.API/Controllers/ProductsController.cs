using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            //Product p = await _productReadRepository.GetByIdAsync("6d0753c0-1998-4102-9e92-6de84849b7b9");
            //p.Name = "product1";
            //await _productWriteRepository.SaveAsync();

            //Product p = await _productReadRepository.GetByIdAsync("6d0753c0-1998-4102-9e92-6de84849b7b9",false);
            //p.Name = "product5";
            //await _productWriteRepository.SaveAsync();
            return Ok(_productReadRepository.GetAll());
        }

        [HttpGet]
        [Route("get2")]
        public async Task Get2()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Name="laptop",Price=1000,Stock=1111},
                new() {Name="laptop2",Price=2000,Stock=2222},
                new() {Name="laptop3",Price=3000,Stock=3333}
            });

            await _productWriteRepository.SaveAsync();
           
        }


    }
}
