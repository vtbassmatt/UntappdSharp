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
    public class UtBeerSearch
    {
        public UtBeerSearch ()
        {
        }

        public static UtBeerSearch FromDynamic(dynamic From)
        {
            UtBeerSearch srch = new UtBeerSearch()
            {
                SearchTerm = From.search_term,
                ReturnedResults = Coerce.ToInt(From.returned_results),
                NextPage = Coerce.ToUri(From.next_page),
            };

            srch.Results = new UtBeerSearchBeer[srch.ReturnedResults];
            for(int i = 0; i < srch.ReturnedResults; i++)
            {
                srch.Results[i] = UtBeerSearchBeer.FromDynamic(From.results[i]);
            }

            return srch;
        }

        public string SearchTerm { get; internal set; }
        public int ReturnedResults { get; internal set; }
        public Uri NextPage { get; internal set; }
        public UtBeerSearchBeer[] Results { get; internal set; }

/*
 *
 *stdClass Object
(
    [search_term] => sam adams
    [http_code] => 200
    [returned_results] => 25
    [next_page] => http://api.untappd.com/v3/beer_search?q=sam%25adams&offset=25
    [results] => Array
        (
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

            [1] => stdClass Object
                (
                    [beer_id] => 42584
                    [beer_name] => Sam Adams Chocolate Cherry Bock
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 25
                )

            [2] => stdClass Object
                (
                    [beer_id] => 4049
                    [beer_name] => Sam Adams Light
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 451
                )

            [3] => stdClass Object
                (
                    [beer_id] => 27551
                    [beer_name] => Samual Adams
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 18
                )

            [4] => stdClass Object
                (
                    [beer_id] => 27583
                    [beer_name] => Samual Adams
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 3
                )

            [5] => stdClass Object
                (
                    [beer_id] => 8369
                    [beer_name] => Samuel Adams American Kriek (Barrel Room Collection)
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 39
                )

            [6] => stdClass Object
                (
                    [beer_id] => 3918
                    [beer_name] => Samuel Adams Black Lager
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 265
                )

            [7] => stdClass Object
                (
                    [beer_id] => 5116
                    [beer_name] => Samuel Adams Blackberry Witbier
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 319
                )

            [8] => stdClass Object
                (
                    [beer_id] => 48712
                    [beer_name] => Samuel Adams Bonfire Rauchbier
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 0
                )

            [9] => stdClass Object
                (
                    [beer_id] => 3917
                    [beer_name] => Samuel Adams Boston Ale
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 176
                )

            [10] => stdClass Object
                (
                    [beer_id] => 6503
                    [beer_name] => Samuel Adams Boston Brick Red
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 154
                )

            [11] => stdClass Object
                (
                    [beer_id] => 12820
                    [beer_name] => Samuel Adams Boston IPA
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 6
                )

            [12] => stdClass Object
                (
                    [beer_id] => 3914
                    [beer_name] => Samuel Adams Boston Lager
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/beer_logos/beer-saBostonLager.jpg
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 1
                    [total_count] => 4695
                )

            [13] => stdClass Object
                (
                    [beer_id] => 4076
                    [beer_name] => Samuel Adams Brown Ale
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 1
                )

            [14] => stdClass Object
                (
                    [beer_id] => 32872
                    [beer_name] => Samuel Adams Cherry Chocolate Bock
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 15
                )

            [15] => stdClass Object
                (
                    [beer_id] => 4052
                    [beer_name] => Samuel Adams Cherry Wheat
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 576
                )

            [16] => stdClass Object
                (
                    [beer_id] => 1195
                    [beer_name] => Samuel Adams Chocolate Bock
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/beer_logos/beer-samuelAdamsChocolateBock.jpg
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 669
                )

            [17] => stdClass Object
                (
                    [beer_id] => 2816
                    [beer_name] => Samuel Adams Coastal Wheat
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 310
                )

            [18] => stdClass Object
                (
                    [beer_id] => 43790
                    [beer_name] => Samuel Adams Colonial
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 4
                )

            [19] => stdClass Object
                (
                    [beer_id] => 3602
                    [beer_name] => Samuel Adams Cranberry Lambic
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 55
                )

            [20] => stdClass Object
                (
                    [beer_id] => 4074
                    [beer_name] => Samuel Adams Cream Stout
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 241
                )

            [21] => stdClass Object
                (
                    [beer_id] => 3915
                    [beer_name] => Samuel Adams Double Bock (Imperial Series)
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 215
                )

            [22] => stdClass Object
                (
                    [beer_id] => 6130
                    [beer_name] => Samuel Adams Dunkelweizen
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 44
                )

            [23] => stdClass Object
                (
                    [beer_id] => 32690
                    [beer_name] => Samuel Adams East-West Kölsch
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 252
                )

            [24] => stdClass Object
                (
                    [beer_id] => 3427
                    [beer_name] => Samuel Adams Golden Pilsner
                    [beer_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-beer-default.png
                    [brewery_id] => 157
                    [brewery_name] => Boston Beer Company
                    [brewery_stamp] => https://untappd.s3.amazonaws.com/site/assets/images/temp/badge-brewery-default.png
                    [country_name] => United States
                    [your_count] => 0
                    [total_count] => 9
                )

        )

)*/
    }
}

