// 
// UntappdSharp is a .Net 4.0 library for calling the Untappd API
// The latest information and code for the project can be found at
// https://github.com/vtbassmatt/UntappdSharp
// 
// This project is licensed under the BSD license. See the License.txt file for
// more information.
using System;
using Microsoft.CSharp.RuntimeBinder;

namespace UntappdSharp
{
    public class UtBeer
    {
        public UtBeer ()
        {
        }

        public UtBeer(UtCheckinBeerDetails CheckinBeer)
        {
            Name = CheckinBeer.BeerName;
            BeerId = CheckinBeer.BeerId;
            Brewery = CheckinBeer.BreweryName;
            BreweryId = CheckinBeer.BreweryId;
            Img = CheckinBeer.Img;
            BeerCreatorId = CheckinBeer.BeerCreator;
            Type = CheckinBeer.TypeName;
        }

        public UtBeer(UtBeerSearchBeer BeerSearchBeer)
        {
            Name = BeerSearchBeer.BeerName;
            BeerId = BeerSearchBeer.BeerId;
            Brewery = BeerSearchBeer.BreweryName;
            BreweryId = BeerSearchBeer.BreweryId;
            YourCount = BeerSearchBeer.YourCount;
            TotalCount = BeerSearchBeer.TotalCount;
        }

        public static UtBeer FromDynamic(dynamic Beer)
        {
            // we always get these beer fields
            var beer = new UtBeer()
            {
                BeerId = Coerce.ToInt(Beer.beer_id),
                BreweryId = Coerce.ToInt(Beer.brewery_id),
                Img = Coerce.ToUri(Beer.img),
            };

            // /beer_info returns name.  /checkin_test returns beer_name.
            try { beer.Name = Beer.name; }
            catch(RuntimeBinderException) {
                try { beer.Name = Beer.beer_name; } catch(RuntimeBinderException) { }
            }

            // /beer_info returns brewery.  /checkin_test returns brewery_name.
            try { beer.Brewery = Beer.brewery; }
            catch(RuntimeBinderException) {
                try { beer.Brewery = Beer.brewery_name; } catch(RuntimeBinderException) { }
            }

            // we may get these as well
            try {
                beer.TotalCount = Coerce.ToInt(Beer.total_count);
                beer.UniqueCount = Coerce.ToInt(Beer.unique_count);
                beer.MonthlyCount = Coerce.ToInt(Beer.monthly_count);
                beer.WeeklyCount = Coerce.ToInt(Beer.weekly_count);
                beer.YourCount = Coerce.ToInt(Beer.your_count);
                beer.AvgRating = Coerce.ToInt(Beer.avg_rating);
                beer.YourRating = Coerce.ToInt(Beer.your_rating);
                beer.BeerAbv = Coerce.ToDecimal(Beer.beer_abv);
                beer.BeerCreated = Coerce.ToDateTime(Beer.beer_created);
                beer.Type = Beer.type;
                beer.BeerOwner = Beer.beer_owner;
                beer.BeerCreator = Beer.beer_creator;
                beer.BeerCreatorId = Coerce.ToInt(Beer.beer_creator_id);
                beer.IsHad = Coerce.ToBool(Beer.is_had);
            } catch(RuntimeBinderException) { }

            return beer;
        }

        public string Name { get; internal set; }
        public int BeerId { get; internal set; }
        public string Brewery { get; internal set; }
        public int BreweryId { get; internal set; }
        public Uri Img { get; internal set; }
        public int TotalCount { get; internal set; }
        public int UniqueCount { get; internal set; }
        public int MonthlyCount { get; internal set; }
        public int WeeklyCount { get; internal set; }
        public int YourCount { get; internal set; }
        public int AvgRating { get; internal set; }
        public int YourRating { get; internal set; }
        public decimal BeerAbv { get; internal set; }
        public DateTime BeerCreated { get; internal set; }
        public string Type { get; internal set; }
        public string BeerOwner { get; internal set; }
        public string BeerCreator { get; internal set; }
        public int BeerCreatorId { get; internal set; }
        public bool IsHad { get; internal set; }


        /*
stdClass Object
(
    [http_code] => 200
    [results] => stdClass Object
        (
            [name] => Hocus Pocus
            [beer_id] => 1
            [brewery] => Magic Hat Brewing Company
            [brewery_id] => 812
            [img] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
            [total_count] => 11
            [unique_count] => 10
            [monthly_count] => 3
            [weekly_count] => 1
            [your_count] => 0
            [avg_rating] => 3
            [your_rating] => 0
            [beer_abv] => 4.5
            [beer_created] => Sat, 21 Aug 2010 07:26:35 +0000
            [type] => American Lager
            [beer_owner] => mike_marsh
            [beer_creator] => Mike M.
            [beer_creator_id] => 4016
            [is_had] => 
        )

)
         */
    }
}

