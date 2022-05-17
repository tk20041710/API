
using BandAPI.Helper;
using BandAPI.Helpers;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
   public interface IAlbumRepository
    {
        PagedList<Album> GetAlbums(Guid bandId,Page page);
        Album GetAlbum(Guid bandId, Guid Id);
        void AddAlbum(Guid bandId, Album album);
        void DeleteAlbum(Album album);

        bool AlbumExists(Guid Id);
        bool Save();
        
    }
}
