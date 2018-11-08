using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
            LoadDataFromCSV();
        }

        public List<Transaction> Get()
        {
            return _transactions;
        }

        private void LoadDataFromCSV()
        {
            TextReader reader = new StreamReader("Data.csv");
            var csvReader = new CsvReader(reader);
            csvReader.Configuration.RegisterClassMap<TransactionMap>();
            var records = csvReader.GetRecords<Transaction>().ToArray();
            _transactions.AddRange(records);
        }
    }
}