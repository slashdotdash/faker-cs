using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
    public static class Address
    {
        public static string ZipCode()
        {
            return new[] {"#####", "#####-####"}.Random().Numerify();
        }

        public static string UsState()
        {
            return _states.Random();
        }

        public static string UsStateAbbr()
        {
            return "AL AK AS AZ AR CA CO CT DE DC FM FL GA GU HI ID IL IN IA KS KY LA ME MH MD MA MI MN MS MO MT NE NV NH NJ NM NY NC ND MP OH OK OR PW PA PR RI SC SD TN TX UT VT VI VA WA WV WI WY AE AA AP"
                .Split(' ').Random();
        }
        
        public static string CityPrefix()
        {
            return "North East West South New Lake Port".Split(' ').Random();
        }

        public static string CitySufix()
        {
            return "town ton land ville berg burgh borough bury view port mouth stad furt chester mouth fort haven side shire".Split(' ').Random();
        }

        public static string City()
        {
            return _cityFormats.Random();
        }

        public static string StreetSuffix()
        {
            return "Alley Avenue Branch Bridge Brook Brooks Burg Burgs Bypass Camp Canyon Cape Causeway Center Centers Circle Circles Cliff Cliffs Club Common Corner Corners Course Court Courts Cove Coves Creek Crescent Crest Crossing Crossroad Curve Dale Dam Divide Drive Drive Drives Estate Estates Expressway Extension Extensions Fall Falls Ferry Field Fields Flat Flats Ford Fords Forest Forge Forges Fork Forks Fort Freeway Garden Gardens Gateway Glen Glens Green Greens Grove Groves Harbor Harbors Haven Heights Highway Hill Hills Hollow Inlet Inlet Island Island Islands Islands Isle Isle Junction Junctions Key Keys Knoll Knolls Lake Lakes Land Landing Lane Light Lights Loaf Lock Locks Locks Lodge Lodge Loop Mall Manor Manors Meadow Meadows Mews Mill Mills Mission Mission Motorway Mount Mountain Mountain Mountains Mountains Neck Orchard Oval Overpass Park Parks Parkway Parkways Pass Passage Path Pike Pine Pines Place Plain Plains Plains Plaza Plaza Point Points Port Port Ports Ports Prairie Prairie Radial Ramp Ranch Rapid Rapids Rest Ridge Ridges River Road Road Roads Roads Route Row Rue Run Shoal Shoals Shore Shores Skyway Spring Springs Springs Spur Spurs Square Square Squares Squares Station Station Stravenue Stravenue Stream Stream Street Street Streets Summit Summit Terrace Throughway Trace Track Trafficway Trail Trail Tunnel Tunnel Turnpike Turnpike Underpass Union Unions Valley Valleys Via Viaduct View Views Village Village  Villages Ville Vista Vista Walk Walks Wall Way Ways Well Wells"
                .Split(' ').Random();
        }

        public static string StreetName()
        {
            return String.Join(" ", _streetFormats.Random());
        }
        
        public static string StreetAddress()
        {
            return StreetAddress(false);
        }

        public static string StreetAddress(bool includeSecondary)
        {
            return _streetAddressFormats.Random().Numerify() + (includeSecondary ? " " + SecondaryAddress() : "");
        }

        public static string SecondaryAddress()
        {
            return new [] { "Apt. ###", "Suite ###" }.Random().Numerify();
        }

        public static string UkCounty()
        {
            return _ukCounties.Random();
        }

        public static string UkCountry()
        {
            return new [] { "England", "Scotland", "Wales", "Northern Ireland" }.Random();
        }

        public static string UkPostCode()
        {
            return new[] {"??# #??", "??## #??"}.Random().Numerify().Letterify();
        }

        #region Format Mappings
        private static readonly string[] _states = new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
        private static readonly string[] _ukCounties = new[] { "Avon", "Bedfordshire", "Berkshire", "Borders", "Buckinghamshire", "Cambridgeshire", "Central", "Cheshire", "Cleveland", "Clwyd", "Cornwall", "County Antrim", "County Armagh", "County Down", "County Fermanagh", "County Londonderry", "County Tyrone", "Cumbria", "Derbyshire", "Devon", "Dorset", "Dumfries and Galloway", "Durham", "Dyfed", "East Sussex", "Essex", "Fife", "Gloucestershire", "Grampian", "Greater Manchester", "Gwent", "Gwynedd County", "Hampshire", "Herefordshire", "Hertfordshire", "Highlands and Islands", "Humberside", "Isle of Wight", "Kent", "Lancashire", "Leicestershire", "Lincolnshire", "Lothian", "Merseyside", "Mid Glamorgan", "Norfolk", "North Yorkshire", "Northamptonshire", "Northumberland", "Nottinghamshire", "Oxfordshire", "Powys", "Rutland", "Shropshire", "Somerset", "South Glamorgan", "South Yorkshire", "Staffordshire", "Strathclyde", "Suffolk", "Surrey", "Tayside", "Tyne and Wear", "Warwickshire", "West Glamorgan", "West Midlands", "West Sussex", "West Yorkshire", "Wiltshire", "Worcestershire" };

        private static readonly IEnumerable<Func<string>> _cityFormats = new List<Func<string>>
        {
            () => string.Format("{0} {1}{2}", CityPrefix(), Name.First(), CitySufix()),
            () => string.Format("{0} {1}", CityPrefix(), Name.First()),
            () => string.Format("{0}{1}", Name.First(), CitySufix()),
            () => string.Format("{0}{1}", Name.Last(), CitySufix())
        };

        private static readonly IEnumerable<Func<string[]>> _streetFormats = new List<Func<string[]>>
        {
            () => new [] { Name.Last(), StreetSuffix() },
            () => new [] { Name.First(), StreetSuffix() }
        };

        private static readonly IEnumerable<Func<string>> _streetAddressFormats = new List<Func<string>>
        {
            () => string.Format("##### {0}", StreetName()),
            () => string.Format("#### {0}", StreetName()),
            () => string.Format("### {0}", StreetName()),
        };
        #endregion
    }
}