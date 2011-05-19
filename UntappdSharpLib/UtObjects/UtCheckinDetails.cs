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
    public class UtCheckinDetails
    {
        public static UtCheckinDetails FromDynamic(dynamic From)
        {
            return new UtCheckinDetails()
            {
                CheckinId = Coerce.ToInt(From.checkin_id),
                Shout = From.shout,
                CheckinLink = Coerce.ToUri(From.checkin_link),
            };
        }

        public int CheckinId { get; internal set; }
        public string Shout { get; internal set; }
        public Uri CheckinLink { get; internal set; }
    }
}

