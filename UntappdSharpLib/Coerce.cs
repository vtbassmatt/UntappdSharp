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
    public static class Coerce
    {
        public static Uri ToUri(string UriString)
        {
            if(null == UriString)
                return null;

            try
            {
                return new Uri(UriString);
            }
            catch(UriFormatException)
            {
                return null;
            }
        }

        public static bool ToBool(object From)
        {
            // null is treated as false
            if(null == From)
                return false;

            // booleans have their natural meaning
            if(From is bool)
                return (bool)From;

            // for integer types, 1 is true and all others are false
            if(From is int && From.Equals(1))
                return true;
            if(From is int)
                return false;

            // for strings, "1" and "true" are true, anything else is false
            if(From is string && (From.Equals("true") || From.Equals("1")))
                return true;
            if(From is string)
                return false;

            // any other type or value returns false
            return false;
        }

        public static int ToInt(object From)
        {
            if(null == From)
                return 0;

            if(From is int)
                return (int)From;

            int Val;
            Int32.TryParse(From.ToString(), out Val);
            return Val;
        }

        public static double ToDouble(object From)
        {
            if(null == From)
                return 0.0;

            if(From is double)
                return (double)From;

            double Val;
            Double.TryParse(From.ToString(), out Val);
            return Val;
        }

        public static decimal ToDecimal(object From)
        {
            if(null == From)
                return 0.0m;

            if(From is decimal)
                return (decimal)From;

            decimal Val;
            Decimal.TryParse(From.ToString(), out Val);
            return Val;
        }

        public static DateTime ToDateTime(object From)
        {
            if(null == From)
                return DateTime.MaxValue;

            try
            {
                return DateTime.Parse(From.ToString());
            }
            catch(FormatException)
            {
                return DateTime.MaxValue;
            }
        }
    }
}

