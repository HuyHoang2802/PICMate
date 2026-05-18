namespace PICMate.Api.Domain.Dtos;

public record CreateBookingRequest(int PhotographerId, string Service, string Date, string Time, string Location, decimal Total, string Note);
