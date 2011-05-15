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
    public class UtPromotion
    {
        public UtPromotion ()
        {
        }

        public static UtPromotion FromDynamic(dynamic From)
        {
            return new UtPromotion()
            {
                PromoName = From.promo_name,
                PromoDescription = From.promo_description,
                PromoImage = Coerce.ToUri(From.promo_image),
                PromoLegal = From.promo_legal,
            };
        }

        public string PromoName { get; internal set; }
        public string PromoDescription { get; internal set; }
        public Uri PromoImage { get; internal set; }
        public string PromoLegal { get; internal set; }
    }
}

