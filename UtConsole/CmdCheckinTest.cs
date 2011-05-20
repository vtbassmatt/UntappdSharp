// 
//  Author:
//    Matt Cooper vtbassmatt@gmail.com
// 
//  Copyright (c) 2011, Matt Cooper
// 
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//     * Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
using System;
using UntappdSharp;

namespace UtConsole
{
    public class CmdCheckinTest : ICommand
    {
        public CmdCheckinTest ()
        {
        }

        #region ICommand implementation
        public void Run (UntappdSharp.Untappd U, string[] tokens)
        {
            if(tokens.Length >= 2)
            {
                try {
                    int beerId = Int32.Parse(tokens[1]);
                    CheckinOptions opt = new CheckinOptions();
                    opt.BeerId = beerId;
                    opt.Timezone = TimeZoneInfo.Local;
                    UtCheckin chk = U.CheckinTest(opt);
                    Console.WriteLine(string.Format(@"Checkin #{0}: {1}
Beer #{2}: {3}
Total checkins for this beer: {4}
Total checkins for this beer this month: {5}
Checked in at: {6} in {7}, {8}",
                        chk.CheckinDetails.CheckinId, chk.CheckinDetails.Shout,
                        chk.BeerDetails.BeerId, chk.BeerDetails.BeerName,
                        chk.CheckinTotal.Beer, chk.CheckinTotal.BeerMonth,
                        chk.FoursquareDetails.Name, chk.FoursquareDetails.City, chk.FoursquareDetails.State));
                } catch(UntappdApiException ex) {
                    UtConsole.Err("Untappd API exception:");
                    UtConsole.Err(ex.Message);
                    UtConsole.Err(ex.InnerException.Message);
                    UtConsole.Err(ex.InnerException.StackTrace);
                } catch(Exception ex) {
                    UtConsole.Err("General exception:");
                    UtConsole.Err(ex.Message);
                    UtConsole.Err(ex.StackTrace);
                }
            } else {
                UtConsole.Err("Expected one argument: <beerid> (integer)");
            }        }

        public string Verb ()
        {
            return "checkin_test";
        }

        public string Usage ()
        {
            return "checkin_test <beerid>";
        }
        #endregion
    }
}

