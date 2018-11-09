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
        private readonly IAssetsUnderManagementService _assetsUnderManagementService;

        public AssetsUnderManagementController(ITransactionRepository transactionRepository, IAssetsUnderManagementService assetsUnderManagementService)
        {
            _transactionRepository = transactionRepository;
            _assetsUnderManagementService = assetsUnderManagementService;
        }

        [HttpGet()]
        public IActionResult GetAssetSummaries()
        {
            List<Transaction> transactions = _transactionRepository.Get();
            var assetSummaries = _assetsUnderManagementService.Calculate(transactions);
            return Ok(assetSummaries);
        }
    }
}
