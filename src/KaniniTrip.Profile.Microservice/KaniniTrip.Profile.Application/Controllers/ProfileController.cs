using KaniniTrip.Profile.Application.DTO;
using KaniniTrip.Profile.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KaniniTrip.Profile.Application.Controllers
{
    [Route("profile")]
    [ApiController]
    public class ProfileController:ControllerBase
    {
        #region Properties
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfileController> _logger;
        #endregion
        #region Constructor
        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }
        #endregion
        #region GetProfileDetails
        /// <summary>
        /// request to get the profile details of the particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a response ofparticular profile details</returns>
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserDTO>> GetProfileDetails(string id)
        {
            _logger.LogInformation("Executing GetProfileDetails with id: {id}", id);
            var item = await _profileService.GetProfileDetails(id);
            _logger.LogInformation("GetHistory returned: {item}", item);
            return Ok(item);
        }
        #endregion
    }
}
