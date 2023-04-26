using Brewup.Warehouse.Domain.CommandHandlers;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.InMemory.Consumers;

namespace Brewup.Infrastructure.Muflone.Consumers.Commands;

public sealed class CreateWarehouseConsumer : CommandConsumerBase<CreateWarehouse>
{
	protected override ICommandHandlerAsync<CreateWarehouse> HandlerAsync { get; }

	public CreateWarehouseConsumer(IRepository repository,
		ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		HandlerAsync = new CreateWarehouseCommandHandler(repository, loggerFactory);
	}
}