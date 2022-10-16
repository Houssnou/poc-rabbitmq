using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POC.Banking.Core.Commands;
using POC.Banking.Core.Events;
using POC.Core.Bus;

namespace POC.Banking.Core.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<NewTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(NewTransferCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return true;
        }
    }
}
