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
        private readonly ICoutryRepository _coutryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICoutryRepository coutryRepository, IMapper mapper)
        {
            _coutryRepository = coutryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCountriesDto>>> GetAll()
        {
            var countries = await _coutryRepository.GetAll();
            var coutriesDto = _mapper.Map<List<GetCountriesDto>>(countries);
            if(countries == null)
            {
               return NoContent();
            }
            return Ok(coutriesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetCountriesDto>> GetCountryById(int id)
        {
            var country = await _coutryRepository.GetCountryById(id);
            var coutryDto = _mapper.Map<GetCountriesDto>(country);
            if(country == null)
            {
                return NoContent();
            }
            return Ok(coutryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateCountryDto>> Create([FromBody] CreateCountryDto countryDto)
        {
            var result =_coutryRepository.IsCountryExist(countryDto.Name);
            if (result)
            {
                return Conflict("record already exist");
            }
            var country = _mapper.Map<Country>(countryDto);
            //var country = new Country();
            //country.Name = countryDto.Name; 
            //country.ShortName = countryDto.ShortName;
            //country.CountryCode= countryDto.CountryCode;    
            await _coutryRepository.Create(country);
            return CreatedAtAction("GetById", new {id = country.Id}, country);
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>> Update(int id, [FromBody] UpdateCountriesDto updateCoutriesDto)
        {
            if(updateCoutriesDto == null || id != updateCoutriesDto.Id)
            {
                return BadRequest();
            }
           
            //var countryDb = _context.Countries.Find(id);
            //if (countryDb == null)
            //{
            //    return NotFound();
            //}
            var country = _mapper.Map<Country>(updateCoutriesDto);
            //countryDb.Name = country.Name;
            //countryDb.ShortName = country.ShortName;
            //countryDb.CountryCode = country.CountryCode;    
            //_context.Countries.Update(country);
            //_context.SaveChanges();   
            await _coutryRepository.Update(country);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id) 
        {
            //var country = _context.Countries.Find(id);
            if (id == 0)
            {
                return BadRequest();
            }
            var country =await _coutryRepository.GetCountryById(id);  

            if(country == null)
            {
                return NotFound();
            }
            await _coutryRepository.Delete(country);
            //_context.SaveChanges();
            return Ok();
        }
        
    }
}
