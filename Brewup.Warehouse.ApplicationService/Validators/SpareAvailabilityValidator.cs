using Brewup.Warehouse.Shared.Dtos;
using FluentValidation;

namespace Brewup.Warehouse.ApplicationService.Validators;

public class SpareAvailabilityValidator : AbstractValidator<SpareAvailabilityJson>
{
	public SpareAvailabilityValidator()
	{
		RuleFor(v => v.SpareId).NotEmpty();
	}
}