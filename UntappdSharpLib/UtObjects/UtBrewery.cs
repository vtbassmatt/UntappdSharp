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
    public class UtBrewery
    {
        public UtBrewery ()
        {
        }

        public static UtBrewery FromDynamic(dynamic Brewery)
        {
            var brewery = new UtBrewery()
            {
                Name = Brewery.name,
                BreweryId = Coerce.ToInt(Brewery.brewery_id),
                Country = Brewery.country,
                Img = Coerce.ToUri(Brewery.img),
                BreweryOwner = Coerce.ToInt(Brewery.brewery_owner),
                TotalCount = Coerce.ToInt(Brewery.total_count),
                UniqueCount = Coerce.ToInt(Brewery.unique_count),
                MonthlyCount = Coerce.ToInt(Brewery.monthly_count),
                WeeklyCount = Coerce.ToInt(Brewery.weekly_count),
                TwitterHandle = Brewery.twitter_handle,

            };

            brewery.TopBeers = new UtTopBeer[Brewery.top_beers.Length];
            for(int i = 0; i < Brewery.top_beers.Length; i++)
            {
                brewery.TopBeers[i] = UtTopBeer.FromDynamic(Brewery.top_beers[i]);
            }

            return brewery;
        }

        public string Name { get; internal set; }
        public int BreweryId { get; internal set; }
        public string Country { get; internal set; }
        public Uri Img { get; internal set; }
        public int BreweryOwner { get; internal set; }
        public int TotalCount { get; internal set; }
        public int UniqueCount { get; internal set; }
        public int MonthlyCount { get; internal set; }
        public int WeeklyCount { get; internal set; }
        public UtTopBeer[] TopBeers { get; internal set; }
        public string TwitterHandle { get; internal set; }


        /*
stdClass Object
(
    [http_code] => 200
    [results] => stdClass Object
        (
            [name] => (512) Brewing Company
            [brewery_id] => 1
            [country] => United States
            [img] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
            [brewery_owner] => 475
            [total_count] => 902
            [unique_count] => 388
            [monthly_count] => 220
            [weekly_count] => 63
            [top_beers] => Array
                (
                    [0] => stdClass Object
                        (
                            [beer_name] => (512) IPA
                            [beer_id] => 5737
                            [beer_type] => American IPA
                        )

                    [1] => stdClass Object
                        (
                            [beer_name] => (512) Pecan Porter
                            [beer_id] => 5738
                            [beer_type] => American Porter
                        )

                    [2] => stdClass Object
                        (
                            [beer_name] => (512) Black IPA
                            [beer_id] => 36933
                            [beer_type] => Black IPA / Cascadian Dark Ale
                        )

                    [3] => stdClass Object
                        (
                            [beer_name] => (512) Whiskey Barrel Aged Double Pecan Porter
                            [beer_id] => 5741
                            [beer_type] => American Porter
                        )

                    [4] => stdClass Object
                        (
                            [beer_name] => (512) Cascabel Cream Stout
                            [beer_id] => 25611
                            [beer_type] => Stout
                        )

                )

            [twitter_handle] => 512brewing
        )

)
         */
    }
}

