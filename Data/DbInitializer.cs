using CanvassHelp.Models;
using System.Diagnostics;

namespace CanvassHelp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CanvassHelpContext context)
        {
            // Look for any students.
            if (context.Groupings.Any())
            {
                return;   // DB has been seeded
            }

            var groups = new Grouping[]
            {
                new() {GroupingId=001001,GroupingName="Grp_1.1"},
                new() {GroupingId=001002,GroupingName="Grp_1.2"},
                new() {GroupingId=001003,GroupingName="Grp_1.3"},
                new() {GroupingId=001004,GroupingName="Grp_1.4"},
                new() {GroupingId=001005,GroupingName="Grp_1.5"},
                new() {GroupingId=002001,GroupingName="Grp_2.1"},
                new() {GroupingId=002002,GroupingName="Grp_2.2"},
                new() {GroupingId=002003,GroupingName="Grp_2.3"},
                new() {GroupingId=002004,GroupingName="Grp_2.4"},
                new() {GroupingId=002005,GroupingName="Grp_2.5"}
            };

            context.Groupings.AddRange(groups);
            context.SaveChanges();

            var addresses = new Address[]
            {
                new() {AddressId=000001,HouseName=null,HouseNumber=12,StreetName="Elmwood Avenue",PostTown="London",Postcode="SW7 3AX",GroupingId=002004},
                new() {AddressId=000002,HouseName=null,HouseNumber=45,StreetName="Primrose Lane",PostTown="Birmingham",Postcode="B11 2RW",GroupingId=001005},
                new() {AddressId=000003,HouseName="Willow House",HouseNumber=7,StreetName="Willow Crescent",PostTown="Manchester",Postcode="M14 7DH",GroupingId=002001},
                new() {AddressId=000004,HouseName=null,HouseNumber=33,StreetName="Oakwood Road",PostTown="Edinburgh",Postcode="EH12 EYZ",GroupingId=001002},
                new() {AddressId=000005,HouseName="Beech Cottage",HouseNumber=22,StreetName="Beechwood Drive",PostTown="Cardiff",Postcode="CF24 4JX",GroupingId=002005}
            };

            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            var people = new Resident[]
            {
                new() {FirstNames="John",MiddleNames="William",LastNames="Smith",LastContacted=DateTime.Parse("2019-09-01"),VoteIntention=VoteIntention.Undecided,Likelihood=Likelihood.Five,ContactPreference=ContactPreference.Anytime,Information=Information.Letter,AddressId=000001},
                new() {FirstNames="Emily",MiddleNames="Grace",LastNames="Johnson",LastContacted=DateTime.Parse("2017-09-01"),VoteIntention=VoteIntention.Labour,Likelihood=Likelihood.Nine,ContactPreference=ContactPreference.Evening,Information=null,AddressId=000003},
                new() {FirstNames="Daniel",MiddleNames="James",LastNames="Brown",LastContacted=DateTime.Parse("2018-09-01"),VoteIntention=VoteIntention.LiberalDemocrat,Likelihood=null,ContactPreference=null,Information=Information.ReturnSoon,AddressId=000003},
                new() {FirstNames="Sarah",MiddleNames="Louise",LastNames="Wilson",LastContacted=DateTime.Parse("2017-09-01"),VoteIntention=VoteIntention.Conservative,Likelihood=Likelihood.Three,ContactPreference=null,Information=Information.AllowTimeToAnswer,AddressId=000004},
                new() {FirstNames="Michael",MiddleNames="Alexander",LastNames="Taylor",LastContacted=DateTime.Parse("2017-09-01"),VoteIntention=VoteIntention.GreenParty,Likelihood=Likelihood.Seven,ContactPreference=ContactPreference.Morning,Information=null,AddressId=000005}
            };

            context.Residents.AddRange(people);
            context.SaveChanges();
        }
    }
}