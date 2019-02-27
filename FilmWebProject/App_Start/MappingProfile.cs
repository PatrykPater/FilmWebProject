using AutoMapper;
using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;

namespace FilmWebProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreViewModel, Genre>();
            CreateMap<FilmFormViewModel, Film>();
            CreateMap<Film, FilmFormViewModel>();
        }
    }
}