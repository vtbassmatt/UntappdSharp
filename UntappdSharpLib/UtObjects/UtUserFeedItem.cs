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
    public class UtUserFeedItem
    {
        public UtUserFeedItem ()
        {
        }

        public static UtUserFeedItem FromDynamic(dynamic FeedItem)
        {
            var feedItem = new UtUserFeedItem()
            {
                User = UtUser.FromDynamic(FeedItem.user),
                CheckinId = Coerce.ToInt(FeedItem.checkin_id),
                BeerId = Coerce.ToInt(FeedItem.beer_id),
                BreweryId = Coerce.ToInt(FeedItem.brewery_id),
                BeerName = FeedItem.beer_name,
                BreweryName = FeedItem.brewery_name,
                CreatedAt = DateTime.Parse(FeedItem.created_at),
                CheckInComment = FeedItem.check_in_comment,
                CheckinLink = Coerce.ToUri(FeedItem.checkin_link),
                BeerStamp = Coerce.ToUri(FeedItem.beer_stamp),
                VenueName = FeedItem.venue_name,
                VenueId = Coerce.ToInt(FeedItem.venue_id),
                VenueLat = Coerce.ToDecimal(FeedItem.venue_lat),
                VenueLng = Coerce.ToDecimal(FeedItem.venue_lng),
            };

            return feedItem;
        }

        public UtUser User { get; internal set; }
        public int CheckinId { get; internal set; }
        public int BeerId { get; internal set; }
        public int BreweryId { get; internal set; }
        public string BeerName { get; internal set; }
        public string BreweryName { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public string CheckInComment { get; internal set; }
        public Uri CheckinLink { get; internal set; }
        public Uri BeerStamp { get; internal set; }
        public string VenueName { get; internal set; }
        public int VenueId { get; internal set; }
        public decimal VenueLat { get; internal set; }
        public decimal VenueLng { get; internal set; }

        /*

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
                 */
    }
}

