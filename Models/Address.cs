using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CanvassHelp.Models
{
    [Authorize]
    public class Address
    {
        [Key,
            Column("AddressId"),
            Display(Name = "Address ID")]
        public int AddressId { get; set; }

        [Column("GroupingId"),
            Display(Name = "Address Group ID")]
        public int GroupingId { get; set; }

        [StringLength(50, ErrorMessage = "House Name cannot be longer than 50 characters"),
            Column("HouseName"),
            Display(Name = "House Name")]
        public string HouseName { get; set; }

        [Required, 
            Column("HouseNumber"),
            Display(Name = "House Number")]
        public int HouseNumber { get; set; }

        [Required,
            StringLength(50, ErrorMessage = "Street Name cannot be longer than 50 characters"),
            Column("StreetName"),
            Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [StringLength(50, ErrorMessage = "Post Town cannot be longer than 50 characters"),
            Column("PostTown"),
            Display(Name = "Post Town")]
        public string PostTown { get; set; }

        [Required,
            DataType(DataType.PostalCode, ErrorMessage = "Invalid Postcode Format"),
            Column("Postcode"),
            Display(Name = "Postcode")]
        public string Postcode { get; set; }

        // Navigation Properties
        public Grouping Grouping { get; set; }
        public ICollection<Resident> Residents { get; set; } = new List<Resident>();
    }
}