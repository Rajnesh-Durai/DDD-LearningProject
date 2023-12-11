using KaniniTrip.Package.Domain.Entities.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Package.Domain.Interfaces.Repository
{
    public interface IPackageRepository
    {
        Task<List<PackageVM>> GetPackageDetails();
    }
}
