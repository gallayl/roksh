using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace roksh.Models
{
    public class Package: IEntity
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^([a-zA-Z]{4}[0-9]{4})$")]
        public string Identifier { get; set; }
        public int StateId { get; set; }
        public DeliveryState State { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}