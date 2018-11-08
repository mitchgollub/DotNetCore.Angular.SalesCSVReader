using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Services
{
    public class SalesSummaryService : ISalesSummaryService
    {
        public List<SalesSummary> Calculate(List<Transaction> transactions)
        {
            List<SalesSummary> salesSummaries = new List<SalesSummary>();
            var dateTimeNow = DateTime.Now;
            var salesReps = transactions.Select(x => x.SalesRep).Distinct();

            foreach(var salesRep in salesReps) 
            {
                var summary = new SalesSummary { SalesRep = salesRep };

                var repTransactions = transactions.Where(x => x.SalesRep == salesRep);

                summary.Y2DSold = repTransactions.Where(x => x.Date > new DateTime(dateTimeNow.Year, 1, 1))
                                        .Select(x => x.Price)
                                        .Sum();

                summary.M2DSold = repTransactions.Where(x => x.Date > new DateTime(dateTimeNow.Year, dateTimeNow.Month, 1))
                                        .Select(x => x.Price)
                                        .Sum();

                summary.Q2DSold = repTransactions.Where(x => x.Date > new DateTime(dateTimeNow.Year, 1, 1))
                                        .Select(x => x.Price)
                                        .Sum();

                summary.I2DSold = repTransactions
                                        .Select(x => x.Price)
                                        .Sum();

                salesSummaries.Add(summary);
            }

            return salesSummaries;
        }
    }
}