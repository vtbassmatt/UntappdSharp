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
using System.Net;
using System.IO;
using System.Collections.Generic;
using UntappdSharp;

namespace UtConsole
{
    class MainClass
    {
        private static Untappd u;
        public static void Main (string[] args)
        {
            string command = "", line;
            string[] tokens = null;

            string apiKey = LoadSecret("apikey"),
                   username = LoadSecret("username"),
                   password = LoadSecret("password");

            u = new Untappd(apiKey);
            u.SetCredentials(username, password);

            Console.WriteLine("Welcome to UtConsole.");

            Prompt();
            while(!command.Equals("exit"))
            {
                line = Console.ReadLine();
                tokens  = line.Split(' ');
                if(tokens.Length > 0)
                {
                    command = tokens[0];
                } else {
                   command = "";
                }

                switch(command)
                {
                    case "exit":
                        continue;
                    case "beer":
                        cmdBeer(tokens);
                        break;
                    case "help":
                        Console.WriteLine(@"Available commands are:
beer <beerid>
help
exit");
                        break;
                    default:
                        Err("Command not recognized, try 'help' for help");
                        break;
                }
                Prompt();
            }
            Console.WriteLine("Thank you for flying UtConsole, we hope to see you on a future journey.");
        }

        private static void Prompt()
        {
            Console.Write("> ");
        }

        private static void Err(string ErrMessage)
        {
            Console.WriteLine("*** {0}", ErrMessage);
        }

        private static void cmdBeer(string[] tokens)
        {
            if(tokens.Length >= 2)
            {
                try {
                    int beerId = Int32.Parse(tokens[1]);
                    UtBeer info = u.BeerInfo(beerId);
                    Console.WriteLine(string.Format(@"Beer #{0}: {1}
Brewery #{2}: {3}
Count: TOTAL  UNIQUE   MONTH    WEEK    YOUR
    {4,8}{5,8}{6,8}{7,8}{8,8}",
                        info.BeerId,info.Name,info.BreweryId,info.Brewery,
                        info.TotalCount,info.UniqueCount,info.MonthlyCount,info.WeeklyCount,info.YourCount));
                } catch(UntappdApiException ex) {
                    Err("Untappd API exception:");
                    Err(ex.Message);
                    Err(ex.InnerException.Message);
                    Err(ex.InnerException.StackTrace);
                } catch(Exception ex) {
                    Err("General exception:");
                    Err(ex.Message);
                    Err(ex.StackTrace);
                }
            } else {
                Err("Expected one argument: <beerid> (integer)");
            }
        }

        #region oldmain
        private static void OldMain (string[] args)
        {
            Console.WriteLine ("Hello World!");

            string apiKey = LoadSecret("apikey"),
                   username = LoadSecret("username"),
                   password = LoadSecret("password");

            Untappd u = new Untappd(apiKey);
            u.SetCredentials(username, password);

            //UtUser vtbassmatt = u.User("vtbassmatt");
            //Console.WriteLine(vtbassmatt.Uid + " : " + vtbassmatt.UserName);

            //UtUser suewho = u.User("suewho");
            //Console.WriteLine(suewho.Uid + " : " + suewho.UserName);

            UtUser me = u.User();
            Console.WriteLine("I am " + me.UserName);

            //UtUser blah = u.User("1");
            //Console.WriteLine(blah.FirstName);

            //UtUserFeed feed = u.UserFeed();
            //Console.WriteLine("checkin " + feed.Feed[0].CheckinId + " by " + feed.Feed[0].User.Uid);

            //UtBeer beer = u.BeerInfo(1);
            //Console.WriteLine(beer.Name);

            //UtBrewery brewery = u.BreweryInfo(1);
            //Console.WriteLine(brewery.Name);
            //foreach(var tBeer in brewery.TopBeers)
            //{
            //    Console.WriteLine("\t" + tBeer.BeerName);
            //}

            //UtFriends friends = u.Friends("suewho");
            //Console.WriteLine("suewho has " + friends.ReturnedResults + " friends");

            //CheckinOptions opt = new CheckinOptions()
            //{
            //    Timezone = TimeZoneInfo.Local,
            //    BeerId = 1,
            //};
            //UtCheckin checkin = u.CheckinTest(opt);
            //Console.WriteLine(checkin.CheckinTotal.Beer);
            //Console.WriteLine(checkin.Recommendations[0].Name);

            // *******************************
            // REAL CHECKIN - EXERCISE CAUTION
            // *******************************
            //CheckinOptions opt = new CheckinOptions()
            //{
            //    Timezone = TimeZoneInfo.Local,
            //    BeerId = 32691,
            //};
            //UtCheckin checkin = u.Checkin(opt);
            //Console.WriteLine(checkin.CheckinTotal.Beer);
            //Console.WriteLine(checkin.Recommendations[0].Name);

            UtBeerSearch search = u.BeerSearch("sam adams");
            foreach(var sBeer in search.Results)
            {
                Console.WriteLine(sBeer.BeerName);
            }


            Console.Read();
        }
        #endregion

        private static Dictionary<string,string> _Secrets;
        private static string LoadSecret(string Index)
        {
            if(null == _Secrets)
            {
                _Secrets = new Dictionary<string, string>();
                string text = File.ReadAllText("secrets.txt");
                foreach(string line in text.Split('\n'))
                {
                    string[] items = line.Split(new char[] {'|'}, 2);
                    if(2 == items.Length)
                    {
                        _Secrets.Add(items[0], items[1]);
                    }
                }
            }

            return _Secrets[Index];
        }
    }
}

