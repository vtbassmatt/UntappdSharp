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
    public class UtCheckinUserDetails
    {
        public static UtCheckinUserDetails FromDynamic(dynamic From)
        {
            return new UtCheckinUserDetails()
            {
                Username = From.username,
                Name = From.name,
                Id = Coerce.ToInt(From.id),
                Img = Coerce.ToUri(From.img),
            };
        }

        public string Username { get; internal set; }
        public string Name { get; internal set; }
        public int Id { get; internal set; }
        public Uri Img { get; internal set; }
    }
}

