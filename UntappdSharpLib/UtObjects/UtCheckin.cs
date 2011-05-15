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
    public class UtCheckin
    {
        public UtCheckin ()
        {
        }

        public static UtCheckin FromDynamic(dynamic From)
        {
            var checkin = new UtCheckin()
            {
                CheckinTotal = new UtCheckinTotal()
                {
                    Beer = From.checkin_total.beer,
                    BeerMonth = From.checkin_total.beer_month,
                },
                CheckinDetails = new UtCheckinDetails()
                {
                    CheckinId = Coerce.ToInt(From.checkin_details.checkin_id),
                    Shout = From.checkin_details.shout,
                    CheckinLink = Coerce.ToUri(From.checkin_details.checkin_link),
                },
                UserDetails = new UtCheckinUserDetails()
                {
                    Username = From.user_details.username,
                    Name = From.user_details.name,
                    Id = Coerce.ToInt(From.user_details.id),
                    Img = Coerce.ToUri(From.user_details.img),
                },
                BeerDetails = new UtCheckinBeerDetails()
                {
                    BeerName = From.beer_details.beer_name,
                    BeerId = Coerce.ToInt(From.beer_details.beer_id),
                    BreweryName = From.beer_details.brewery_name,
                    BreweryId = Coerce.ToInt(From.beer_details.brewery_id),
                    Img = Coerce.ToUri(From.beer_details.img),
                    BeerCreator = Coerce.ToInt(From.beer_details.beer_creator),
                    TypeId = Coerce.ToInt(From.beer_details.type_id),
                    TypeName = From.beer_details.type_name,
                },
                IsTooFarAway = Coerce.ToBool(From.is_too_far_away),

                // TODO: figure out what these really return and deal with them
                Foursquare = From.foursquare,
                FoursquareDetails = From.foursquare_details,
                HereNow = From.here_now,
            };

            // checkin_test has a known bug: `badges` can be an object
            // rather than an array of objects
            if(null == From.badges) {
                checkin.Badges = null;
            } else if(From.badges is DynamicRest.JsonObject) {
                checkin.Badges = new UtBadge[1];
                checkin.Badges[0] = UtBadge.FromDynamic(From.badges);
            } else {
                checkin.Badges = new UtBadge[From.badges.Length];
                for(int i = 0; i < From.badges.Length; i++)
                {
                    checkin.Badges[i] = UtBadge.FromDynamic(From.badges[i]);
                }
            }

            checkin.Promotions = new UtPromotion[From.promotions.Length];
            for(int i = 0; i < From.promotions.Length; i++)
            {
                checkin.Promotions[i] = UtPromotion.FromDynamic(From.promotions[i]);
            }

            checkin.Recommendations = new UtBeer[From.recommendations.Length];
            for(int i = 0; i < From.recommendations.Length; i++)
            {
                checkin.Recommendations[i] = UtBeer.FromDynamic(From.recommendations[i]);
            }

            return checkin;
        }

        public dynamic Foursquare { get; internal set; }
        public UtCheckinTotal CheckinTotal { get; internal set; }
        public UtBadge[] Badges { get; internal set; }
        public dynamic FoursquareDetails { get; internal set; }
        public dynamic HereNow { get; internal set; }
        public bool IsTooFarAway { get; internal set; }
        public UtCheckinBeerDetails BeerDetails { get; internal set; }
        public UtPromotion[] Promotions { get; internal set; }
        public UtBeer[] Recommendations { get; internal set; }
        public UtCheckinDetails CheckinDetails { get; internal set; }
        public UtCheckinUserDetails UserDetails { get; internal set; }


/*
stdClass Object
(
    [result] => success
    [foursquare] => Array
        (
        )

    [checkin_total] => stdClass Object
        (
            [beer] => 1st
            [beer_month] => 1st
        )

    [badges] => stdClass Object
        (
            [name] => Newbie
            [descrip] => So, you’re new around here? Congrats on your first brew! This ones for you.
            [img_sm] => https://untappd.s3.amazonaws.com/assets/badges/bdg_newbie_sm.png
            [img_md] => https://untappd.s3.amazonaws.com/assets/badges/bdg_newbie_md.png
            [img_lg] => https://untappd.s3.amazonaws.com/assets/badges/bdg_newbie_lg.png
        )

    [foursquare_details] => Array
        (
        )

    [here_now] => Array
        (
        )

    [http_code] => 200
    [is_too_far_away] => false
    [beer_details] => stdClass Object
        (
            [beer_name] => Hocus Pocus
            [beer_id] => 1
            [brewery_name] => Magic Hat Brewing Company
            [brewery_id] => 812
            [img] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
            [beer_creator] => 4016
            [type_id] => 4
            [type_name] => American Lager
        )

    [promotions] => Array
        (
            [0] => stdClass Object
                (
                    [promo_name] => Sample Promotion
                    [promo_description] => Same Description
                    [promo_image] => http://untappd.s3.amazonaws.com/promo/greatdivide-promo-image.jpg
                    [promo_legal] => Legal Text Here
                )

        )

    [recommendations] => Array
        (
            [0] => stdClass Object
                (
                    [beer_name] => Corona Extra
                    [beer_id] => 5848
                    [brewery_name] => Grupo Modelo S.A. de C.V.
                    [brewery_id] => 618
                    [img] => https://untappd.s3.amazonaws.com/site/beer_logos/beer-coronaExtra.jpg
                )

            [1] => stdClass Object
                (
                    [beer_name] => Budweiser
                    [beer_id] => 3783
                    [brewery_name] => Anheuser-Busch
                    [brewery_id] => 44
                    [img] => https://untappd.s3.amazonaws.com/site/beer_logos/beer-budwiser.jpg
                )

            [2] => stdClass Object
                (
                    [beer_name] => Dos Equis Special Lager
                    [beer_id] => 10887
                    [brewery_name] => Cervecería Cuauhtémoc Moctezuma, S.A. de C.V.
                    [brewery_id] => 360
                    [img] => https://untappd.s3.amazonaws.com/site/beer_logos/beer-CerveceriaDosEquisSL.jpg
                )

            [3] => stdClass Object
                (
                    [beer_name] => Pacifico
                    [beer_id] => 5850
                    [brewery_name] => Grupo Modelo S.A. de C.V.
                    [brewery_id] => 618
                    [img] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-pacifico.png
                )

            [4] => stdClass Object
                (
                    [beer_name] => Sapporo Premium Beer
                    [beer_id] => 17636
                    [brewery_name] => Sapporo Breweries Ltd
                    [brewery_id] => 4779
                    [img] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                )

        )

    [checkin_details] => stdClass Object
        (
            [checkin_id] => 373
            [shout] =>
            [checkin_link] => A link to your checkin would be here
        )

    [user_details] => stdClass Object
        (
            [username] => vtbassmatt
            [name] => Matt Cooper
            [id] => 11779
            [img] => http://gravatar.com/avatar.php?gravatar_id=0e606626a0fc989a9ec3134559315324&rating=X&size=80&default=https://untappd.s3.amazonaws.com/site/assets/images/default_avatar.jpg
        )

)
 */
    }
}

