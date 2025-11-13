using VMT.TechnicalTest.Common.Helpers.Models;

namespace VMT.TechnicalTest.Application.Contracts.CSV
{
    public interface IExportCSVProvider
    {
        Task<ApiResponse<byte[]>> Execute();
    }
}