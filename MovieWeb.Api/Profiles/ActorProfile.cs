using AutoMapper;
using MovieWeb.Api.Dto.Actors;
using MovieWeb.Domain;

namespace MovieWeb.Api.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, GetActorListDto>()
                .ForMember(x => x.FullName, 
                options => options.MapFrom(y => y.FirstName + " " + y.LastName));
        }
    }
}
