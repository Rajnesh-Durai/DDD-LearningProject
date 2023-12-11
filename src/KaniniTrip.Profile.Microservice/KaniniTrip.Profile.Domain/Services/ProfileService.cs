using KaniniTrip.Profile.Domain.Entities.View_Models;
using KaniniTrip.Profile.Domain.Exception;
using KaniniTrip.Profile.Domain.Interfaces.Repository;
using KaniniTrip.Profile.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Profile.Domain.Services
{
    public class ProfileService:IProfileService
    {
        #region Properties
        private readonly IProfileRepository _profileRepository;
        #endregion
        #region Constructors
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="profileRepository"></param>
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        #endregion
        #region Get Particular Profile Details Service
        /// <summary>
        /// Retrieves a particular profile details
        /// </summary>
        /// <returns>A Particular Profile Details.</returns>
        public async Task<UserVM> GetProfileDetails(string id)
        {
            try
            {
                var items = await _profileRepository.GetProfileDetails(id);
                return items ?? throw new System.Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            catch (System.Exception ex) { Console.WriteLine(ex); return new UserVM(); }
        }
        #endregion
    }
}
