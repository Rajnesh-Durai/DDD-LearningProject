using KaniniTrip.Profile.Domain.Entities;
using KaniniTrip.Profile.Domain.Entities.View_Models;

namespace KaniniTrip.Profile.Domain.Interfaces.Services
{
    public interface IProfileService
    {
        Task<UserVM> GetProfileDetails(string id);
    }
}
