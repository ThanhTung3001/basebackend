﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Identity.Common.Enum;
using Models.DTOs.Account;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public AccountType AccountType { get; set; }
        
        public string LastAccessAddress { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
