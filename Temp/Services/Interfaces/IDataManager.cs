using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Temp.Services.Models;

namespace Temp.Services.Interfaces
{
    public interface IDataManager
    {
        Task<IEnumerable<FinancialData>> LoadDataWithUrlAsync(string url, CancellationToken token = default);
        Task<IEnumerable<FinancialData>> GetAllAsync(CancellationToken token = default);
        Task<IEnumerable<FinancialData>> GetDataWithFilter(Expression<Func<FinancialData, bool>> filter, CancellationToken token = default);
        Task CreateDataAsync(IEnumerable<FinancialData> data, CancellationToken token = default);
    }
}
