﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaniniTrip.Package.Domain.Helper;

namespace KaniniTrip.Package.Domain.Entities
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The PlaceName field is required.")]
        [StringLength(20, ErrorMessage = "The PlaceName must be at most 20 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The PlaceName must contain only alphabets.")]
        public string? PlaceName { get; set; }

        [StringLength(100, ErrorMessage = "The ImageName must be at most 100 characters long.")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? PlaceImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        public ICollection<PackageDetails>? Packages { get; set; }
    }
}
