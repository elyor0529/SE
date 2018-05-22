using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SE.Model.Entity
{
    public class SearchProvider: AuditableEntity<long>
    { 

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string PrivateSecret { get; set; }

        [MaxLength(250)]
        public string PublicKey { get; set; }

        public virtual ICollection<SearchResult> Results { get; set; }

        public SearchProvider()
        {
            Results = new HashSet<SearchResult>();
        }

    }
}
