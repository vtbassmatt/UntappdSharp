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
    public class UtBeerSearchBeer
    {
        public UtBeerSearchBeer ()
        {
        }

        public static UtBeerSearchBeer FromDynamic(dynamic From)
        {
            UtBeerSearchBeer beer = new UtBeerSearchBeer()
            {
                BeerId = Coerce.ToInt(From.beer_id),
                BeerName = From.beer_name,
                BeerStamp = Coerce.ToUri(From.beer_stamp),
                BreweryId = Coerce.ToInt(From.brewery_id),
                BreweryName = From.brewery_name,
                BreweryStamp = Coerce.ToUri(From.brewery_stamp),
                CountryName = From.country_name,
                YourCount = Coerce.ToInt(From.your_count),
                TotalCount = Coerce.ToInt(From.total_count),
            };

            return beer;
        }

        public int BeerId { get; internal set; }
        public string BeerName { get; internal set; }
        public Uri BeerStamp { get; internal set; }
        public int BreweryId { get; internal set; }
        public string BreweryName { get; internal set; }
        public Uri BreweryStamp { get; internal set; }
        public string CountryName { get; internal set; }
        public int YourCount { get; internal set; }
        public int TotalCount { get; internal set; }
/*
    [0] => stdClass Object
    (
        [beer_id] => 38942
        [beer_name] => Sam adams
        [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
        [brewery_id] => 9422
        [brewery_name] => Two Step Brewing
        [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
        [country_name] => United States
        [your_count] => 0
        [total_count] => 1
    )
*/
    }
}

