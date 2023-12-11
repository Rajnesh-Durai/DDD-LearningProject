using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Package.Domain.Entities.View_Models
{
    public class PackageVM
    {
        public int Id { get; set; }
        public string? PlaceName { get; set; }
        public int? MinimumPrice { get; set; }
        public string? Image { get; set; }
    }
}
