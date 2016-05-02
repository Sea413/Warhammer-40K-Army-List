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

        public override bool Equals(System.Object otherArmy)
        {
            if (!(otherArmy is Army))
            {
                return false;
            }
            else
            {
                Army testArmy = (Army) otherArmy;
                return ArmyId.Equals(testArmy.ArmyId);
            }
        }

        public override int GetHashCode()
        {
            return ArmyId.GetHashCode();
        }
    }
}