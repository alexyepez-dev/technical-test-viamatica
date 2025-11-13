using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using VMT.TechnicalTest.Application.Contracts.CSV;
using VMT.TechnicalTest.Common.Helpers.Models;
using VMT.TechnicalTest.Persistence.Context;

namespace VMT.TechnicalTest.Application.Providers.Manager.CSV
{
    public class ExportCSVProvider
    (
        AppDbContext context,
        ILogger<ExportCSVProvider> logger
    ) : IExportCSVProvider
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger<ExportCSVProvider> _logger = logger;

        public async Task<ApiResponse<byte[]>> Execute()
        {
            try
            {
                _logger.LogInformation("Starting CSV generation.");
                var users = await _context.Users.ToListAsync();

                if (users is null ||users.Count == 0)
                {
                    _logger.LogWarning("No users were found to export.");
                    return new ApiResponse<byte[]>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "No users were found to export.",
                        Data = null
                    };
                }

                var builder = new StringBuilder();
                builder.AppendLine("Username");

                users.ForEach(res => builder.AppendLine($"{res.Username}"));

                var preamble = Encoding.UTF8.GetPreamble();
                var bytes = Encoding.UTF8.GetBytes(builder.ToString());
                var result = preamble.Concat(bytes).ToArray();

                _logger.LogInformation("CSV successfully generated with {count} users", users.Count);

                return new ApiResponse<byte[]>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "CSV generated successfully.",
                    Data = result
                };
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Error generating CSV.");
                return new ApiResponse<byte[]>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error al generar CSV: {error.Message}",
                    Data = null
                };
            }
        }
    }
}