using System;

namespace Models.DTOs.Organization
{
    public class VehicalDto : BaseDto
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }
        // public List<RouteVehicle> RouteVehicles { get; set; }
        public int OrganizationId { get; set; }
        public OrganizationDto Organization { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int TotalMileage { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime InsuranceExpirationDate { get; set; }
        public int RegistrationYear { get; set; }
        public string RegistrationTerm { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string BodyType { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfCirculation { get; set; }
        public int NumberOfSeats { get; set; }
    }

    public class VehicalCreateDto
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }
        // public List<RouteVehicle> RouteVehicles { get; set; }
        public int OrganizationId { get; set; }
        //  public OrganizationDto Organization { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int TotalMileage { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime InsuranceExpirationDate { get; set; }
        public int RegistrationYear { get; set; }
        public string RegistrationTerm { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string BodyType { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfCirculation { get; set; }
        public int NumberOfSeats { get; set; }
    }

    public class VehicalUpdateDto : BaseDto
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }
        // public List<RouteVehicle> RouteVehicles { get; set; }
        public int OrganizationId { get; set; }
        //  public OrganizationDto Organization { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int TotalMileage { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime InsuranceExpirationDate { get; set; }
        public int RegistrationYear { get; set; }
        public string RegistrationTerm { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string BodyType { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfCirculation { get; set; }
        public int NumberOfSeats { get; set; }
    }
}