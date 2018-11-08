using System.Collections.Generic;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Services
{
    public interface ISalesSummaryService
    {
        List<SalesSummary> Calculate(List<Transaction> transactions);
    }
}