using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Angular.SalesCSVReader.Models;
using DotNetCore.Angular.SalesCSVReader.Repositories;
using DotNetCore.Angular.SalesCSVReader.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Angular.SalesCSVReader.Controllers
{
    [Route("api/[controller]")]
    public class SalesSummaryController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ISalesSummaryService _salesSummaryService;

        public SalesSummaryController(ITransactionRepository transactionRepository, ISalesSummaryService salesSummaryService)
        {
            _transactionRepository = transactionRepository;
            _salesSummaryService = salesSummaryService;
        }

        [HttpGet()]
        public IActionResult GetSalesSummaries()
        {
            List<Transaction> transactions = _transactionRepository.Get();
            var salesSummaries = _salesSummaryService.Calculate(transactions);
            return Ok(salesSummaries);
        }
    }
}
