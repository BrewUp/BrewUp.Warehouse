namespace Brewup.Warehouse.Shared.CustomTypes;

public record BeerToDrawn(BeerId BeerId, Quantity Quantity, Stock Stock, Availability Availability);