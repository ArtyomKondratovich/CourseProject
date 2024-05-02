using System.Windows.Forms.DataVisualization.Charting;

namespace Temp.Services.Utils
{
    public class QueryOptions
    {
        public TimeSeries SeriesType { get; set; }
        public DataType TypeOfData { get; set; }
        public Outsize Outsize { get; set; }
        public string Symbol { get; set; }
        public Interval Interval { get; set; }
        public string Month { get; set; } = null;
    }
}
