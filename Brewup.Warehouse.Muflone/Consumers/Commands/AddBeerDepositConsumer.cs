﻿using Brewup.Warehouse.Domain.CommandHandlers;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.InMemory.Consumers;

namespace Brewup.Warehouse.Muflone.Consumers.Commands;

public sealed class AddBeerDepositConsumer : CommandConsumerBase<AddBeerDeposit>
{
	protected override ICommandHandlerAsync<AddBeerDeposit> HandlerAsync { get; }

	public AddBeerDepositConsumer(IRepository repository,
		ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		HandlerAsync = new AddBeerDepositCommandHandler(repository, loggerFactory);
	}
}