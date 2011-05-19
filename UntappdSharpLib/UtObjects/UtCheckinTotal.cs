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
    public class UtCheckinTotal
    {
        public static UtCheckinTotal FromDynamic(dynamic From)
        {
            return new UtCheckinTotal()
            {
                Beer = From.beer,
                BeerMonth = From.beer_month,
            };
        }
        public string Beer { get; internal set; }
        public string BeerMonth { get; internal set; }
    }
}

