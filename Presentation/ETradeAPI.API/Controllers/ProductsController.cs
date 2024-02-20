using ETradeAPI.Application.Repositories;
using ETradeAPI.Application.ViewModels.Product;
using ETradeAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(_productReadRepository.GetAll(false)); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {

            return Ok(await _productReadRepository.GetByIdAsync(id, false));

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreateViewModel model)
        {
            //if (ModelState.IsValid)
            //{
               
            //}

            await _productWriteRepository.AddAsync(new Product()
            {

                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price

            });

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created); //return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateViewModel model)
        {

            Product product = await _productReadRepository.GetByIdAsync(model.Id);

            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;

            await _productWriteRepository.SaveAsync();
            return Ok();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( [FromRoute] string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

       


    }
}
