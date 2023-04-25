namespace Identity.Models
{
    public class ApplicationMenuRole{
    
        public int MenuId { get; set; }
    
        public ApplicationMenu Menu { get; set; }
    
        public int RoleId { get; set; }
    
        public ApplicationRole Role { get; set; }
    }
}
