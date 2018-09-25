using System.Collections.Generic;

namespace aspcorewebapi_duis.Models
{
    public class Role
    {
        public Role()
        {
            RoleUsers = new List<RoleUser>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
        public IEnumerable<RoleUser> RoleUsers { get; set; }
    }
}