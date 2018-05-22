using System;

namespace SE.Model
{
    public interface IAuditableEntity 
    {
        DateTime AddedDate { get; set; }
          
        DateTime? ModifiedDate { get; set; } 
    }
}
