using BandAPI.Helper;
using BandAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace BandAPI.Services
{
    public interface IBandRepository
    {
        Band GetBand(Guid Id);
        PagedList<Band> GetBands(IEnumerable<Guid> Ids,Paged paged);
        PagedList<Band> GetBands(Models.BandsResourceParameters bandsResourceParameters,Paged paged);
        void AddBand(Band band);
        void DeleteBand(Band band);
        
        bool BandExists(Guid Id);
        bool Save();
       
    }
    
}
