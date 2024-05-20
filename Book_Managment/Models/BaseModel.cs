using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_Managment.API.Models
{
    public class BaseModel
    {
        public long? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsActive { get; set; } = true;

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
