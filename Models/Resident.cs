using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Linq;

namespace CanvassHelp.Models
{
    public enum VoteIntention
    {
        Unknown,
        Conservative,
        Labour,
        LiberalDemocrat,
        GreenParty,
        ReformUK,
        Undecided,
        WillNotSay,
        Against
    }
    public enum Likelihood
    {
        Unknown,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }
    public enum Information
    {
        Unknown,
        ReturnSoon,
        Leaflet,
        Email,
        Letter,
        Call,
        AllowTimeToAnswer,
        MarkAsMoved,
        MarkAsDeceased
    }
    public enum ContactPreference
    {
        Unknown,
        Morning,
        Afternoon,
        Evening,
        Anytime,
        DoNotContact
    }
    public class Resident
    {
        [Key, 
            Column("ResidentId"),
            Display(Name = "Resident ID")]
        public int ResidentId { get; set; }

        [Column("AddressId"),
            Display(Name = "Address ID")]
        public int AddressId { get; set; }

        [Required,
            StringLength(50, ErrorMessage = "First Names cannot be longer than 50 characters"),
            Column("FirstNames"),
            Display(Name = "First Name(s)")]
        public string FirstNames { get; set; }

        [StringLength(50, ErrorMessage = "Middle Names cannot be longer than 50 characters"),
            Column("MiddleNames"),
            Display(Name = "Middle Name(s)")]
        public string MiddleNames { get; set; }

        [Required, 
            StringLength(50, ErrorMessage = "Last Names cannot be longer than 50 characters"), 
            Column("LastNames"), 
            Display(Name = "Last Name(s)")]
        public string LastNames { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown"),
            DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address Format"),
            Column("Email"),
            Display(Name = "Email Address")]
        public string Email { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown"), 
            Column("MobileNumber"),
            Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public VoteIntention? VoteIntention { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public Likelihood? Likelihood { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public Information? Information { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown")]
        public ContactPreference? ContactPreference { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true), Display(Name = "Last Contacted")]
        public DateTime LastContacted { get; set; }

        // Navigation Properties
        public Address Address { get; set; }
    }
}