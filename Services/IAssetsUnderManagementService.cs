using System.Collections.Generic;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Services
{
    public interface IAssetsUnderManagementService
    {
        List<AssetUnderManagement> Calculate(List<Transaction> transactions);
    }
}