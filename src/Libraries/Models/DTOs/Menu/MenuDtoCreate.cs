using System;
using System.Collections.Generic;
using Models.DbEntities;

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
}
