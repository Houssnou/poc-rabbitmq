using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POC.Transfer.API.Dtos;
using POC.Transfer.Core.Interfaces;

namespace POC.Transfer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
       
        private readonly ILogger<TransferController> _logger;
        private readonly ITransferService _transferService;
        private readonly IMapper _mapper;

        public TransferController(ILogger<TransferController> logger, ITransferService transferService, IMapper mapper)
        {
            _logger = logger;
            _transferService = transferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TransfertDto>> Get()
        {
            var result = await _transferService.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<TransfertDto>>(result));
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<TransfertDto>> GetById(int id)
        {
            var result = await _transferService.GetByIdAsync(id);

            return Ok(_mapper.Map<TransfertDto>(result));
        }
        [HttpGet("/sender/{id}")]
        public async Task<ActionResult<TransfertDto>> GetBySender(int id)
        {
            var result = await _transferService.GetAllBySenderAsync(id);

            return Ok(_mapper.Map<IReadOnlyList<TransfertDto>>(result));
        }
        [HttpGet("/recipient/{id}")]
        public async Task<ActionResult<TransfertDto>> GetByRecipient(int id)
        {
            var result = await _transferService.GetAllByRecipientAsync(id);

            return Ok(_mapper.Map<IReadOnlyList<TransfertDto>>(result));
        }

    }
}