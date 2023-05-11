using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Gateway.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCP.Gateway.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RazorpayClientController : ControllerBase
    {
        private readonly IRazorpayPaymentApi _razorpayPaymentApi;

        public RazorpayClientController(IRazorpayPaymentApi razorpayPaymentApi)
        {
            _razorpayPaymentApi = razorpayPaymentApi;
        }

        [HttpGet]
        public IActionResult FetchOrder(string orderKey)
        {
            var ds = _razorpayPaymentApi.FetchOrder(orderKey);
            return Ok(ds);
        }

    }
}