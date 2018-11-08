using System.Collections.Generic;
using DotNetCore.Angular.SalesCSVReader.Models;

namespace DotNetCore.Angular.SalesCSVReader.Repositories
{
    public interface ITransactionRepository
    {
        List<Transaction> Get();
    }
}