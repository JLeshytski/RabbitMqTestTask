using Microsoft.AspNetCore.Mvc;
using RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction;
using RabbitMqTestTask.WebApi.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace RabbitMqTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService { get; set; }

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionAddRequest transactionAddRequest)
        {
            TransactionAddResponse transactionAddResponse = await _transactionService.AddAsync(transactionAddRequest);

            return Ok(transactionAddResponse);
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] TransactionGetByIdRequest transactionGetByIdRequest)
        {
            TransactionGetResponse transactionGetResponse = await _transactionService.GetByIdAsync(transactionGetByIdRequest);

            return Ok(transactionGetResponse);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllByClient([FromBody] TransactionGetAllByClientRequest transactionGetAllByClientRequest)
        {
            TransactionGetAllResponse transactionGetAllResponse = await _transactionService.GetAllByClientAsync(transactionGetAllByClientRequest);

            return Ok(transactionGetAllResponse);
        }
    }
}