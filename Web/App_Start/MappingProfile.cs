using AutoMapper;
using Model.Models;
using Web.Dtos;
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
        }
    }
}