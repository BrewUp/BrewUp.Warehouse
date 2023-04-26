using Brewup.Warehouse.Domain.Abstracts;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace Brewup.Warehouse.Domain.CommandHandlers;

public sealed class WithdrawalFromWarehouseCommandHandler : CommandHandlerAsync<WithdrawalFromWarehouse>
{
	public WithdrawalFromWarehouseCommandHandler(IRepository repository,
		ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task HandleAsync(WithdrawalFromWarehouse command, CancellationToken cancellationToken = new())
	{
		try
		{
			var aggregate = await Repository.GetByIdAsync<Entities.Warehouse>(command.WarehouseId.Value);
			aggregate.WithdrawnFromWarehouse(command.Beers, command.MessageId);

			await Repository.SaveAsync(aggregate, Guid.NewGuid());
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}
}