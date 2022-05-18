﻿using BandAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
    [TitleAndDescription(ErrorMessage = "Title Must Be Different From Description")]
    public class AlbumDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title needs to be filled in")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters")]
        public string Title { get; set; }

        [MaxLength(400, ErrorMessage = "Description needs to be up to 400 characters")]
        public virtual string Description { get; set; }


        public Guid BandId { get; set; }
    }

    [TitleAndDescription(ErrorMessage = "Title Must Be Different From Description")]
    public class AlbumForCreatingDto
    {

        [Required(ErrorMessage = "Title needs to be filled in")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters")]
        public string Title { get; set; }

        [MaxLength(400, ErrorMessage = "Description needs to be up to 400 characters")]
        public virtual string Description { get; set; }
    }

    [TitleAndDescription(ErrorMessage = "Title Must Be Different From Description")]
    public class AlbumForUpdateDto
    {

        [Required(ErrorMessage = "Title needs to be filled in")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters")]
        public string Title { get; set; }

        [MaxLength(400, ErrorMessage = "Description needs to be up to 400 characters")]
        public virtual string Description { get; set; }
    }
}
