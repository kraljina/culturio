using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.CultureObject;
using Span.Culturio.Api.Services.CultureObject;

namespace Span.Culturio.Api.Controllers {
    [Route("api/culture-objects")]
    [ApiController]
    public class CultureObjectController : ControllerBase {
        private readonly IValidator<CreateCultureObjectDto> _validator;
        private readonly ICultureObjectService _cultureObjectService;


        public CultureObjectController(IValidator<CreateCultureObjectDto> validator, ICultureObjectService cultureObjectService) {
            _validator = validator;
            _cultureObjectService = cultureObjectService;
        }


        [HttpPost]
        public async Task<ActionResult<string>> Post(CreateCultureObjectDto req) {
            ValidationResult result = await _validator.ValidateAsync(req);
            if (!result.IsValid) return BadRequest("ValidationError");

            var cultureObjectDto = await _cultureObjectService.CreateCultureObjectAsync(req);

            return Ok("Successful response");

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CultureObjectDto>> Get(int id) {
            var cultureObjectDto = await _cultureObjectService.GetCultureObjectAsync(id);
            if (cultureObjectDto is null) return NotFound("Nema");

            return Ok(cultureObjectDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CultureObjectDto>>> Get() {
            var cultureObjectsDto = await _cultureObjectService.GetCultureObjectsAsync();
            return Ok(cultureObjectsDto);
        }
    }
}
