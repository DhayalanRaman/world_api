namespace World.Api.StudyFold
{
    public class Study
    {
    }
}
//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using World.Api.Data;
//using World.Api.DTO.Country;
//using World.Api.Modals;

//namespace World.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountryController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public CountryController(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public ActionResult<IEnumerable<GetCountriesDto>> GetAll()
//        {
//            var countries = _context.Countries.ToList();
//            var coutriesDto = _mapper.Map<List<GetCountriesDto>>(countries);
//            if(countries == null)
//            {
//               return NoContent();
//            }
//            return Ok(coutriesDto);
//        }
//        [HttpGet("{id:int}")]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public ActionResult<GetCountriesDto> GetCountryById(int id)
//        {
//            var country = _context.Countries.Find(id);
//            var coutryDto = _mapper.Map<GetCountriesDto>(country);
//            if(country == null)
//            {
//                return NoContent();
//            }
//            return Ok(coutryDto);
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status409Conflict)]
//        public ActionResult<Country> Create([FromBody]CreateCountryDto countryDto)
//        {
//            var result = _context.Countries.AsQueryable().Where(x=> x.Name.ToLower().Trim() == countryDto.Name.ToLower().Trim()).Any();
//            if(result)
//            {
//                return Conflict("record already exist");
//            }
//            var country = _mapper.Map<Country>(countryDto);
//            //var country = new Country();
//            //country.Name = countryDto.Name; 
//            //country.ShortName = countryDto.ShortName;
//            //country.CountryCode= countryDto.CountryCode;    
//            _context.Countries.Add(country);
//            _context.SaveChanges();
//            return CreatedAtAction("GetById", new {id = country.Id}, country);
//        }
//        [HttpPut("{id:int}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<Country> Update(int id, [FromBody] UpdateCountriesDto updateCoutriesDto)
//        {
//            if(updateCoutriesDto == null || id != updateCoutriesDto.Id)
//            {
//                return BadRequest();
//            }
           
//            //var countryDb = _context.Countries.Find(id);
//            //if (countryDb == null)
//            //{
//            //    return NotFound();
//            //}
//            var country = _mapper.Map<Country>(updateCoutriesDto);
//            //countryDb.Name = country.Name;
//            //countryDb.ShortName = country.ShortName;
//            //countryDb.CountryCode = country.CountryCode;    
//            _context.Countries.Update(country);
//            _context.SaveChanges();   
//            return Ok();
//        }
//        [HttpDelete("{id:int}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public ActionResult<Country> DeleteById(int id) 
//        {
//            var country = _context.Countries.Find(id);
//            if (id == 0)
//            {
//                return BadRequest();
//            }
//            if(country == null)
//            {
//                return NotFound();
//            }
//            _context.Countries.Remove(country);
//            _context.SaveChanges();
//            return Ok();
//        }
        
//    }
//}
