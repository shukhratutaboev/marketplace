using Marketplace.Api.Models;
using Marketplace.Dal.Repositories;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.AspNetCore.Mvc;
using Attribute = Marketplace.Domain.Entities.TableModels.Attribute;

namespace Marketplace.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAttributeRepository _attributeRepository;

    public CategoryController(ILogger<CategoryController> logger,
        ICategoryRepository categoryRepository,
        IAttributeRepository attributeRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
        _attributeRepository = attributeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody]CategoryCreate model)
    {
        var entity = new Category()
        {
            Name = model.Name,
            ParentId = model.ParentId,
            IsLeafCategory = model.IsLeafCategory
        };

        var result = await _categoryRepository.AddAsync(entity);

        return Ok(result);
    }

    [HttpPost("{id:long}/attributes")]
    public async Task<IActionResult> AddAttributes([FromRoute]long id, [FromBody]List<AttributeCreate> attributes)
    {
        var entities = attributes.Select(a => {
            var entity = new Attribute()
            {
                Name = a.Name,
                IsFiltered = a.IsFiltered,
                IsHaveValues = a.IsHaveValues,
                CategoryId = id,
                Values = a.Values
            };
            return entity;
        });

        await _attributeRepository.AddRangeAsync(entities);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return Ok(categories);
    }

    [HttpGet("{id:long}/attributes")]
    public async Task<IActionResult> GetAttributes([FromRoute]long id)
    {
        var attributes = await _attributeRepository.GetCategoryAttributesAsync(id);

        return Ok(attributes);
    }
}
