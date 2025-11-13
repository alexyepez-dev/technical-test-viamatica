using Microsoft.AspNetCore.Mvc;
using VMT.TechnicalTest.Application.Contracts.CSV;
using System.Net;

namespace VMT.TechnicalTest.Api.Controllers.Manager
{
    [ApiController]
    [Route("api/manager")]
    public class ManagerController
    (
        ILogger<ManagerController> logger
    ) : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger = logger;

        [HttpGet("export-csv")]
        public async Task<ActionResult> ExportCSV
        (
            [FromServices] IExportCSVProvider provider
        )
        {
            _logger.LogInformation("Request to export CSV received.");
            var result = await provider.Execute();
            var type = "text/csv";
            var file = "users.csv";
            var csv = result.Data;
            var statusCode = result.StatusCode;

            if (statusCode != HttpStatusCode.OK) return StatusCode
            (
                (int)statusCode, result
            );
            
            return File(csv, type, file);
        }
    }
}