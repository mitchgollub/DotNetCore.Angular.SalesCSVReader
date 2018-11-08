using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace DotNetCore.Angular.SalesCSVReader.Models
{
    public class Transaction
    {
        public DateTime? Date { get; set; }
        public string Type { get; set; }
        public decimal Shares { get; set; }
        public string Price { get; set; }
        public string Fund { get; set; }
        public string Investor { get; set; }
        public string SalesRep { get; set; }
    }


    public sealed class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.Date).Name("TXN_DATE");
            Map(m => m.Type).Name("TXN_TYPE");
            Map(m => m.Shares).Name("TXN_SHARES");
            Map(m => m.Price).Name("TXN_PRICE");
            Map(m => m.Fund).Name("FUND");
            Map(m => m.Investor).Name("INVESTOR");
            Map(m => m.SalesRep).Name("SALES_REP");
        }
    }
}