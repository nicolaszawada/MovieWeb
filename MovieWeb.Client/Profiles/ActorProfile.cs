using AutoMapper;
using MovieWeb.Client.Models.Actors;
using MovieWeb.Domain;

namespace MovieWeb.Client.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorListViewModel>();
            CreateMap<Actor, ActorDetailViewModel>();
            CreateMap<ActorCreateViewModel, Actor>();
            CreateMap<Actor, ActorEditViewModel>().ReverseMap();
            CreateMap<Actor, ActorDeleteViewModel>();
        }
    }
}
