//
// UntappdSharp is a .Net 4.0 library for calling the Untappd API
// The latest information and code for the project can be found at
// https://github.com/vtbassmatt/UntappdSharp
//
// This project is licensed under the BSD license. See the License.txt file for
// more information.
//
using System;
using System.Net;
namespace UntappdSharp
{
    internal interface IUntappd
    {
        // Credential setup
        void SetCredentials(string Username, string Password);

        // User info
        UtUser User(string Username = "");
        UtUserFeed UserFeed(string Username = null, int? Since = null, int? Offset =  null);

        // Beer info
        UtBeerSearch BeerSearch(string Q, bool SortByCount = false, int? Offset = null);
        UtBeer BeerInfo(int BeerId);

        // Brewery info
        UtBrewery BreweryInfo(int BreweryId);

        // Friends info
        UtFriends Friends(string Username = null, int? Offset = null);

        // Check in
        UtCheckin Checkin(CheckinOptions Options);
        UtCheckin CheckinTest(CheckinOptions Options);
    }
}

