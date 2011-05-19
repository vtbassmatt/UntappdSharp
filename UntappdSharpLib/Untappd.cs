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
using DynamicRest;
using System.Text;
using System.Collections.Generic;
namespace UntappdSharp
{
    public class Untappd : IUntappd
    {
        private dynamic _Client;

        public Untappd () : this(null)
        {
        }

        public Untappd (string ApiKey = null)
        {
            try {
                List<string> PostOps = new List<string>()
                {
                    "checkin_test",
                    "checkin",
                };
                _Client = new RestClient(EnvironmentDetails.EndpointFormat, RestService.Json, PostOps);
    
                if(null == ApiKey)
                {
                    _Client.apiKey = EnvironmentDetails.ApiKey;
                } else {
                    _Client.apiKey = ApiKey;
                }
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        #region IUntappd implementation
        public void SetCredentials (string Username, string Password)
        {
            try {
                _Client = _Client.WithBasicAuth(Username, MD5(Password));
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtUser User (string Username = "")
        {
            try {
                dynamic args = new JsonObject();
                args.user = Username;

                dynamic response = _Client.user(args);
                if(null != response.Result.results)
                {
                    dynamic user = response.Result.results.user;

                    return UtUser.FromDynamic(user);
                }

                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtUserFeed UserFeed(string Username = null, int? Since = null, int? Offset =  null)
        {
            try {
                dynamic args = new JsonObject();
                args.user = Username;
                args.since = Since;
                args.offset = Offset;
    
                dynamic response = _Client.user_feed(args);
                if(null != response.Result.results)
                {
                    return UtUserFeed.FromDynamic(response);
                }
    
                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtBeer BeerInfo(int BeerId)
        {
            try {
                dynamic args = new JsonObject();
                args.bid = BeerId;

                dynamic response = _Client.beer_info(args);
                if(null != response.Result.results)
                {
                    return UtBeer.FromDynamic(response.Result.results);
                }

                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtBrewery BreweryInfo(int BreweryId)
        {
            try {
                dynamic args = new JsonObject();
                args.brewery_id = BreweryId;
    
                dynamic response = _Client.brewery_info(args);
                if(null != response.Result.results)
                {
                    return UtBrewery.FromDynamic(response.Result.results);
                }
    
                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtFriends Friends(string Username = null, int? Offset = null)
        {
            try {
                dynamic args = new JsonObject();
                args.user = Username;
                args.offset = Offset;
    
                dynamic response = _Client.friends(args);
                if(null != response.Result.results)
                {
                    return UtFriends.FromDynamic(response);
                }
    
                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtCheckin Checkin(CheckinOptions Options)
        {
            return CheckinInternal(Options, true);
        }

        public UtCheckin CheckinTest(CheckinOptions Options)
        {
            return CheckinInternal(Options, false);
        }

        private UtCheckin CheckinInternal(CheckinOptions Options, bool IsRealCheckin)
        {
            // CheckinOptions allow for CheckinTest:
            // gmt_offset    : required
            // bid           : required, beer ID
            // foursquare_id : optional
            // user_lat      : optional, but required if location given
            // user_lng      : optional, but required if location given

            try
            {
                dynamic args = new JsonObject();
                args.gmt_offset = GetGmtOffset(Options.Timezone);
                args.bid = Options.BeerId;
                args.foursquare_id = Options.FoursquareId;
                args.user_lat = Options.UserLat;
                args.user_lng = Options.UserLng;
    
                dynamic response;
                if(IsRealCheckin)
                {
                    response = _Client.checkin(args);
                } else {
                    response = _Client.checkin_test(args);
                }
                if(null != response.Result)
                {
                    return UtCheckin.FromDynamic(response.Result);
                }
    
                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }

        public UtBeerSearch BeerSearch(string Q, bool SortByCount = false, int? Offset = null)
        {
            try {
                dynamic args = new JsonObject();
                args.q = Q;
                if(SortByCount) { args.sort = "count"; }
                if(null != Offset) { args.offset = Offset; }
    
                dynamic response = _Client.beer_search(args);
                if(null != response.Result.results)
                {
                    return UtBeerSearch.FromDynamic(response.Result);
                }
    
                return null;
            } catch(Exception ex) {
                throw new UntappdApiException(ex);
            }
        }
        #endregion

        #region Helpers: MD5, timezone stuff
        private static string MD5(string Input)
        {
            // from http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5.aspx
            System.Security.Cryptography.MD5 Md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = Md5Hasher.ComputeHash(Encoding.Default.GetBytes(Input));
            StringBuilder sb = new StringBuilder();
            foreach(byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private static decimal GetGmtOffset(TimeZoneInfo Tz)
        {
            TimeSpan UtcOffset = Tz.GetUtcOffset(DateTime.Today);

            bool WestOfGmt = UtcOffset.Hours < 0;
            decimal WholeHours = Math.Abs(UtcOffset.Hours);
            decimal FractionalHours = UtcOffset.Minutes / 60m;

            return (WholeHours + FractionalHours) *
                   (WestOfGmt ? -1m : 1m);

        }
        #endregion
    }
}

