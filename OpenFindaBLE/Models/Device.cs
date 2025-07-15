using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFindaBLE.Backend.Models
{
    public class Device:BaseEntity
    {
        public byte[] EncryptionKey { get; set; }
        public byte[] VarificationKey { get; set; }
        public List<TrackLog> TrackLog { get; set; } = new List<TrackLog>();
        public List<UserDevice> UserDevices { get; set; } = new List<UserDevice>();
    }
}
