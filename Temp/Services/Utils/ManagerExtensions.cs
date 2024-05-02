using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using Temp.Services.Models;

namespace Temp.Services.Utils
{
    public static class ManagerExtensions
    {
        public static string AdjustData(this string data) 
        {
            var replaceable = new List<KeyValuePair<string, string>> 
            {
                new KeyValuePair<string, string>("1. open", "open"),
                new KeyValuePair < string, string >("2. high", "high"),
                new KeyValuePair < string, string >("3. low", "low"),
                new KeyValuePair < string, string >("4. close", "close"),
                new KeyValuePair < string, string >("5. volume", "volume"),
                new KeyValuePair < string, string >("1. Information", "Information"),
                new KeyValuePair < string, string >("2. Symbol", "Symbol"),
                new KeyValuePair < string, string >("3. Last Refreshed", "LastRefreshed"),
                new KeyValuePair < string, string >("4. Output Size", "OutputSize"),
                new KeyValuePair < string, string >("5. Time Zone", "TimeZone")
            };

            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            var modifiedString = new StringBuilder(data);

            foreach (var replacement in replaceable)
            {
                modifiedString.Replace(replacement.Key, replacement.Value);
            }

            return modifiedString.ToString();
        }

        public static string ConvertToString(this Interval interval) 
        {
            switch (interval) 
            {
                case Interval.onemin:
                    return "1min";
                case Interval.fivemin:
                    return "5min";
                case Interval.fifteenminutes:
                    return "15min";
                case Interval.thirtyminutes:
                    return "30min";
                case Interval.sixtyminutes:
                    return "60min";
                default:
                    throw new NotSupportedException();
            }
        }

        public static IEnumerable<FinancialData> ConvertToFinancialData(this JsonElement element)
        {
            try 
            {
                return JsonConvert.DeserializeObject<Dictionary<DateTime, Ohlvc>>(element.ToString())
                    .Select(x => new FinancialData
                    {
                        Open = x.Value.Open,
                        Close = x.Value.Close,
                        High = x.Value.High,
                        Low = x.Value.Low,
                        Volume = x.Value.Volume,
                        DateTime = x.Key
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }

            return Enumerable.Empty<FinancialData>();
        }
    }
}
