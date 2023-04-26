namespace Brewup.Warehouse.Shared.Dtos;

public record SpareAvailabilityJson(string SpareId, double Stock, double Availability, double ProductionCommitted, double SalesCommitted, double SupplierOrdered);