using System;
using System.Collections.Generic;
using Identity.Common.Enum;
using Models.DbEntities;

namespace Identity.Models;

public class ApplicationMenu : BaseEntity
{
    public DateTime ModifierDate { get; set; }
    public ICollection<ApplicationMenuRole> MenuRoles { get; set; } = new List<ApplicationMenuRole>();
    public string Path { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public IconType IconType { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<ApplicationMenu> Children { get; set; } = new List<ApplicationMenu>();
    public int? ParrentId { get; set; }
    public ApplicationMenu Parent { get; set; }
}