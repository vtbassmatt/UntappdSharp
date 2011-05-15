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
    public class UtFriends
    {
        public UtFriends ()
        {
        }

        public static UtFriends FromDynamic(dynamic Response)
        {
            dynamic friends = Response.Result.results;
            UtFriends uFriends = new UtFriends()
            {
                NextPage = Response.Result.next_page,
                Friends = new UtUser[Response.Result.returned_results],
            };

            for(int i = 0; i < Response.Result.returned_results; i++)
            {
                uFriends.Friends[i] = UtUser.FromDynamic(friends[i]);
            }

            return uFriends;
        }

        public int ReturnedResults { get { return Friends.Length; } }
        public string NextPage { get; internal set; }
        public UtUser[] Friends { get; internal set; }
    }
}

