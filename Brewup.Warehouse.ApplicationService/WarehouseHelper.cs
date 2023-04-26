using Brewup.Warehouse.ApplicationService.Abstracts;
using Brewup.Warehouse.ApplicationService.Concretes;
using Brewup.Warehouse.ApplicationService.EventsHandler;
using Brewup.Warehouse.ApplicationService.Validators;
using Brewup.Warehouse.Shared.DomainEvents;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Messages.Events;

namespace Brewup.Warehouse.ApplicationService;

public static class WarehouseHelper
{
	public static IServiceCollection AddWarehouseModule(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<SpareAvailabilityValidator>();

		services.AddScoped<IWarehouseService, WarehouseService>();
		services.AddScoped<ISparesAvailabilityService, SparesAvailabilityService>();
		services.AddScoped<IBeerService, BeerService>();
		services.AddScoped<IWarehouseOrchestrator, WarehouseOrchestrator>();

		services.AddScoped<IDomainEventHandlerAsync<WarehouseCreated>, WarehouseCreatedEventHandler>();
		services.AddScoped<IDomainEventHandlerAsync<BeerDepositAdded>, BeerDepositAddedForBeerCreatedEventHandler>();
		services.AddScoped<IDomainEventHandlerAsync<BeerWithdrawn>, BeerWithdrawnEventHandler>();

		return services;
	}
}