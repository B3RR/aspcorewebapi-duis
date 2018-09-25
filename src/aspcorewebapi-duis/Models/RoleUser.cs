using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Models
{

    public class RoleUser
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}