using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaGateway.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaGateway.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocalizationResourceController : ControllerBase
    {
        private readonly ILocalizationRepository _localizationRepository;

        public LocalizationResourceController(ILocalizationRepository localizationRepository)
        {
            _localizationRepository = localizationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocalizationResourceString(string culture, string resourceName)
        {
            
            var ds = await  _localizationRepository.GetLocalizationResourceString(culture, resourceName);
            return Ok(ds);
        }

    }
}