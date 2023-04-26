using Brewup.Warehouse.ReadModel.Abstracts;
using Microsoft.Extensions.Logging;

namespace Brewup.Warehouse.ApplicationService.Abstracts;

public abstract class WarehouseBaseService
{
	protected readonly IPersister Persister;
	protected readonly ILogger Logger;

	protected WarehouseBaseService(ILoggerFactory loggerFactory, IPersister persister)
	{
		Persister = persister ?? throw new ArgumentNullException(nameof(persister));
		Logger = loggerFactory.CreateLogger(GetType());
	}
}