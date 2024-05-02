using System.Text;
using Temp.Services.Utils;

namespace Temp.Services.Implementations
{
    public class UrlManager : IUrlManager
    {
        private readonly string _apiBaseUrl;
        private readonly string _apiKey;

        public UrlManager(string baseUrl, string apiKey) 
        {
            _apiBaseUrl = baseUrl;
            _apiKey = apiKey;
        }

        public string GetUrlWithOptions(QueryOptions options)
        {
            if (_apiBaseUrl == null || _apiKey == null)
            {
                return null;
            }

            var url = new StringBuilder(_apiBaseUrl);
            url.Append("/query?");

            switch (options.SeriesType)
            {
                case TimeSeries.TIME_SERIES_INTRADAY:
                    url.Append($"function={options.SeriesType}")
                        .Append($"&symbol={options.Symbol}")
                        .Append($"&interval={ManagerExtensions.ConvertToString(options.Interval)}")
                        .Append(options.Month != null ? $"&month={options.Month}" : "")
                        .Append($"&outsize={options.Outsize}");
                    break;
                case TimeSeries.TIME_SERIES_DAILY:
                    url.Append($"function={options.SeriesType}")
                        .Append($"&symbol={options.Symbol}")
                        .Append($"&outsize={options.Outsize}");
                    break;
            }

            url.Append($"&apikey={_apiKey}");
            return url.ToString();
        }
    }
}