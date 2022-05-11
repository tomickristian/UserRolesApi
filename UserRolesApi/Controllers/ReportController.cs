using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserRolesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportController : ControllerBase
    {

        private IJsReportMVCService _renderService;

        public ReportController(IJsReportMVCService renderService)
        {
            _renderService = renderService;
        }

        
        [HttpGet("UserRolesHtml")]
        public async Task<IActionResult> UserRolesHtml()
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("UserRolesReport", null);
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("TvPostajeXlsx")]
        public async Task<IActionResult> TvPostajeXlsx()
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("htmlToXlsx", null);
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
