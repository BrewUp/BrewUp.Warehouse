using Muflone.Core;

namespace Brewup.Warehouse.Shared.CustomTypes;

public class SpareId : DomainId
{
	public SpareId(Guid value) : base(value)
	{
	}
}