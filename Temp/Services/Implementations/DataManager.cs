using System;
using Temp.Services.Interfaces;
using Temp.Services.Utils;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Temp.Services.Models;
using System.Linq;
using Temp.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Temp.Services.Implementations
{
    public class DataManager : IDataManager
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly CourseProjectDbContext _dbContext;

        public DataManager()
        {
            _dbContext = new CourseProjectDbContext();
        }

        public async Task<IEnumerable<FinancialData>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.FinancialData
                .ToListAsync(token);
        }

        public async Task<IEnumerable<FinancialData>> GetDataWithFilter(Expression<Func<FinancialData, bool>> filter, CancellationToken token = default)
        {
            return await _dbContext.FinancialData
                .Where(filter)
                .ToListAsync(token);
        }

        public async Task CreateDataAsync(IEnumerable<FinancialData> data, CancellationToken token = default)
        {
            await _dbContext.FinancialData.AddRangeAsync(data, token);
            await _dbContext.SaveChangesAsync(token);
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
