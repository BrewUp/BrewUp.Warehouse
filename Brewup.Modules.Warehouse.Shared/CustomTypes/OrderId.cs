using Muflone.Core;

namespace Brewup.Modules.Warehouse.Shared.CustomTypes;

public sealed class OrderId : DomainId
{
	public OrderId(Guid value) : base(value)
	{
	}
}