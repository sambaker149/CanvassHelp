namespace CanvassHelp.Models
{
    public class Grouping
    {
        public int GroupingId { get; set; }
        public string GroupingName { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}