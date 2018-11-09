using System.Collections.Generic;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Services
{
    public interface IReportCalculationService
    {
        List<SalesSummary> Calculate(List<SalesSummary> salesSummaries, List<Transaction> transactions);
        List<AssetUnderManagement> Calculate(List<AssetUnderManagement> assetSummaries, List<Transaction> transactions);
    }
}