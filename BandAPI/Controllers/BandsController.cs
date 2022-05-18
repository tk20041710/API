using AutoMapper;
using BandAPI.Helper;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/v1/bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;

        private readonly IMapper _mapper;
        private readonly IPropertyValidationService _propertyValidationService;

        public BandsController(IBandRepository bandRepository, IMapper mapper,IPropertyValidationService propertyValidationService)
        {

            _bandRepository = bandRepository ??
          throw new ArgumentNullException(nameof(bandRepository));
            _mapper = mapper ??
         throw new ArgumentNullException(nameof(mapper));
            _propertyValidationService = propertyValidationService ??
        throw new ArgumentNullException(nameof(propertyValidationService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bandsResourceParameters"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet(Name="Getbands")]

        public IActionResult GetBands([FromQuery] Models.BandsResourceParameters bandsResourceParameters, [FromQuery] Paged paged)
        {
            if (!_propertyValidationService.HasValidProperties<BandDto>(bandsResourceParameters.Fields))
                return BadRequest("Không tìm thấy");

            var bandFromRepo = _bandRepository.GetBands(bandsResourceParameters, paged);
            return Ok(_mapper.Map<IEnumerable<BandDto>>(bandFromRepo).ShapeData(bandsResourceParameters.Fields));
        }

        /// <summary>
        /// Lấy thông tin của band theo bandId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}", Name = "Getband")]

        public IActionResult GetBand(Guid Id)
        {
            var bandFromRepo = _bandRepository.GetBand(Id);
            if (bandFromRepo == null) return NotFound();
            return Ok(_mapper.Map<BandDto>(bandFromRepo));
        }

        /// <summary>
        /// Thêm 1 Band
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BandDto> CreatedBand([FromBody] BandForUpdateDto dto)
        {
            var bandEntity = _mapper.Map<DomainModel.Band>(dto);
            _bandRepository.AddBand(bandEntity);
            _bandRepository.Save();

            var bandToReturn = _mapper.Map<BandDto>(bandEntity);
            return CreatedAtRoute("GetBand", new { Id = bandToReturn.Id }, bandToReturn);
        }

        /// <summary>
        /// Sửa một Band theo bandId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public ActionResult<BandDto> UpdateBand(Guid Id, [FromBody] BandForCreatingDto dto)
        {
            if (!_bandRepository.BandExists(Id)) return NotFound();

            var bandFromRepo = _bandRepository.GetBand(Id);
            _mapper.Map(dto, bandFromRepo);
            _bandRepository.Save();
            return Ok();
        }

        /// <summary>
        /// Xóa Band
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public ActionResult DeleteBand(Guid Id)
        {
            if (!_bandRepository.BandExists(Id))
                return NotFound();
            var bandFromRepo = _bandRepository.GetBand(Id);

            _bandRepository.DeleteBand(bandFromRepo);


            _bandRepository.Save();

            return Ok();

        }


    }
}
