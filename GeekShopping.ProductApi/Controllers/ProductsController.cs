using GeekShopping.ProductApi.Interfaces;
using GeekShopping.ProductApi.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Create(productVo);
            return Ok(product);
        }
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Update(productVo);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Update(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
