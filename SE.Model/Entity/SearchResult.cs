using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE.Model.Entity
{
    public class SearchResult : AuditableEntity<long>
    {

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string SearchTerms { get; set; }

        [Required]
        [StringLength(1000)]
        public string Url { get; set; }

        public double? SearchTime { get; set; }

        public long? TotalRecords { get; set; }

        [ForeignKey("Provider")]
        public long ProviderId { get; set; }

        [StringLength(50)]
        public string Ip { get; set; }

        public virtual SearchProvider Provider { get; set; }

        public virtual ICollection<ResultHistory> Histories { get; set; }

        public SearchResult()
        {
            Histories = new HashSet<ResultHistory>();
        }

    }
}
