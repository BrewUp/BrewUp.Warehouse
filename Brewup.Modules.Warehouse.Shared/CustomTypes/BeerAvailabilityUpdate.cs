namespace Brewup.Modules.Warehouse.Shared.CustomTypes;

public record BeerAvailabilityUpdated(BeerId BeerId,
	BeerName BeerName,
	MovementQuantity MovementQuantity,
	Stock Stock,
	Availability Availability,
	ProductionCommitted ProductionCommitted,
	SalesCommitted SalesCommitted,
	SupplierOrdered SupplierOrdered);