using System;
using System.Linq.Expressions;
using Temp.Services.Models;

namespace Temp.Services.Utils
{
    public static class Expressions
    {
        public static Expression<Func<FinancialData, bool>> GetInRangeFilter(DateTime start, DateTime end)
        {
            if (start < end)
            {
                throw new ArgumentException();
            }

            return (x) => x.DateTime >= end && x.DateTime <= start;
        }
    }
}
