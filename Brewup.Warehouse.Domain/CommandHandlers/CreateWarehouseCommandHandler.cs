using Brewup.Warehouse.Domain.Abstracts;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace Brewup.Warehouse.Domain.CommandHandlers;

public sealed class CreateWarehouseCommandHandler : CommandHandlerAsync<CreateWarehouse>
{
	public CreateWarehouseCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task HandleAsync(CreateWarehouse command, CancellationToken cancellationToken = new())
	{
		try
		{
			var warehouse = Entities.Warehouse.CreateWarehouse(command.WarehouseId, command.WarehouseName);
			await Repository.SaveAsync(warehouse, Guid.NewGuid());
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}
}