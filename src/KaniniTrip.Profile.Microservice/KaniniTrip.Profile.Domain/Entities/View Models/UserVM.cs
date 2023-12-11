using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Profile.Domain.Entities.View_Models
{
    public class UserVM
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? UserImage { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
