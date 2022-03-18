using AutoMapper;
using blissBackend.Dto.AuthDto;
using blissBackend.Models.Login;

namespace blissBackend.Profiles
{
    public class userProfiles : Profile
    {
        public userProfiles()
        {
            CreateMap<Book, readUserInfo>()
            .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.email,
                    opt => opt.MapFrom(src => $"{src.email}")
                )
                .ForMember(
                    dest => dest.password,
                    opt => opt.MapFrom(src => $"{src.password}")
                );
            CreateMap<adminSignup, Book>();
            CreateMap<login, Book>();
            CreateMap<Book, theLoginDto>();
            CreateMap<myLoginDto, Book>()
            .ForMember(
                    dest => dest.email,
                    opt => opt.MapFrom(src => $"{src.email}")
                )
                .ForMember(
                    dest => dest.password,
                    opt => opt.MapFrom(src => $"{src.password}")
                );
        }
    }
}