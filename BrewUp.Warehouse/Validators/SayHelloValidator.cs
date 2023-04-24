using BrewUp.Warehouse.Models;
using FluentValidation;

namespace BrewUp.Warehouse.Validators;

public class SayHelloValidator : AbstractValidator<HelloRequest>
{
	public SayHelloValidator()
	{
		RuleFor(h => h.Name).NotEmpty().MaximumLength(50);
	}
}