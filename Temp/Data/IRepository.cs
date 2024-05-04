using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Temp.Services.Models;

namespace Temp.Data
{
    public interface IRepository
    {
       IEnumerable<FinancialData> GetFinancialDataWithFilter(Expression<Func<FinancialData, bool>> filter);
       IEnumerable<FinancialData> GetAll();
    }
}
