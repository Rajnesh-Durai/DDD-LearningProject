

using KaniniTrip.Package.Domain.Entities.View_Models;

namespace KaniniTrip.Package.Domain.Interfaces.Services
{
    public interface IPackageService
    {
        Task<List<PackageVM>> GetPackageDetails();
    }
}
