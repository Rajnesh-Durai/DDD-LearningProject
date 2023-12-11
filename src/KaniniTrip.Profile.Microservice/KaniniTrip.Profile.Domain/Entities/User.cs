using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaniniTrip.Profile.Domain.Helper;
using Microsoft.AspNetCore.Http;

namespace KaniniTrip.Profile.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Id { get; set; }

        [StringLength(20, ErrorMessage = "First Name cannot exceed 20 characters.")]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(20, ErrorMessage = "Last Name cannot exceed 20 characters.")]
        public string LastName { get; set; } = string.Empty;
        public string? UserImage { get; set; }

        [NotMapped]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? ImageFileFormat { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public string Gender { get; set; } = string.Empty;

        [StringLength(15, ErrorMessage = "Role cannot exceed 15 characters.")]
        public string Role { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 6, ErrorMessage = "PhoneNumber must be between 6 and 10 digits.")]
        public string? PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        public byte[]? Hashkey { get; set; }

        public byte[]? Password { get; set; }
        public string? Email { get; set; }
    }
}
