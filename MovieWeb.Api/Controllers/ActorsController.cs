using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Api.Dto.Actors;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Api.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly MovieContext _movieContext;

        public ActorsController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get an actor list
        /// </summary>
        /// <returns>actor list</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetActorListDto>>> Get()
        {
            var actors = await _actorService.GetAsync();

            var dtos = _mapper.Map<IEnumerable<GetActorListDto>>(actors);

            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetActorDetailDto>> Get(int id)
        {
            var actor = await _movieContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(new GetActorDetailDto()
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Birthdate = actor.Birthdate,
                PhoneNumber = actor.PhoneNumber
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateActorDto actorDto)
        {
            var actor = new Actor()
            {
                FirstName = actorDto.FirstName,
                LastName = actorDto.LastName,
                Birthdate = actorDto.Birthdate,
                PhoneNumber = actorDto.PhoneNumber
            };

            await _movieContext.Actors.AddAsync(actor);
            await _movieContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = actor.Id }, null);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateActorDto actorDto)
        {
            var actor = await _movieContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            actor.FirstName = actorDto.FirstName;
            actor.LastName = actorDto.LastName;

            await _movieContext.SaveChangesAsync();

            return Ok();
        }

    }
}
