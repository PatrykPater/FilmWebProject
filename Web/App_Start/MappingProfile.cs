using AutoMapper;
using Model.Models;
using Service.Dtos;
using System.Linq;
using Web.Dtos;
using Web.Helpers;
using Web.ViewModels;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();

            CreateMap<Genre, GenreServiceDto>();
            CreateMap<GenreServiceDto, GenreViewModel>();

            CreateMap<FilmFormViewModel, Film>();
            CreateMap<Film, FilmFormViewModel>();


            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, Notification>();

            CreateMap<News, NewsDetailsViewModel>()
                .ForMember(dest => dest.Author,
                    opt => opt.MapFrom(source => NameHelper.GetFullUserName(source.Author.FirstName, source.Author.LastName)))
                .ForMember(dest => dest.DateOfPublication,
                    opt => opt.MapFrom(source => DateTimeHelper.GetDate(source.DateOfPublication)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(source => source.Tags.Select(t => t.Name)));

            CreateMap<ApplicationUser, AdminPromoteToModViewModel>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(source => NameHelper.GetFullUserName(source.FirstName, source.LastName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => source.Id));

            CreateMap<ReviewToAddDto, Review>();
            CreateMap<News, NewsForMainPageViewModel>();

            CreateMap<FilmListParametersViewModel, FilmListParametersServiceDto>();
            CreateMap<FilmListParametersServiceDto, FilmListParametersViewModel>();


        }
    }
}