using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarHammer.Models
{
    [Table("Armies")]

    public class Army
    {
    [Key]
        public int ArmyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}