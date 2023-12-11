using KaniniTrip.Package.Application.DTO;
using KaniniTrip.Package.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KaniniTrip.Package.Application.Controllers
{
    [Route("package")]
    [ApiController]
    public class PackageController:ControllerBase
    {
        #region Properties
        private readonly IPackageService _profileService;
        private readonly ILogger<PackageController> _logger;
        #endregion
        #region Constructor
        public PackageController(IPackageService profileService, ILogger<PackageController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }
        #endregion
        #region GetAllPackageDetails
        /// <summary>
        /// request to get the profile details of the particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a response ofparticular profile details</returns>
        [HttpGet("location")]
        public async Task<ActionResult<List<PackageDTO>>> GetProfileDetails()
        {
            _logger.LogInformation("Executing GetProfileDetails with");
            var item = await _profileService.GetPackageDetails();
            _logger.LogInformation("GetHistory returned: {item}", item);
            return Ok(item);
        }
        #endregion
    }
}
