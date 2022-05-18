using BandAPI.DBContexts;
using BandAPI.Helper;
using BandAPI.Helpers;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly BandAlbumContext _context;

        public AlbumRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAlbum(Guid bandId, Album album)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            if (album == null)
                throw new ArgumentNullException(nameof(album));
            album.BandId = bandId;
            _context.Albums.Add(album);
        }

        public bool AlbumExists(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));
            return _context.Albums.Any(a => a.Id == Id);
        }

        public void DeleteAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));
            _context.Albums.Remove(album);
        }

        public Album GetAlbum(Guid bandId, Guid Id)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));
            return _context.Albums.Where(a => a.BandId == bandId && a.Id == Id).FirstOrDefault();
        }
        public PagedList<Album> GetAlbums(Guid bandId,Paged paged)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            var a = _context.Albums.Where(a => a.BandId == bandId)
                                  .OrderBy(a => a.Title) as IQueryable<Album>;
            return PagedList<Album>.Create(a, paged.Page, paged.Size);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}
