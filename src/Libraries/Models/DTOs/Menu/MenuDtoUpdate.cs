namespace Models.DTOs.Menu
{
    public class MenuDtoUpdate
    {
        // public ICollection<string> MenuRoles { get; set; } = new List<string>();

        public string Path { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int IconType { get; set; }

        public bool IsActive { get; set; } = true;

        public int Id { get; set; }
    }
}
