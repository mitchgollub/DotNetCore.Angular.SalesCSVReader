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
    public class AssetsUnderManagementController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IReportCalculationService _reportCalculationService;

        public AssetsUnderManagementController(ITransactionRepository transactionRepository, IReportCalculationService reportCalculationService)
        {
            _transactionRepository = transactionRepository;
            _reportCalculationService = reportCalculationService;
        }

        [HttpGet()]
        public IActionResult GetAssetSummaries()
        {
            List<Transaction> transactions = _transactionRepository.Get();
            var assetSummaries = new List<AssetUnderManagement>();
            _reportCalculationService.Calculate(assetSummaries, transactions);
            return Ok(assetSummaries);
        }
    }
}
