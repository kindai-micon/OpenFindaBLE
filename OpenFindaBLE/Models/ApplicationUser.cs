using Microsoft.AspNetCore.Identity;

namespace OpenFindaBLE.Backend.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser() : base()
        {
            Id = Guid.NewGuid();
            SecurityStamp = Guid.NewGuid().ToString();
        }
        public ApplicationUser(string userName) : this()
        {
            UserName = userName;
        }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public List<UserDevice> UserDevices { get; set; } = new List<UserDevice>();
    }
}
