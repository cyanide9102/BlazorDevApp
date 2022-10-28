using BlazorDevApp.Core.Entities;
using BlazorDevApp.Core.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorDevApp.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private readonly IRepository<Product> _productRepository;

    public ProductsController(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost(Name = nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromForm] DataTables.Request request)
    {
        try
        {
            var query = _productRepository.Get();
            int recordsTotal = query.Count();

            // TODO: apply search filter

            int recordsFiltered = query.Count();

            // TODO: apply ordering

            query = query.Skip(request.Start).Take(request.Length);

            var catalogBrands = await query.ToListAsync();
            var response = new DataTables.Response<Product>
            {
                Draw = request.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = catalogBrands
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return Problem(e.InnerException != null ? e.InnerException.Message : e.Message);
        }
    }

    [HttpGet("{id}", Name = nameof(Get))]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product == null ? Problem(statusCode: StatusCodes.Status404NotFound) : Ok(product);
    }

    [HttpPost(Name = nameof(Create))]
    public async Task<IActionResult> Create()
    {
        return NoContent();
    }

    [HttpPost(Name = nameof(Update))]
    public async Task<IActionResult> Update()
    {
        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return Problem(statusCode: StatusCodes.Status404NotFound);
        }

        await _productRepository.DeleteAsync(product);
        await _productRepository.SaveChangesAsync();

        return NoContent();
    }
}
