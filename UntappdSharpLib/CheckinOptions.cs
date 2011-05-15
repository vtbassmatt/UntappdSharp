// 
// UntappdSharp is a .Net 4.0 library for calling the Untappd API
// The latest information and code for the project can be found at
// https://github.com/vtbassmatt/UntappdSharp
// 
// This project is licensed under the BSD license. See the License.txt file for
// more information.
using System;
namespace UntappdSharp
{
    public class CheckinOptions
    {
        // Allowed in Checkin & CheckinTest
        public TimeZoneInfo Timezone { get; set; }
        public int BeerId { get; set; }
        public string FoursquareId { get; set; }
        public decimal? UserLat { get; set; }
        public decimal? UserLng { get; set; }

        // Allowed in Checkin
        public string Shout { get; set; }
        public int RatingValue { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Foursquare { get; set; }
        public bool Gowalla { get; set; }
    }
}

