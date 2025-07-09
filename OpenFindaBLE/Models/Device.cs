using System.ComponentModel.DataAnnotations;

namespace OpenFindaBLE.Backend.Models
{
    public class Device:BaseEntity
    {
        public byte[]? EncryptionKey { get; set; }
        public byte[]? VarificationKey { get; set; }
        public Device()
        {
            EncryptionKey = new byte[32]; // Default size for AES-256
            VarificationKey = new byte[32]; // Default size for AES-256
        }

    }
}
