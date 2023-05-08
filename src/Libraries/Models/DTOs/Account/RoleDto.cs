using System.Collections.Generic;
using Models.DTOs.Menu;

namespace Models.DTOs.Account
{
    public class RoleDto
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<MenuRoleDto> MenuRoleDtos { get; set; }

    }








}