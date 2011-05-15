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
    public class UtTopBeer
    {
        public UtTopBeer ()
        {
        }

        public static UtTopBeer FromDynamic(dynamic From)
        {
            return new UtTopBeer()
            {
                BeerName = From.beer_name,
                BeerId = Coerce.ToInt(From.beer_id),
                BeerType = From.beer_type,
            };
        }

        public string BeerName { get; internal set; }
        public int BeerId { get; internal set; }
        public string BeerType { get; internal set; }

/*
    [0] => stdClass Object
    (
        [beer_name] => (512) IPA
        [beer_id] => 5737
        [beer_type] => American IPA
    )
*/
    }
}

