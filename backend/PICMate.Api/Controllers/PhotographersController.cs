using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Controllers;

[ApiController]
[Route("api/photographers")]
public class PhotographersController(IPhotographerService photographerService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhotographerQuery query, CancellationToken ct)
    {
        var paged = await photographerService.GetPagedAsync(query, ct);
        var mapped = new PagedResponse<PhotographerResponse>
        {
            Items = paged.Items.Select(mapper.Map<PhotographerResponse>).ToList(),
            Page = paged.Page,
            PageSize = paged.PageSize,
            TotalItems = paged.TotalItems,
            TotalPages = paged.TotalPages
        };
        return Ok(mapped);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var item = await photographerService.GetByIdAsync(id, ct);
        return item is null ? NotFound() : Ok(mapper.Map<PhotographerResponse>(item));
    }
}
