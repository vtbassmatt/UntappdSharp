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
    public class UtCheckinBeerDetails
    {
        public static UtCheckinBeerDetails FromDynamic(dynamic From)
        {
            return new UtCheckinBeerDetails()
            {
                BeerName = From.beer_name,
                BeerId = Coerce.ToInt(From.beer_id),
                BreweryName = From.brewery_name,
                BreweryId = Coerce.ToInt(From.brewery_id),
                Img = Coerce.ToUri(From.img),
                BeerCreator = Coerce.ToInt(From.beer_creator),
                TypeId = Coerce.ToInt(From.type_id),
                TypeName = From.type_name,
            };
        }

        public string BeerName { get; internal set; }
        public int BeerId { get; internal set; }
        public string BreweryName { get; internal set; }
        public int BreweryId { get; internal set; }
        public Uri Img { get; internal set; }
        public int BeerCreator { get; internal set; }
        public int TypeId { get; internal set; }
        public string TypeName { get; internal set; }
    }
}

