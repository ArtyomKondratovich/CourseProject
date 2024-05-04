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
        IEnumerable<FinancialData> GetAll();
        IEnumerable<FinancialData> GetfinancialDataWithFilter(Expression<Func<FinancialData, bool>> filter);
    }
}