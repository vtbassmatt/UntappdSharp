// 
// UntappdSharp is a .Net 4.0 library for calling the Untappd API
// The latest information and code for the project can be found at
// https://github.com/vtbassmatt/UntappdSharp
// 
// This project is licensed under the BSD license. See the License.txt file for
// more information.
using System;
using System.Runtime.Serialization;

namespace UntappdSharp
{
    public class UntappdApiException : Exception, ISerializable
    {
        public UntappdApiException () { }

        public UntappdApiException (Exception ex) : base("Generic error returned by UntappdSharp", ex) { }

        public UntappdApiException (string Message) : base(Message) { }

        public UntappdApiException (string Message, Exception ex) : base(Message, ex) { }
    }
}

