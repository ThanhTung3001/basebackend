using System;
using System.Collections;
using System.Collections.Generic;
using Identity.Common.Enum;
using Models.DbEntities;

namespace Identity.Models;

public class ApplicationMenu:BaseEntity
{
    public DateTime ModifierDate { get; set; }
    
    public string CreateBy { get; set; }
    public ICollection<ApplicationMenuRole> MenuRoles { get; set; } = new List<ApplicationMenuRole>();

    public string Path {get;set;}
    
    public string Name { get; set; }
    
    public string Icon { get; set; }
    
    public IconType IconType { get; set; }

    public bool IsActive { get; set; } = true;
}

public class ApplicationMenuRole{
    
    public int MenuId { get; set; }
    
    public ApplicationMenu Menu { get; set; }
    
    public int RoleId { get; set; }
    
    public ApplicationRole Role { get; set; }
}