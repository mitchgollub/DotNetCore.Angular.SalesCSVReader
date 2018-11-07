using System.IO;
using CsvHelper;
using DotNetCore.Angular.SalesCSVReader.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace DotNetCore.Angular.SalesCSVReader
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
            LoadDataFromCSV();
        }
 
        public DbSet<Transaction> Transactions { get; set; }

        private void LoadDataFromCSV()
        {
            TextReader reader = new StreamReader("Data.csv");
            var csvReader = new CsvReader(reader);
            var records = csvReader.GetRecords<Transaction>();

            this.Transactions.AddRange(records);
            this.SaveChanges();
        }
    }
}