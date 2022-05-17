using AutoMapper;
using BandAPI.Helper;
using BandAPI.Helpers;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BandAPI.Controllers
{
    [Route("api/v1/bandcollections")]
    public class BandCollectionController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

        public BandCollectionController(IBandRepository bandRepository, IMapper mapper)
        {
            _bandRepository = bandRepository ??
          throw new ArgumentNullException(nameof(bandRepository));
            _mapper = mapper ??
         throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("({ids})", Name = "GetBandCollection")]
        public IActionResult GetBandCollection([FromRoute]
               [ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids,[FromQuery] Page page)
        {
            if (ids == null)
                return BadRequest();

            var bandEntities = _bandRepository.GetBands(ids,page);

            if (ids.Count() != bandEntities.Count())
                return NotFound();

            var bandsToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);

            return Ok(bandsToReturn);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bandCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody] IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<DomainModel.Band>>(bandCollection);

            foreach (var band in bandEntities)
            {
                _bandRepository.AddBand(band);
            }

            _bandRepository.Save();
            var bandCollectionToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);
            var IdsString = string.Join(",", bandCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBandCollection", new { ids = IdsString }, bandCollectionToReturn);
        }
    }
}
