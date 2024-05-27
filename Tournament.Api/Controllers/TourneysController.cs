using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;


namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourneysController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TourneysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<TourneysController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tourney>>> GetTourneys()
        {
            var Tourneys = await _unitOfWork.Tourney.GetAllAsync();
            return Ok(Tourneys);
        }

        // GET: api/Tourneys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tourney>> GetTourney(int id)
        {
            var tourney = await _unitOfWork.Tourney.GetAsync(id);

            if (tourney == null)
            {
                return NotFound();
            }

            return tourney;
        }

        // PUT: api/Tourneys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourney(int id, Tourney tourney)
        {
            if (id != tourney.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Tourney.UpdateAsync(tourney);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!await _unitOfWork.Tourney.AnyAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tourneys
        [HttpPost]
        public async Task<ActionResult<Tourney>> PostTourney(Tourney tourney)
        {
            _unitOfWork.Tourney.Add(tourney);
            await _unitOfWork.SaveChangesAsync();

            // Access the Id property of the created tourney instance
            int createdTourneyId = tourney.Id;

            return CreatedAtAction("GetTourney", new { id = createdTourneyId }, tourney);
        }

        // DELETE: api/Tourneys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourney(int id)
        {
            var tourney = await _unitOfWork.Tourney.GetAsync(id);
            if (tourney == null)
            {
                return NotFound();
            }

            _unitOfWork.Tourney.RemoveAsync(tourney);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
