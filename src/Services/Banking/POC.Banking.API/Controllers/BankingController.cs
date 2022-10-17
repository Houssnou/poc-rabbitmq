using Microsoft.AspNetCore.Mvc;
using POC.Banking.API.Dtos.Account;
using POC.Banking.Core.Interfaces;

namespace POC.Banking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;

        public BankingController(ILogger<BankingController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> Get()
        {
            return Ok(await _accountService.GetAccounts());
        }

        [HttpPost]
        public async Task<ActionResult> Post(TransfertDto transfertRequest)
        {
            await _accountService.TransfertAsync(transfertRequest.From, transfertRequest.To, transfertRequest.Amount);
            return Ok(transfertRequest);
        }
    }
}