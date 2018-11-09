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

            foreach (var salesRep in salesReps)
            {
                var summary = new SalesSummary { SalesRep = salesRep };

                var repTransactions = transactions.Where(x => x.SalesRep == salesRep);

                summary.Y2DSold = repTransactions.Where(x => x.Date >= new DateTime(dateTimeNow.Year, 1, 1))
                                        .Select(x => CalculateTransaction(x))
                                        .Sum();

                summary.M2DSold = repTransactions.Where(x => x.Date >= new DateTime(dateTimeNow.Year, dateTimeNow.Month, 1))
                                        .Select(x => CalculateTransaction(x))
                                        .Sum();

                summary.Q2DSold = repTransactions.Where(x => GetQuarter(x.Date) == GetQuarter(dateTimeNow))
                                        .Select(x => CalculateTransaction(x))
                                        .Sum();

                summary.I2DSold = repTransactions
                                        .Select(x => CalculateTransaction(x))
                                        .Sum();

                salesSummaries.Add(summary);
            }

            return salesSummaries;
        }

        private decimal CalculateTransaction(Transaction transaction) {
            var absoluteValue = transaction.Price * transaction.Shares;

            if (transaction.Type == "SELL") {
                absoluteValue *= -1; 
            }

            return absoluteValue;
        }

        private int GetQuarter(DateTime date)
        {
            if (date.Month >= 1 && date.Month <= 3)
                return 1;
            else if (date.Month >= 4 && date.Month <= 6)
                return 2;
            else if (date.Month >= 7 && date.Month <= 9)
                return 3;
            else
                return 4;
        }
    }
}