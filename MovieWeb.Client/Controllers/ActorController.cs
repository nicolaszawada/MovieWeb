using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Client.Models.Actors;
using MovieWeb.Domain;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Client.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(IActorService actorService,
            IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _actorService.GetAsync();

            var vms = _mapper.Map<IEnumerable<ActorListViewModel>>(actors);

            return View(vms);
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetAsync(id);

            var vm = _mapper.Map<ActorDetailViewModel>(actor);

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorCreateViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            var actor = _mapper.Map<Actor>(vm);

            await _actorService.CreateAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorService.GetAsync(id);

            var vm = _mapper.Map<ActorEditViewModel>(actor);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            var actor = _mapper.Map<Actor>(vm);

            await _actorService.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Details), new { Id = id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetAsync(id);

            var vm = _mapper.Map<ActorDeleteViewModel>(actor);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _actorService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
