using AutoMapper;
using BandAPI.Helper;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    
    [ApiController]
    [Route("api/v1/bands/{bandId}/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

 
        public AlbumsController(IAlbumRepository albumRepository,
                                            IBandRepository bandRepository,
                                            IMapper mapper)
        {

            _albumRepository = albumRepository ??
          throw new ArgumentNullException(nameof(albumRepository));
            _bandRepository = bandRepository ??
          throw new ArgumentNullException(nameof(bandRepository));
            _mapper = mapper ??
         throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Lấy thuộc tin của tất cả album thuộc bandId
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<AlbumDto>> GetAlbumsForBand(Guid bandId,Page page)
        {
            if (!_bandRepository.BandExists(bandId)) return NotFound();
            var albumFromRepo = _albumRepository.GetAlbums(bandId,page);
            return Ok(_mapper.Map<IEnumerable<AlbumDto>>(albumFromRepo));
        }

        /// <summary>
        /// Lấy thông tin của 1 album
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}", Name = "GetAlbum")]
        public ActionResult<AlbumDto> GetAlbumForBand(Guid bandId, Guid Id)
        {
            if (!_bandRepository.BandExists(bandId)) return NotFound();
            var albumFromRepo = _albumRepository.GetAlbum(bandId, Id);
            if (albumFromRepo == null) return NotFound();
            return Ok(_mapper.Map<AlbumDto>(albumFromRepo));
        }

        /// <summary>
        /// Thêm album
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="albumForCreatingDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AlbumDto> CreateAlbumForBand(Guid bandId, [FromBody] AlbumForCreatingDto albumForCreatingDto)
        {
            if (!_bandRepository.BandExists(bandId)) return NotFound();

            var albumEntity = _mapper.Map<DomainModel.Album>(albumForCreatingDto);
            _albumRepository.AddAlbum(bandId, albumEntity);
            _albumRepository.Save();
            var albumToReturn = _mapper.Map<AlbumDto>(albumEntity);
            return CreatedAtRoute("GetAlbum", new { bandId = albumToReturn.BandId, Id = albumToReturn.Id }, albumToReturn);

        }

        /// <summary>
        /// Sửa Album theo albumId thuộc bandId
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="Id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public ActionResult<AlbumDto> UpdateAlbumForBand (Guid bandId,Guid Id,[FromBody] AlbumForCreatingDto dto)
        {
            if (!_bandRepository.BandExists(bandId)) return NotFound();
            var albumFromRepo = _albumRepository.GetAlbum(bandId, Id);
            if (albumFromRepo == null)
            {
                var albumToAdd = _mapper.Map<DomainModel.Album>(dto);
                albumToAdd.Id = Id;
                _albumRepository.AddAlbum(bandId, albumToAdd);
                _albumRepository.Save();
              return CreatedAtRoute("GetAlbum", new { bandId = albumToAdd.BandId, Id = albumToAdd.Id }, albumToAdd);
            }    

            _mapper.Map(dto, albumFromRepo);
            _albumRepository.Save();
            return AcceptedAtRoute("GetAlbum", new { bandId = albumFromRepo.BandId, Id = albumFromRepo.Id }, albumFromRepo);
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="bandId"></param>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("{Id}")]
        public ActionResult DeleteAlbumForBand(Guid bandId, Guid Id)
        {
            if (!_bandRepository.BandExists(bandId)) return NotFound();
            var albumFromRepo = _albumRepository.GetAlbum(bandId, Id);
            if (albumFromRepo == null) return NotFound();

            _albumRepository.DeleteAlbum(albumFromRepo);
            _albumRepository.Save();
            return Ok();
        }
    }
}
