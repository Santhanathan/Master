using AutoMapper;

namespace WebApplication1.Profiles
{
    public class Regionprofiles: Profile
    {
        public Regionprofiles()
        {
            CreateMap<Model.Domain.Region, Model.DTO.Region>()
                //.ForMember(dest => dest.ID, options => options.MapFrom(src =>src.ID))
                .ReverseMap();
        }
    }
}
