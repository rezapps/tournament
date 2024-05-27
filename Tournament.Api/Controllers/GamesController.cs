using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Dtos;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // private readonly TournamentContext _context;
        // private readonly IGameRepository _gameRepo;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GamesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET: api/<GamesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var games = await _unitOfWork.Game.GetAllAsync();
                var gamesDtos = _mapper.Map<IEnumerable<GameDto>>(games);
                return Ok(gamesDtos);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var game = await _unitOfWork.Game.GetAsync(id);
                if (game == null)
                {
                    return NotFound();
                }
                var gameDto = _mapper.Map<GameDto>(game);
                return Ok(gameDto);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<GamesController>
        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] Game game)
        {
            _unitOfWork.Game.Add(game);
            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(Get), new { id = game.Id }, game));
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Game game)
        {
            var gameFromDb = await _unitOfWork.Game.GetAsync(id);
            if (gameFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(game, gameFromDb);
            return NoContent();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var gameFromDb = await _unitOfWork.Game.GetAsync(id);
            if (gameFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Game.RemoveAsync(gameFromDb);
            return NoContent();
        }
    }
}
