//
// UntappdSharp is a .Net 4.0 library for calling the Untappd API
// The latest information and code for the project can be found at
// https://github.com/vtbassmatt/UntappdSharp
//
// This project is licensed under the BSD license. See the License.txt file for
// more information.
//
using System;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
namespace UntappdSharp
{
    public class UtUser
    {
        public UtUser ()
        {
        }

        public UtUser(UtCheckinUserDetails CheckinUser)
        {
            throw new NotImplementedException();
        }

        public static UtUser FromDynamic(dynamic User)
        {
            var user = new UtUser()
            {
                UserName = User.user_name,
                FirstName = User.first_name,
                LastName = User.last_name,
                UserAvatar = Coerce.ToUri(User.user_avatar),
                Location = User.location,
                Bio = User.bio,
                IsFriends = Coerce.ToBool(User.is_friends),
                Url = Coerce.ToUri(User.url),
            };

            // most User calls return uid.  /friends returns user_id.
            try { user.Uid = Coerce.ToInt(User.uid); }
            catch(RuntimeBinderException) {
                try { user.Uid = Coerce.ToInt(User.user_id); } catch(RuntimeBinderException) { }
            }

            // sometimes user objects have these properties, sometimes they don't
            // TODO: performance testing to see if this is as expensive as it looks
            try { user.IsRequested = Coerce.ToBool(User.is_requested); } catch(RuntimeBinderException) { };
            try { user.IsYou = Coerce.ToBool(User.is_you); } catch(RuntimeBinderException) { };
            try { user.DateJoined = Coerce.ToDateTime(User.date_joined); } catch(RuntimeBinderException) { };
            try { user.IsPrivate = Coerce.ToBool(User.is_private); } catch(RuntimeBinderException) { };
            try { user.TotalBadges = Coerce.ToInt(User.total_badges); } catch(RuntimeBinderException) { };
            try { user.TotalFriends = Coerce.ToInt(User.total_friends); } catch(RuntimeBinderException) { };
            try { user.TotalCheckins = Coerce.ToInt(User.total_checkins); } catch(RuntimeBinderException) { };
            try { user.TotalBeers = Coerce.ToInt(User.total_beers); } catch(RuntimeBinderException) { };
            try { user.TotalCreatedBeers = Coerce.ToInt(User.total_created_beers); } catch(RuntimeBinderException) { };
            try { user.SocialAccounts = new Dictionary<string,bool>(3)
                {
                    {"facebook", Coerce.ToBool(User.social_accounts.facebook)},
                    {"twitter", Coerce.ToBool(User.social_accounts.twitter)},
                    {"foursquare", Coerce.ToBool(User.social_accounts.foursquare)},
                };
            } catch(RuntimeBinderException) { };

            return user;
        }

        public int Uid { get; internal set; }
        public string UserName { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Uri UserAvatar { get; internal set; }
        public string Location { get; internal set; }
        public string Bio { get; internal set; }
        public bool IsFriends { get; internal set; }
        public bool IsRequested { get; internal set; }
        public bool IsYou { get; internal set; }
        public Uri Url { get; internal set; }
        public DateTime DateJoined { get; internal set; }
        public bool IsPrivate { get; internal set; }
        public int TotalBadges { get; internal set; }
        public int TotalFriends { get; internal set; }
        public int TotalCheckins { get; internal set; }
        public int TotalBeers { get; internal set; }
        public int TotalCreatedBeers { get; internal set; }
        public Dictionary<string,bool> SocialAccounts { get; internal set; }

        /*
stdClass Object
(
    [http_code] => 200
    [results] => stdClass Object
        (
            [user] => stdClass Object
                (
                    [uid] => 11779
                    [user_name] => vtbassmatt
                    [first_name] => Matt
                    [last_name] => Cooper
                    [user_avatar] => http://gravatar.com/avatar.php?gravatar_id=0e606626a0fc989a9ec3134559315324&rating=X&size=80&default=https://untappd.s3.amazonaws.com/site/assets/images/default_avatar.jpg
                    [location] => Issaquah, WA
                    [bio] => 
                    [is_friends] => 
                    [is_requested] => 
                    [is_you] => 1
                    [url] => 
                    [date_joined] => Tue, 28 Dec 2010 07:26:02 +0000
                    [is_private] => 0
                    [total_badges] => 1
                    [total_friends] => 0
                    [total_checkins] => 3
                    [total_beers] => 3
                    [total_created_beers] => 0
                    [social_accounts] => stdClass Object
                        (
                            [facebook] => 1
                            [twitter] => 
                            [foursquare] => 1
                        )

                )

        )

)         */
    }
}

