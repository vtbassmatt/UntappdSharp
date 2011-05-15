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
    public class UtBadge
    {
        public UtBadge ()
        {
        }

        public static UtBadge FromDynamic(dynamic From)
        {
            UtBadge badge = new UtBadge()
            {
                Name = From.name,
                Descrip = From.descrip,
                ImgSm = Coerce.ToUri(From.img_sm),
                ImgMd = Coerce.ToUri(From.img_md),
                ImgLg = Coerce.ToUri(From.img_lg),
            };

            return badge;
        }

        public string Name { get; internal set; }
        public string Descrip { get; internal set; }
        public Uri ImgSm { get; internal set; }
        public Uri ImgMd { get; internal set; }
        public Uri ImgLg { get; internal set; }
    }
}

