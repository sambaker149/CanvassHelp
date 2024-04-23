using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CanvassHelp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int GroupingId { get; set; }
        public string HouseName { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string PostTown { get; set; }
        public string Postcode { get; set; }

        public Grouping Grouping { get; set; }
        public ICollection<Resident> Residents { get; set; } = new List<Resident>();
    }
}