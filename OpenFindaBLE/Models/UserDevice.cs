using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFindaBLE.Backend.Models
{
    public class UserDevice : BaseEntity
    {
        [ForeignKey(nameof(ApplicationUser))]
        public ApplicationUser? ApplicationUser { get; set; }
        public Guid UserId { get; set; }
        public List<Device> Device { get; set; } = new List<Device>();
        public Guid DeviceId { get; set; }
        public Attributes Attribute { get; set; }
        public enum Attributes
        {
            None,
            Owner,
            Outsiders,
        }
    }
}
