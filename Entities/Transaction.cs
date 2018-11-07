using System;

namespace DotNetCore.Angular.SalesCSVReader.Entities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public decimal Shares { get; set; }
        public decimal Price { get; set; }
        public string Fund { get; set; }
        public string Investor { get; set; }
        public string SalesRep { get; set; }
    }
}