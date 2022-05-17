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
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;


        public BandsController(IAlbumRepository albumRepository, IBandRepository bandRepository,IMapper mapper)
        {
            _albumRepository = albumRepository ??
        throw new ArgumentNullException(nameof(albumRepository));
            _bandRepository = bandRepository ??
          throw new ArgumentNullException(nameof(bandRepository));
            _mapper = mapper ??
         throw new ArgumentNullException(nameof(mapper));
        }

     

        /// <summary>
        /// Lấy thông tin của band theo bandId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}",Name ="Getband")]

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
        public ActionResult<BandDto> CreatedBand([FromBody] BandForCreatingDto dto)
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
        public ActionResult DeleteBand(Guid Id,[FromQuery] Page page)
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
