using System;
using System.Collections.Generic;
using System.IO;
using Temp.Services.Models;
using System.Text.Json;
using System.Linq;
using System.Linq.Expressions;

namespace Temp.Data
{

    public class Repository : IRepository
    {
        private readonly string _directoryPath;
        private IQueryable<FinancialData> _financialDatas;

        public Repository(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                _directoryPath = directoryPath;
                InitData();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<FinancialData> GetFinancialDataWithFilter(Expression<Func<FinancialData, bool>> filter)
        {
            return _financialDatas.Where(filter);
        }

        public IEnumerable<FinancialData> GetAll()
        {
            return _financialDatas;
        }

        private void InitData() 
        {
            var directoryFiles = Directory.GetFiles(_directoryPath);

            var loadedData = new List<FinancialData>();

            foreach (var file in directoryFiles)
            {
                using (var reader = new StreamReader(file))
                {
                    var json = reader.ReadToEnd();
                    loadedData.AddRange(JsonSerializer.Deserialize<IEnumerable<FinancialData>>(json));
                }
            }

            _financialDatas = loadedData.AsQueryable();
        }
    }
}
