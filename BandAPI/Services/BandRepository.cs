using BandAPI.DBContexts;
using BandAPI.Helper;
using BandAPI.Helpers;
using BandAPI.Models;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class BandRepository : IBandRepository
    {
        private readonly BandAlbumContext _context;

        public BandRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Thêm band
        /// </summary>
        /// <param name="band"></param>
        public void AddBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));
            _context.Bands.Add(band);
        }

        /// <summary>
        /// Kiểm tra band có tồn tại hay không
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool BandExists(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));
           return  _context.Bands.Any(a => a.Id == Id);
        }

        /// <summary>
        /// Xóa band
        /// </summary>
        /// <param name="band"></param>
        public void DeleteBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));
            _context.Bands.Remove(band);
        }

        /// <summary>
        /// Lấy thông tin của một band
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public Band GetBand(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));
            return _context.Bands.Where(a => a.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Lấy thông tin của tất cả các band
        /// </summary>
        /// <returns></returns>
        public PagedList<Band> GetBands(Page page)
        {
            var collection = _context.Bands.ToList() as IQueryable<Band>;

            return PagedList<Band>.Create(collection, page.PageNumber, page.PageSize);
        }

        /// <summary>
        /// Lấy thông tin của nhiều band theo bandIds
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public PagedList<Band> GetBands(IEnumerable<Guid> Ids,Page page)
        {
            if (Ids == null)
                throw new ArgumentNullException(nameof(Ids));
             var collection= _context.Bands.Where(a => Ids.Contains(a.Id))
                                  .OrderBy(a => a.Name) as IQueryable<Band>;
            return PagedList<Band>.Create(collection, page.PageNumber, page.PageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bandDto"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public PagedList<Band> GetBands(Models.BandsResourceParameters bandDto,Page page)
        {
         

            if (bandDto == null)
                throw new ArgumentNullException(nameof(bandDto));

            var collection = _context.Bands as IQueryable<Band>;

            if (!string.IsNullOrWhiteSpace(bandDto.MainGenre))
            {
                var mainGenre = bandDto.MainGenre.Trim();
                collection = collection.Where(b => b.MainGenre.Contains(mainGenre));
            }

            if (!string.IsNullOrWhiteSpace(bandDto.SearchQuery))
            {
                var searchQuery = bandDto.SearchQuery.Trim();
                collection = collection.Where(b => b.Name.Contains(searchQuery));
            }
            return PagedList<Band>.Create(collection, page.PageNumber,page.PageSize);
        }

        /// <summary>
        /// Lưu bạn thông tin
        /// </summary>
        /// <returns></returns>
        public bool Save()  
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}
