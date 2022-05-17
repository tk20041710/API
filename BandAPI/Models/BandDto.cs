
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
    public class BandDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name needs to be filled in")]
        [MaxLength(100, ErrorMessage = "Name needs to be up to 100 characters")]
        public string Name { get; set; }

        public string FoundedYearsAgo { get; set; }
        [Required(ErrorMessage = "MainGenre needs to be filled in")]
        [MaxLength(50, ErrorMessage = "MainGenre needs to be up to 200 characters")]
        public string MainGenre { get; set; }

    }


    public class BandsResourceParameters
    {
        public string MainGenre { get; set; }
        public string SearchQuery { get; set; }
    }

 
    public class BandForCreatingDto
    {
        [Required(ErrorMessage = "Name needs to be filled in")]
        [MaxLength(100, ErrorMessage = "Name needs to be up to 100 characters")]
        public string Name { get; set; }

        [Required]
        public DateTime Founded { get; set; }

        [Required(ErrorMessage = "MainGenre needs to be filled in")]
        [MaxLength(50, ErrorMessage = "MainGenre needs to be up to 200 characters")]
        public string MainGenre { get; set; }

        public ICollection<AlbumForCreatingDto> Albums { get; set; } = new List<AlbumForCreatingDto>();
    }

}
