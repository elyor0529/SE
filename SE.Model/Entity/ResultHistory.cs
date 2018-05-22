using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE.Model.Entity
{
    public class ResultHistory : AuditableEntity<long>
    {

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }

        public int ResultIndex { get; set; }

        [ForeignKey("Result")]
        public long ResultId { get; set; }

        public virtual SearchResult Result { get; set; }

    }
}
