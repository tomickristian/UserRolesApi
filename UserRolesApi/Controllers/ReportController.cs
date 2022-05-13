using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
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

        [HttpGet("UserRolesReport")]
        public async Task<IActionResult> UserRolesReport()
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("UserRoleReport", null);
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("UserRolesXlsxDownload")]
        public async Task<IActionResult> UserRolesXlsxDownload()
        {
            try
            {
                var report = await _renderService.RenderAsync(new RenderRequest() { Template = new Template()
                {
                    Name = "UserRoleReport",
                    Recipe = Recipe.HtmlToXlsx
                }
                });
                return File(report.Content, "application/octet-stream", "Korisničke uloge.xlsx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
