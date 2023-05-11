﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Gateway.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCP.Gateway.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmsReminderController : ControllerBase
    {
        private readonly ISmsReminderRepository _smsReminderRepository;

        public SmsReminderController(ISmsReminderRepository smsReminderRepository)
        {
            _smsReminderRepository = smsReminderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSmsReminderSchedule()
        {
            var ds = await _smsReminderRepository.GetSmsReminderSchedule();
            return Ok(ds);
        }
    }
}