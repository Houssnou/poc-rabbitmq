using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Core.Bus;
using POC.Transfer.Core.Events;
using POC.Transfer.Core.Interfaces.Repositories;

namespace POC.Transfer.Core.EventHandlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _repo;

        public TransferCreatedEventHandler(ITransferRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(TransferCreatedEvent @event)
        {
            var transfert = new Entities.Transfer(@event.From, @event.To, @event.Amount);

            await _repo.SaveTransferAsync(transfert);

            _ = Task.CompletedTask;
        }
    }
}
