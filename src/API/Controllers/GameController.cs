using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;
using Webshop.API.Entities;
using Webshop.API.Models;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/games")]
    public class GamesController : Controller
    {

        private readonly IGameRepository _GameRepository;
        private readonly IMapper _mapper;

        public GamesController(IGameRepository GameRepository, IMapper mapper)
        {
            _GameRepository = GameRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGames()
        {
            var Games = await _GameRepository.GetGamesAsync();
            return Ok(_mapper.Map<IEnumerable<GameDto>>(Games));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGame(Guid id)
        {
            var Game = await _GameRepository.GetGameAsync(id);

            if (Game == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GameDto>(Game));
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> AddGame(GameDto GameDto)
        {
            var game = await _GameRepository.AddGameAsync(_mapper.Map<Game>(GameDto));
            await _GameRepository.SaveChangesAsync();
            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(GameDto GameDto)
        {
            var Game = await _GameRepository.GetGameAsync(GameDto.Id);
            if (Game == null)
            {
                return NotFound();
            }
            _GameRepository.UpdateGame(_mapper.Map<Game>(GameDto));
            await _GameRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a specific file
        /// <summary>
        /// <param name="id">Guid of a Game</param>
        /// <returns>/</returns>
        /// <remarks>
        /// Attention: The Game will be deleted
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            var Game = await _GameRepository.GetGameAsync(id);
            if (Game == null)
            {
                return NotFound();
            }

            _GameRepository.DeleteGame(Game);
            return NoContent();
        }
    }
}
