using AutoMapper;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Domain.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Photographer, PhotographerResponse>()
            .ConstructUsing(x => new PhotographerResponse(
                x.Id,
                x.Name,
                x.Avatar,
                x.CoverPhoto,
                x.Bio,
                x.Location,
                x.Rating,
                x.ReviewCount,
                x.IsOnline,
                x.IsVerified,
                x.InstantBooking,
                new PricingDto(x.HourlyPrice, x.PerPhotoPrice, x.TiktokPackagePrice),
                x.Styles.Select(s => s.Name).ToList(),
                x.PortfolioImages.OrderBy(i => i.SortOrder).Select(i => i.ImageUrl).ToList(),
                x.Reviews.Select(r => new ReviewDto(r.Id, r.User, r.Avatar, r.Rating, r.Text, r.Date)).ToList()
            ));
    }
}
