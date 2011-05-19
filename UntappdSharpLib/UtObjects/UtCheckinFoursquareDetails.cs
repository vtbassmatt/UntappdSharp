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
    public class UtCheckinFoursquareDetails
    {
        public UtCheckinFoursquareDetails ()
        {
        }

        public static UtCheckinFoursquareDetails FromDynamic(dynamic From)
        {
            UtCheckinFoursquareDetails detail = new UtCheckinFoursquareDetails()
            {
                Name = From.venue_name,
                Address = From.venue_address,
                City = From.venue_city,
                State = From.venue_state,
                FoursquareImg = Coerce.ToUri(From.foursquare_img),
                Category = From.venue_category,
            };

            return detail;
        }

        public string Name { get; internal set; }
        public string Address { get; internal set; }
        public string City { get; internal set; }
        public string State { get; internal set; }
        public Uri FoursquareImg { get; internal set; }
        public string Category { get; internal set; }
    }
}

