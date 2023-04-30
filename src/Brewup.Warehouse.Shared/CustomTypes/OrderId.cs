using Muflone.Core;

namespace Brewup.Warehouse.Shared.CustomTypes;

public sealed class OrderId : DomainId
{
	public OrderId(Guid value) : base(value)
	{
	}
}