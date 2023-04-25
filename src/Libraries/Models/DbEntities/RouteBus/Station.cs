using System;
using System.Collections.Generic;

namespace Models.DbEntities.RouteBus;

public class Station:BaseEntity
{
  
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<RouteStop> RouteStops { get; set; }
   
}
