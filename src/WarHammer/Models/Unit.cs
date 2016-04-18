using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarHammer.Models
{
    [Table("Units")]
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitSize { get; set; }
        public int ArmyId { get; set; }
        public virtual Army Army { get; set; }
    }
}