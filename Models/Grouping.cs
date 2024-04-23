using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanvassHelp.Models
{
    public class Grouping
    {
        [Key, 
            Column("Grouping Id"),
            Display(Name = "Address Group ID")]
        public int GroupingId { get; set; }

        [Required,
            StringLength(50, ErrorMessage = "Address Group Names cannot be longer than 50 characters"),
            Column("GroupingName"),
            Display(Name = "Address Group Name")]
        public string GroupingName { get; set; }

        // Navigation Properties
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}