using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using World.Api.DTO.Country;
using World.Api.DTO.State;
using World.Api.Modals;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateController(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetStateDto>>> GetAll()
        {
            var states = await _stateRepository.GetAll();
            if (states == null)
            {
                return NoContent();
            }
            var statesDto = _mapper.Map<List<GetStateDto>>(states);
            return Ok(statesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetStateDto>> GetStatesCountryId(int id)
        {
            var state = await _stateRepository.Get(id);
            if (state == null)
            {
                return NoContent();
            }
            var stateDto = _mapper.Map<GetStateDto>(state);
            return Ok(stateDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateStateDto>> Create([FromBody] CreateStateDto stateDto)
        {
            var result = _stateRepository.IsRecordExist(x => x.Name == stateDto.Name);
            if (result)
            {
                return Conflict("record already exist");
            }
            var state = _mapper.Map<States>(stateDto);
            await _stateRepository.Create(state);
            return CreatedAtAction("GetStatesCountryId", new { id = state.Id }, state);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<States>> Update(int id, [FromBody]UpdateStateDto updateStateDto)
        {
            if (updateStateDto == null || id != updateStateDto.Id)
            {
                return BadRequest();
            }
            var state = _mapper.Map<States>(updateStateDto);
            await _stateRepository.Update(state);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var country = await _stateRepository.Get(id);

            if (country == null)
            {
                return NotFound();
            }
            await _stateRepository.Delete(country);
            return Ok();
        }
    }
}