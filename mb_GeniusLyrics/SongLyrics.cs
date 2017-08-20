/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Parser.Html;
using Genius;

// client access token: gxJMvRz5fQeA3H_5-dcGeJMFrP-Llo4AN7dU03SraVIytb8QZIp8gpmJtVDGCGk1
namespace mb_GeniusLyrics
{
    class SongLyrics
    {
        static void Main(string[] args)
        {
            ContentRetriever.AuthorizationToken = "gxJMvRz5fQeA3H_5-dcGeJMFrP-Llo4AN7dU03SraVIytb8QZIp8gpmJtVDGCGk1";
            String artist = "Kodak Black";
            String song = "Change My Ways";
            String songUrl = null;
            Console.WriteLine("Hello World");
            songUrl = getSongInfo(artist, song);
            getLyrics(songUrl);
        }

        static String getSongInfo(String artist, String song)
        {
            Search.AuthenticationToken = "gxJMvRz5fQeA3H_5-dcGeJMFrP-Llo4AN7dU03SraVIytb8QZIp8gpmJtVDGCGk1";
            Search.SearchTerm = artist + " " + song;

            var hits = Search.DoSearch();
            return hits.Result.ElementAt(0).Result.Url;
        }

        // The format of each tag is: meta name="og:title" content="In a World..."
        // genius tag: lyrics
        static void getLyrics(string url)
        {
            var parser = new HtmlParser();
            WebResponse response = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var result = parser.Parse(reader.ReadToEnd());
                var lyrics = result.DocumentElement.GetElementsByClassName("lyrics").ElementAt(0).TextContent;
                Console.WriteLine(lyrics);

            }
            catch (Exception ex)
            {
                // handle error
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
            }
        }
    }
}
*/