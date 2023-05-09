

namespace Models.DTOs.Customer
{
    public class CustomerDto : BaseDto
    {
        public string Note { get; set; }

        public string Name { get; set; }

        public string ColorCode { get; set; }
    }

    public class CustomerDtoCreate
    {
        public string Note { get; set; }

        public string Name { get; set; }

        public string ColorCode { get; set; }
    }

    public class CustomerDtoUpdate : BaseDto
    {
        public string Note { get; set; }

        public string Name { get; set; }

        public string ColorCode { get; set; }
    }

}