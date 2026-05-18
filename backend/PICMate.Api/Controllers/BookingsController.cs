using Microsoft.AspNetCore.Mvc;
using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BookingQuery query, CancellationToken ct) => Ok(await bookingService.GetPagedAsync(query, ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request, CancellationToken ct)
    {
        var created = await bookingService.CreateAsync(request, ct);
        return created is null ? BadRequest(new { message = "Photographer does not exist." }) : Ok(created);
    }
}
