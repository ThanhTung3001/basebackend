

namespace Models.DTOs.Organization
{
    public class OrganizationDto : BaseDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string TaxCode { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Introduction { get; set; }

        public string WebSiteAddress { get; set; }
    }

    public class OrganizationCreateDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string TaxCode { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Introduction { get; set; }

        public string WebSiteAddress { get; set; }
    }
}