using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CanvassHelp.Models
{
    public enum VoteIntention
    {
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
        Morning,
        Afternoon,
        Evening,
        Anytime,
        DoNotContact
    }
    public class Resident
    {
        public int ResidentId { get; set; }
        public int AddressId { get; set; }
        public string FirstNames { get; set; }
        public string MiddleNames { get; set; }
        public string LastNames { get; set; }
        [DisplayFormat(NullDisplayText = "No Information")]
        public string Email { get; set; }
        [DisplayFormat(NullDisplayText = "No Information")]
        public int MobileNumber { get; set; }

        [DisplayFormat(NullDisplayText = "No Information")]
        public VoteIntention? VoteIntention { get; set; }
        [DisplayFormat(NullDisplayText = "No Information")]
        public Likelihood? Likelihood { get; set; }
        [DisplayFormat(NullDisplayText = "No Information")]
        public Information? Information { get; set; }
        [DisplayFormat(NullDisplayText = "No Information")]
        public ContactPreference? ContactPreference { get; set; }
        public DateTime LastContacted { get; set; }

        public Address Address { get; set; }
    }
}