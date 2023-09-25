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
    public class DataController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        private readonly ISymbolService _symbolService;
        private readonly IQueryService _queryService;

        public DataController(IIndicatorService indicatorService, ISymbolService symbolService, IQueryService queryService)
        {
            _indicatorService = indicatorService;
            _symbolService = symbolService;
            _queryService = queryService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ImportSymbolData([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("File is mandatory.");
            }

            try
            {
                bool isFileValid;
                using (var fileStream = file.OpenReadStream())
                {
                    isFileValid = _symbolService.ImportSymbolData(fileStream);
                }

                if (isFileValid)
                {
                    return Ok("File was imported successfully.");
                }

                return BadRequest("Something went wrong.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. " + ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ImportIndicators([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("File is mandatory.");
            }

            try
            {
                bool isFileValid;
                using (var fileStream = file.OpenReadStream())
                {
                    isFileValid = _indicatorService.ImportIndicators(fileStream);
                }

                if (isFileValid)
                {
                    return Ok("File was imported successfully.");
                }

                return BadRequest("Something went wrong.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. " + ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ContentResult Query(QueryModel query)
        {
            try
            {
                var result = _queryService.ExecuteQuery(ModelMapperHelper.GetQuery(query));
                if (result == null)
                {
                    return base.Content(HtmlHelper.GetErrorHtml("Something went wrong, no result from execution."), "text/html");
                }

                return base.Content(HtmlHelper.GetQueryHtml(result), "text/html");
            }
            catch(Exception ex)
            {
                return base.Content(HtmlHelper.GetErrorHtml("Something went wrong. " + ex.Message), "text/html");
            }
        }
    }
}