using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaniniTrip.Package.Domain.Entities.View_Models;
using KaniniTrip.Package.Domain.Exception;
using KaniniTrip.Package.Domain.Interfaces.Repository;
using KaniniTrip.Package.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace KaniniTrip.Package.Infrastructure.Repository
{
    public class PackageRepository: IPackageRepository
    {
        #region Properties
        private readonly KaniniTripDbContext _context;
        #endregion
        #region Constructors
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="profileRepository"></param>
        public PackageRepository(KaniniTripDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Get Particular Package Details Service
        /// <summary>
        /// Retrieves a particular profile details
        /// </summary>
        /// <returns>A Particular Profile Details.</returns>
        public async Task<List<PackageVM>> GetPackageDetails()
        {
            try
            {
                var packageGroups = _context.PackageDetails.GroupBy(p => p.PlaceId, (key, group) => new { PlaceId = key, MinimumPrice = group.Min(p => p.PricePerPerson) });

                var items = await (from place in _context.Places
                                   join packageGroup in packageGroups on place.Id equals packageGroup.PlaceId into packagesForPlace
                                   from package in packagesForPlace.DefaultIfEmpty()
                                   select new PackageVM()
                                   {
                                       Id = place.Id,
                                       Image=place.ImageName,
                                       MinimumPrice = package.MinimumPrice,
                                       PlaceName = place.PlaceName

                                   }).ToListAsync();
                return items ?? throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            catch (Exception ex) { Console.WriteLine(ex); return new List<PackageVM>(); }
        }
        #endregion
    }
}
