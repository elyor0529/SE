using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Http;
using Google.Apis.Json;
using Google.Apis.Services;
using Newtonsoft.Json;

namespace SE.Cmd
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            const string apiKey = "AIzaSyAt8AkrmkiLVghrcKA3lFh37R79rSG0NsE";
            const string searchEngineId = "003470263288780838160:ty47piyybua";
            const string query = "c#";
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                GZipEnabled = true,
                DefaultExponentialBackOffPolicy = ExponentialBackOffPolicy.None,
                Serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented,
                    DateParseHandling = DateParseHandling.DateTime,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                })
            });
            var listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;

            Console.WriteLine("Start...");
            IList<Result> paging = new List<Result>();
            var count = 0;
            while (paging != null)
            {
                Console.WriteLine($"Page {count}");
                listRequest.Start = count * 10 + 1;
                paging = listRequest.Execute().Items;
                if (paging != null)
                    foreach (var item in paging)
                    { 
                        Console.WriteLine("Title : " + item.Title + Environment.NewLine + "Link : " + item.Link + Environment.NewLine + Environment.NewLine);
                    }
                count++;
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
