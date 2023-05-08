using System.Collections.Generic;

namespace Models.DbEntities.RouteBus;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    public List<OrganizationUser> OrganizationUsers { get; set; }

    public string PhoneNumber { get; set; }

    public string TaxCode { get; set; }

    public string Avatar { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; }

    public string Introduction { get; set; }

    public string WebSiteAddress { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}

public class OrganizationUser : BaseEntity
{
    public int UserId { get; set; }
    public Organization Organization { get; set; }
    public int OrganizationId { get; set; }
}

public class UserInfo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}