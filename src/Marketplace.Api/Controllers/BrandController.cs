using Marketplace.Api.Models;
using Marketplace.Dal.Repositories;
using Marketplace.Domain.Entities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly ILogger<BrandController> _logger;
    private readonly IBrandRepository _brandRepository;

    public BrandController(ILogger<BrandController> logger,
        IBrandRepository brandRepository)
    {
        _logger = logger;
        _brandRepository = brandRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody]BrandCreate model)
    {
        var entity = new Brand()
        {
            Name = model.Name,
            Description = model.Description
        };

        var result = await _brandRepository.AddAsync(entity);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _brandRepository.GetAllAsync();

        return Ok(brands);
    }
}
