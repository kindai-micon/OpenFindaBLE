using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFindaBLE.Backend.Models
{
    public class UserDevice : BaseEntity
    {
        [ForeignKey(nameof(UserId))]

        public ApplicationUser UserId { get; set; }
        [ForeignKey(nameof(DeviceId))]
        public Device DeviceId { get; set; }

        public Attributes Attribute { get; set; } = Attributes.None;
        public enum Attributes
        {
            None = 0,
            Owner = 1,
            Outsiders = 2,
        }
    }
}
