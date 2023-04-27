using Brewup.Warehouse.Domain.CommandHandlers;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace Brewup.Warehouse.Muflone.Consumers.Commands;

public sealed class AddBeerDepositConsumer : CommandConsumerBase<AddBeerDeposit>
{
	protected override ICommandHandlerAsync<AddBeerDeposit> HandlerAsync { get; }

	public AddBeerDepositConsumer(IRepository repository,
		AzureServiceBusConfiguration azureServiceBusConfiguration,
		ILoggerFactory loggerFactory,
		ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
	{
		HandlerAsync = new AddBeerDepositCommandHandler(repository, loggerFactory);
	}
}