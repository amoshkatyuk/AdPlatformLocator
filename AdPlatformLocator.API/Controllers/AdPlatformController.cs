using AdPlatformLocator.App.Interfaces;
using AdPlatformLocator.App.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdPlatformLocator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdPlatformController : ControllerBase
    {
        private readonly IAdPlatformService _adPlatformService;

        public AdPlatformController(IAdPlatformService adPlatformService)
        {
            _adPlatformService = adPlatformService;
        }

        [HttpPost("load")]
        public async Task<IActionResult> LoadAdPlatforms([FromBody] LoadRequestDto request) 
        {
            try
            {
                await _adPlatformService.LoadAdPlatformsFromFileAsync(request.FilePath);
                return Ok("Data loaded successfully.");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byLocation")]
        public async Task<IActionResult> GetAdPlatformsByLocation(string location)
        {
            try
            {
                var result = await _adPlatformService.GetPlatformsByLocationAsync(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
