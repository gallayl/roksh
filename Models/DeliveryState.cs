using System.ComponentModel.DataAnnotations;

namespace roksh.Models
{
    public class DeliveryState : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description_EN { get; set; }
        public string Description_HU { get; set; }
    }
}