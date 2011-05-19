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
    public class UtHereNow
    {
        public UtHereNow ()
        {
        }

        public static UtHereNow FromDynamic(dynamic From)
        {
            return new UtHereNow()
            {
                FirstName = From.user.first_name,
                LastName = From.user.last_name,
                Username = From.user.user_name,
                UserPhoto = Coerce.ToUri(From.user.user_photo),
                CheckinId = Coerce.ToInt(From.checkin_id),
                CheckinUrl = Coerce.ToUri(From.checkin_url),
                CreatedAt = Coerce.ToDateTime(From.created_at),
            };
        }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Username { get; internal set; }
        public Uri UserPhoto { get; internal set; }
        public int CheckinId { get; internal set; }
        public Uri CheckinUrl { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}

