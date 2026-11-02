using BookLocal.Application.Businesses.DTOs;
using BookLocal.Application.Businesses.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLocal.Api.Controllers;

[ApiController]
[Route("api/businesses")]
public class BusinessesController : ControllerBase
{
    private readonly IBusinessService _businessService;

    public BusinessesController(IBusinessService businessService)
    {
        _businessService = businessService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BusinessResponse>>> GetAll(
CancellationToken cancellationToken
    )
    {
        var allBusiness = await _businessService.GetAllAsync(cancellationToken);

        return Ok(allBusiness);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BusinessResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var business = await _businessService.GetByIdAsync(id, cancellationToken);

        if (business is null)
        {
            return NotFound();
        }

        return Ok(business);
    }

    [HttpPost]
    public async Task<ActionResult<BusinessResponse>> CreateBusiness(
CreateBusinessRequest request, CancellationToken cancellationToken
    )
    {
        var business = await _businessService.CreateAsync(request, cancellationToken);

        return Ok(business);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BusinessResponse>> UpdateBusiness(int id,
UpdateBusinessRequest updateBusinessRequest, CancellationToken cancellationToken
    )
    {
        var business = await _businessService.UpdateAsync(id, updateBusinessRequest, cancellationToken);

        if (business is null)
        {
            return NotFound();
        }

        return Ok(business);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteBusiness(int id, CancellationToken cancellationToken)
    {
        var result = await _businessService.DeleteAsync(id, cancellationToken);

        if (!result)
        {
            return NotFound();
        }


        return NoContent();
    }
}