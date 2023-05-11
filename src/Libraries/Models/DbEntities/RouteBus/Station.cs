using System.Collections.Generic;

namespace Models.DbEntities.RouteBus;

public class Station : BaseEntity
{

    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Addresss { get; set; }
    public string Avatar { get; set; }
    public bool IsActive { get; set; }
    public string Code { get; set; }
    public List<RouteStop> RouteStops { get; set; }

}
