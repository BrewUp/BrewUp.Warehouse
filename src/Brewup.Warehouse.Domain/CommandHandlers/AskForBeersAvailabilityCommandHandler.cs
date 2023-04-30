using Brewup.Warehouse.Domain.Abstracts;
using Brewup.Warehouse.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace Brewup.Warehouse.Domain.CommandHandlers;

public sealed class AskForBeersAvailabilityCommandHandler : CommandHandlerAsync<AskForBeersAvailability>
{
	public AskForBeersAvailabilityCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task HandleAsync(AskForBeersAvailability command, CancellationToken cancellationToken = new())
	{
		try
		{
			var warehouse = await Repository.GetByIdAsync<Entities.Warehouse>(command.WarehouseId.Value);
			warehouse.AskForBeersAvailability(command.Beers, command.MessageId);
			await Repository.SaveAsync(warehouse, Guid.NewGuid());
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}
}