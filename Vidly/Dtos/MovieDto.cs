﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

       
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}