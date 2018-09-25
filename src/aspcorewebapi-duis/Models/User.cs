using System.Collections.Generic;

namespace aspcorewebapi_duis.Models
{
    public class User

    {
        public User()
        {
            RoleUsers = new List<RoleUser>();
        }
        public int ID { get; set; }
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoleUser> RoleUsers { get; set; }

    }
}