using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFindaBLE.Backend.Models
{
    public class UserDevice : BaseEntity
    {
        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Device))]
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public Attributes Attribute { get; set; }
    }
    public enum Attributes
    {
        None,
        Owner,
        Outsiders,
    }
}
