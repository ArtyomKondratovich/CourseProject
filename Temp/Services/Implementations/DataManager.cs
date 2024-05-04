using System;
using Temp.Services.Interfaces;
using Temp.Services.Utils;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Temp.Services.Models;
using Temp.Data;
using System.Linq.Expressions;
using System.Threading;

namespace Temp.Services.Implementations
{
    public class DataManager : IDataManager
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IRepository _repositrory;

        public DataManager(string directoryPath) 
        {
            _repositrory = new Repository(directoryPath);
        }

        public IEnumerable<FinancialData> GetAll()
        {
            return _repositrory.GetAll();
        }

        public IEnumerable<FinancialData> GetfinancialDataWithFilter(Expression<Func<FinancialData, bool>> filter)
        {
            return _repositrory.GetFinancialDataWithFilter(filter);
        }

        public async Task<IEnumerable<FinancialData>> LoadDataWithUrlAsync(string url, CancellationToken token = default)
        {
            var response = await _client.GetAsync(url, token);

            var data = await response.Content.ReadAsStringAsync();

            var adjustedData = data.AdjustData();

            JsonProperty pointsProperty = new JsonProperty();

            var json = JsonDocument.Parse(adjustedData);

            var elements = json.RootElement.EnumerateObject();

            foreach (var element in elements)
            {
                if (element.Name != "Meta Data")
                {
                    pointsProperty = element;
                }
            }

            return pointsProperty.Value.ConvertToFinancialData();
        }
    }
}
