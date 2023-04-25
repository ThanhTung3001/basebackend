using System.Collections.Generic;
using Models.DbEntities;

namespace Models.DTOs.Menu
{
    public class MenuDtoUpdate:BaseEntity
    {
        public ICollection<string> MenuRoles { get; set; } = new List<string>();

        public string Path {get;set;}
    
        public string Name { get; set; }
    
        public string Icon { get; set; }
    
        public int IconType { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
