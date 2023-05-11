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
    public class ApplicationRulesController : ControllerBase
    {
        private readonly IApplicationRulesRepository _applicationRulesRepository;

        public ApplicationRulesController(IApplicationRulesRepository applicationRulesRepository)
        {
            _applicationRulesRepository = applicationRulesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationRuleStatusByID(int processID, int ruleID)
        {
            var ds = await _applicationRulesRepository.GetApplicationRuleStatusByID(processID, ruleID);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationRuleListByProcesssID(int processID)
        {
            var ds = await _applicationRulesRepository.GetApplicationRuleListByProcesssID(processID);
            return Ok(ds);
        }
    }
}