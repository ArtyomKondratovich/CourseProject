using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Temp.Services.Models;

namespace Temp.Data
{
    public class Repository : IRepository
    {

        public Task<IEnumerable<FinancialData>> GetFinancialDataInRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
