using System.ComponentModel.DataAnnotations;

namespace Zion1.Client.Domain.Entities
{
    public class ClientInfo 
    {
        [Key]
        public int ClientId { get; set; } = 0;
        public string ClientName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}