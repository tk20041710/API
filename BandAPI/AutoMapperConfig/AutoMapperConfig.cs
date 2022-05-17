using AutoMapper;
using BandAPI.Helper;
using BandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.AutoMapperConfig
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            #region Album
            CreateMap<DomainModel.Album, Models.AlbumDto>().ReverseMap();
            CreateMap<AlbumForCreatingDto, DomainModel.Album>().ReverseMap();
            #endregion


            #region Band
            CreateMap<DomainModel.Band, Models.BandDto>()
                .ForMember(
                    dest => dest.FoundedYearsAgo,
                    opt => opt.MapFrom(src => $"{src.Founded.ToString("yyyy")} ({src.Founded.GetYearsAgo()}) years ago"));
            CreateMap<Models.BandForCreatingDto, DomainModel.Band>();
            #endregion


        }
    }
}
