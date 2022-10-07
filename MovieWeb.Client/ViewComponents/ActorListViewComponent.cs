using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models.Actors;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Client.ViewComponents
{
    public class ActorListViewComponent : ViewComponent
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorListViewComponent(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actors = await _actorService.GetAsync();

            var vms = _mapper.Map<IEnumerable<ActorListViewModel>>(actors);

            return View(vms);
        }
    }
}
