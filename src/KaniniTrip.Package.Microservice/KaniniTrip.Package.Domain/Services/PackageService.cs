using KaniniTrip.Package.Domain.Entities.View_Models;
using KaniniTrip.Package.Domain.Exception;
using KaniniTrip.Package.Domain.Interfaces.Repository;
using KaniniTrip.Package.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Package.Domain.Services
{
    public class PackageService:IPackageService
    {
        #region Properties
        private readonly IPackageRepository _packageRepository;
        #endregion
        #region Constructors
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="profileRepository"></param>
        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }
        #endregion
        #region Get All Package Details Service
        /// <summary>
        /// Retrieves all package details
        /// </summary>
        /// <returns>A List of Package Details.</returns>
        public async Task<List<PackageVM>> GetPackageDetails()
        {
            try
            {
                var items = await _packageRepository.GetPackageDetails();
                return items ?? throw new System.Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            catch (System.Exception ex) { Console.WriteLine(ex); return new List<PackageVM>(); }
        }
        #endregion
    }
}
