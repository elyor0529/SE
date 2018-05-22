using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE.Model
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public override T Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AddedDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
          
    }
}
