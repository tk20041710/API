using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
   public  class Album
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }


        [MaxLength(400)]
        public string Description { get; set; }

        [ForeignKey("BandId")]

        public Guid BandId { get; set; }
    }
}
