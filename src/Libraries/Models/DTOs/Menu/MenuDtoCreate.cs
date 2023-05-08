namespace Models.DTOs.Menu
{
    public class MenuDtoCreate
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ParrentId { get; set; }



    }

    public class MenuRoleDto
    {
        public int MenuId { get; set; }

        //   public ApplicationMenu Menu { get; set; }

        public int RoleId { get; set; }

        //    public ApplicationRole Role { get; set; }
    }
}
