using System;
using System.Collections.Generic;

namespace Models.DbEntities.RouteBus;

public class Route : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }

    public List<RouteStop> RouteStops { get; set; }

    public List<RouteVehicle> RouteVehicles { get; set; }

    public List<RouteSchedule> RouteSchedules { get; set; }

    public string TransportationType { get; set; }

    public decimal BaseFare { get; set; }

    public int Code { get; set; }

    public int Distance { get; set; }

    public string TimeSlot { get; set; }


}
public class RouteSchedule : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int RouteId { get; set; }
    public Route Route { get; set; }

}