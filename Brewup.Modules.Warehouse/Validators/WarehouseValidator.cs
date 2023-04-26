using Brewup.Warehouse.Shared.Dtos;
using FluentValidation;

namespace Brewup.Modules.Warehouse.Validators;

public class WarehouseValidator : AbstractValidator<WarehouseJson>
{
	public WarehouseValidator()
	{
		RuleFor(v => v.WarehouseName).NotEmpty();
	}
}