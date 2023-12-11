using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaniniTrip.Profile.Domain.Entities.View_Models;
using KaniniTrip.Profile.Domain.Exception;
using KaniniTrip.Profile.Domain.Interfaces.Repository;
using KaniniTrip.Profile.Infrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace KaniniTrip.Profile.Infrastructure.Repository
{
    public class ProfileRepository: IProfileRepository
    {
        #region Properties
        private readonly KaniniTripDbContext _context;
        #endregion
        #region Constructors
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="profileRepository"></param>
        public ProfileRepository(KaniniTripDbContext context)
        {
            _context = context;
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
                var items = await (from user in _context.Users
                                   where user.Id == id
                                   select new UserVM()
                                   {
                                       Id = user.Id,
                                       UserName = user.FirstName + " " + user.LastName,
                                       Email=user.Email,
                                       PhoneNumber=user.PhoneNumber,
                                       Address=user.Address,
                                       Gender=user.Gender,
                                       DateOfBirth=user.DateOfBirth,
                                       UserImage=user.UserImage

                                   }).FirstOrDefaultAsync();
                return items ?? throw new Exception(CustomException.ExceptionMessages["CantEmpty"]);
            }
            catch (Exception ex) { Console.WriteLine(ex); return new UserVM(); }
        }
        #endregion

    }
}
