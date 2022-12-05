using AutoMapper;

namespace WebApplication1.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile() {
            CreateMap<Model.Domain.Walk, Model.DTO.Walks>()
                    //.ForMember(dest => dest.ID, options => options.MapFrom(src =>src.ID))
                    .ReverseMap();

            CreateMap<Model.Domain.WalkDificulty, Model.DTO.WalkDificulty>()
                   //.ForMember(dest => dest.ID, options => options.MapFrom(src =>src.ID))
                   .ReverseMap();
        }
    }
}
