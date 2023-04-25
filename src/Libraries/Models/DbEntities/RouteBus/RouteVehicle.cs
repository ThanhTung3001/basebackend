using System;

namespace Models.DbEntities.RouteBus;

public class RouteVehicle:BaseEntity
{

    public int RouteId { get; set; }
    public Route Route { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }

}