using System;
using System.Collections.Generic;
using Temp.Services.Models;

namespace Temp.Services.Utils
{
    public static class Mapper
    {
        public static CandlestickData ConvertFromDataPoint(this FinancialData point) 
        {
            return new CandlestickData
            {
                DateTicks = point.DateTime.Ticks,
                Open = point.Open,
                Close = point.Close,
                High = point.High,
                Low = point.Low
            };
        }
    }
}
