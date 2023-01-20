using Marketplace.Api.Models;
using Marketplace.Dal.Repositories;
using Marketplace.Domain.Entities.MongoModels;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IProductVariationRepository _productVariationRepository;

    public ProductController(ILogger<ProductController> logger,
        IProductRepository productRepository,
        IProductVariationRepository productVariationRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
        _productVariationRepository = productVariationRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody]ProductCreate model)
    {
        var entity = new Product()
        {
            Name = model.Name,
            CategoryId = model.CategoryId,
            BrandId = model.BrandId,
        };

        var result = await _productRepository.AddAsync(entity);

        return Ok(result);
    }

    [HttpGet("base")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();

        return Ok(products);
    }

    [HttpPost("{id:long}/variation")]
    public async Task<IActionResult> AddVariation([FromRoute]long id, [FromBody]ProductVariationCraete model)
    {
        var product = await _productRepository.GetAsync(id);
        var entity = new ProductVariation()
        {
            ProductId = id,
            CategoryId = product.CategoryId,
            Price = model.Price,
            Quantity = model.Quantity,
            Attributes = model.Attributes
        };

        await _productVariationRepository.AddAsync(entity);

        return Ok();
    }

    [HttpGet("{id:long}/variation")]
    public async Task<IActionResult> GetVariations([FromRoute]long id)
    {
        var variations = await _productVariationRepository.GetAllAsync();

        return Ok(variations);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery]ProductQuery query)
    {
        var products = await _productVariationRepository.GetProductsAsync(query);

        return Ok(products);
    }
}
