using KaniniTrip.Profile.Domain.Entities.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniTrip.Profile.Domain.Interfaces.Repository
{
    public interface IProfileRepository
    {
        Task<UserVM> GetProfileDetails(string id);
    }
}
