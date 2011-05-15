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
    public class UtUserFeed
    {
        public UtUserFeed ()
        {
        }

        // TODO: Refactor.  This FromDynamic pulls in some of the metadata that isn't
        //       from the results member, which is unlike other FromDynamic's
        public static UtUserFeed FromDynamic(dynamic Response)
        {
            dynamic feed = Response.Result.results;
            UtUserFeed uFeed = new UtUserFeed()
            {
                NextQuery = Response.Result.next_query,
                NextPage = Response.Result.next_page,
                Feed = new UtUserFeedItem[Response.Result.returned_results],
            };

            for(int i = 0; i < Response.Result.returned_results; i++)
            {
                uFeed.Feed[i] = UtUserFeedItem.FromDynamic(feed[i]);
            }

            return uFeed;
        }

        public int ReturnedResults { get { return Feed.Length; } }
        public string NextQuery { get; internal set; }
        public string NextPage { get; internal set; }
        public UtUserFeedItem[] Feed { get; internal set; }

        /*
stdClass Object
(
    [http_code] => 200
    [returned_results] => 3
    [next_query] => http://api.untappd.com/v3/user_feed?user=vtbassmatt&since=842747
    [next_page] => http://api.untappd.com/v3/user_feed?user=vtbassmatt&offset=25
    [results] => Array
        (
            [0] => stdClass Object
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
                            [url] =>
                        )

                    [checkin_id] => 842747
                    [beer_id] => 3977
                    [brewery_id] => 44
                    [beer_name] => Shock Top Belgian White
                    [brewery_name] => Anheuser-Busch
                    [created_at] => Wed, 11 May 2011 01:49:04 +0000
                    [check_in_comment] =>
                    [checkin_link] => http://untappd.com/user/vtbassmatt/checkin/842747
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [venue_name] => Sammamish Crown Condominiums
                    [venue_id] => 49458
                    [venue_lat] => 47.5674
                    [venue_lng] => -122.098
                )

            [1] => stdClass Object
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
                            [url] => 
                        )

                    [checkin_id] => 177372
                    [beer_id] => 6681
                    [brewery_id] => 2531
                    [beer_name] => Session Black Lager
                    [brewery_name] => Full Sail Brewing Company
                    [created_at] => Sat, 15 Jan 2011 01:38:27 +0000
                    [check_in_comment] => 
                    [checkin_link] => http://untappd.com/user/vtbassmatt/checkin/177372
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [venue_name] => 
                    [venue_id] => 
                    [venue_lat] => 
                    [venue_lng] => 
                )

            [2] => stdClass Object
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
                            [url] => 
                        )

                    [checkin_id] => 104600
                    [beer_id] => 769
                    [brewery_id] => 1663
                    [beer_name] => Snow Cap
                    [brewery_name] => Pyramid Breweries, Inc.
                    [created_at] => Tue, 28 Dec 2010 07:42:55 +0000
                    [check_in_comment] => 
                    [checkin_link] => http://untappd.com/user/vtbassmatt/checkin/104600
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [venue_name] => 
                    [venue_id] => 
                    [venue_lat] => 
                    [venue_lng] => 
                )

        )

)
         **/
    }
}

