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
            CreateMap<FilmFormViewModel, Film>();
            CreateMap<Film, FilmFormViewModel>();
            CreateMap<Film, FilmListViewModel>();
            CreateMap<FilmFormViewModel, Film>();
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

            CreateMap<ReviewToAddDto, Review>()
                .ForMember(dest => dest.Film, opt => opt.MapFrom(source => source.Film))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(source => source.Author))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(source => source.Content))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title));

            CreateMap<News, NewsForMainPageViewModel>();

            CreateMap<FilmListParametersViewModel, FilmListParametersDto>()
                .ForMember(dest => dest.QuerySearch, opt => opt.MapFrom(source => source.QuerySearch))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(source => source.PageSize))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(source => source.PageNumber))
                .ForMember(dest => dest.MaxPageNumber, opt => opt.MapFrom(source => source.MaxPageNumber))
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(source => source.CurrentPage))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(source => source.Genres))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(source => source.Countries));

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, GenreViewModel>();

        }
    }
}