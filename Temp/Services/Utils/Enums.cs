using System;
using System.Collections.Generic;
namespace Temp.Services.Utils
{
    public enum TimeSeries
    {
        TIME_SERIES_INTRADAY,
        TIME_SERIES_DAILY,
        TIME_SERIES_DAILY_ADJUSTED,
        TIME_SERIES_WEEKLY,
        TIME_SERIES_WEEKLY_ADJUSTED,
        TIME_SERIES_MONTHLY,
        TIME_SERIES_MONTHLY_ADJUSTED,
    }

    public enum DataType
    {
        json,
        csv
    }

    public enum TechnicalIndicators
    {

    }

    public enum Outsize
    {
        compact,
        full
    }

    public enum Interval 
    {
        onemin,
        fivemin,
        fifteenminutes,
        thirtyminutes,
        sixtyminutes
    }
}
