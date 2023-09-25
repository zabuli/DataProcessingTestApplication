using DataProcessingApplication.Helpers;
using DataProcessingApplication.Models;
using Interfaces.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataProcessingApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IndicatorController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        private readonly IUserService _userService;

        public IndicatorController(IIndicatorService indicatorService, IUserService userService)
		{
            _indicatorService = indicatorService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Get(string name)
        {
            try
            {
                var user = _userService.GetUser(RequestHelper.GetToken(Request));
                if (user == null)
                {
                    return BadRequest("Token is not valid, please log-in again.");
                }

                var indicators = _indicatorService.GetIndicators(name, user.Id);
                return Ok(indicators);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong. " + ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Post(IndicatorModel indicator)
        {
            try
            {
                var user = _userService.GetUser(RequestHelper.GetToken(Request));
                if (user == null)
                {
                    return BadRequest("Token is not valid, please log-in again.");
                }

                var result = _indicatorService.StoreIndicator(ModelMapperHelper.GetIndicator(indicator, user.Id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. " + ex.Message);
            }
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Put(IndicatorModel indicator)
        {
            try
            {
                var user = _userService.GetUser(RequestHelper.GetToken(Request));
                if (user == null)
                {
                    return BadRequest("Token is not valid, please log-in again.");
                }

                var result = _indicatorService.StoreIndicator(ModelMapperHelper.GetIndicator(indicator, user.Id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. " + ex.Message);
            }
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Patch()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Delete()
        {
            return Ok();
        }
    }
}