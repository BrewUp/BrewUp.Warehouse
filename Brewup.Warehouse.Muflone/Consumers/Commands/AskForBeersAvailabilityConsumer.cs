using Brewup.Warehouse.Domain.CommandHandlers;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.InMemory.Consumers;

namespace Brewup.Warehouse.Muflone.Consumers.Commands;

public sealed class AskForBeersAvailabilityConsumer : CommandConsumerBase<AskForBeersAvailability>
{
	protected override ICommandHandlerAsync<AskForBeersAvailability> HandlerAsync { get; }

	public AskForBeersAvailabilityConsumer(IRepository repository, ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		HandlerAsync = new AskForBeersAvailabilityCommandHandler(repository, loggerFactory);
	}
}