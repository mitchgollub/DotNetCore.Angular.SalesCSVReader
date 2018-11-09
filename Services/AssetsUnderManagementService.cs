using System.Collections.Generic;
using System.Linq;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Services
{
    public class AssetsUnderManagementService : IAssetsUnderManagementService
    {
        public List<AssetUnderManagement> Calculate(List<Transaction> transactions)
        {
            List<AssetUnderManagement> assetSummaries = new List<AssetUnderManagement>();
            var salesReps = transactions.Select(x => x.SalesRep).Distinct();

            foreach (var salesRep in salesReps)
            {
                var summary = new AssetUnderManagement { SalesRep = salesRep };

                summary.AssetAmount = transactions.Where(x => x.SalesRep == salesRep)
                                        .Select(x => x.Price)
                                        .Sum();

                assetSummaries.Add(summary);
            }

            return assetSummaries;
        }
    }
}