using System;
using System.Collections.Generic;

namespace Models.DbEntities.RouteBus;

public class RouteStop
{
    public int Id { get; set; }
    public int Sequence { get; set; }
    public int RouteId { get; set; }
    public Route Route { get; set; }
    public int StationId { get; set; }
    public Station Station { get; set; }
    public int StopId { get; set; }
    public Stop Stop { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
public class Stop:BaseEntity
{
 
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<RouteStop> RouteStops { get; set; }
 
}


