using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Package.Domain.Entities
{
    public class PackageDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The PlaceId field is required.")]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "The PackageName field is required.")]
        [StringLength(30, ErrorMessage = "The PackageName must be at most 30 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The PackageName must contain only alphabets.")]
        public string PackageName { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "The Days field must be greater than 0.")]
        public int Days { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The PricePerPerson field must be greater than 0.")]
        public int PricePerPerson { get; set; }

        [StringLength(50, ErrorMessage = "The Food must be at most 50 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The FoodName must contain only alphabets.")]
        public string? Food { get; set; }
    }
}
