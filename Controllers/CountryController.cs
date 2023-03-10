using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using World.Api.Data;
using World.Api.DTO.Country;
using World.Api.Modals;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCountriesDto>>> GetAll()
        {
            var countries = await _countryRepository.GetAll();
            if (countries == null)
            {
                return NoContent();
            }
            var countriesDto = _mapper.Map<List<GetCountriesDto>>(countries);
            return Ok(countriesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetCountriesDto>> GetCountryById(int id)
        {
            var country = await _countryRepository.Get(id);
            if (country == null)
            {
                return NoContent();
            }

            var countryDto = _mapper.Map<GetCountriesDto>(country);
            return Ok(countryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateCountryDto>> Create([FromBody] CreateCountryDto countryDto)
        {
            var result = _countryRepository.IsRecordExist(x => x.Name == countryDto.Name);
            if (result)
            {
                return Conflict("record already exist");
            }
            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.Create(country);
            return CreatedAtAction("GetCountryById", new { id = country.Id }, country);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>> Update(int id, [FromBody] UpdateCountriesDto updateCountriesDto)
        {
            if (updateCountriesDto == null || id != updateCountriesDto.Id)
            {
                return BadRequest();
            }
            var country = _mapper.Map<Country>(updateCountriesDto);
            await _countryRepository.Update(country);
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
            var country = await _countryRepository.Get(id);

            if (country == null)
            {
                return NotFound();
            }
            await _countryRepository.Delete(country);
            return Ok();
        }

    }
}
