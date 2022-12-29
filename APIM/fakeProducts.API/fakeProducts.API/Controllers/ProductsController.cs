using fakeProducts.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace fakeProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return Ok(product);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.GetProductById(id));
        }



    }
}
