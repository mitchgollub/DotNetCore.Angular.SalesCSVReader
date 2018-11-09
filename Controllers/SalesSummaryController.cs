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
        private readonly IReportCalculationService _reportCalculationService;

        public SalesSummaryController(ITransactionRepository transactionRepository, IReportCalculationService reportCalculationService)
        {
            _transactionRepository = transactionRepository;
            _reportCalculationService = reportCalculationService;
        }

        [HttpGet()]
        public IActionResult GetSalesSummaries()
        {
            List<Transaction> transactions = _transactionRepository.Get();
            var salesSummaries = new List<SalesSummary>();
            _reportCalculationService.Calculate(salesSummaries, transactions);
            return Ok(salesSummaries);
        }
    }
}
