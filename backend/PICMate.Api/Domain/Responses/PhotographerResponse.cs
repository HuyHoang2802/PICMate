namespace PICMate.Api.Domain.Responses;

public record PricingDto(decimal Hourly, decimal PerPhoto, decimal TiktokPackage);
public record ReviewDto(int Id, string User, string Avatar, int Rating, string Text, string Date);
public record PhotographerResponse(
    int Id,
    string Name,
    string Avatar,
    string CoverPhoto,
    string Bio,
    string Location,
    decimal Rating,
    int ReviewCount,
    bool IsOnline,
    bool IsVerified,
    bool InstantBooking,
    PricingDto Pricing,
    List<string> Styles,
    List<string> Portfolio,
    List<ReviewDto> Reviews
);
