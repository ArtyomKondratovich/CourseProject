using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temp.Configuration;
using Temp.Services;
using Temp.Services.Implementations;
using Temp.Services.Interfaces;
using Temp.Services.Models;
using Temp.Services.Utils;
using System.Linq;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Temp
{
    public partial class Form1 : Form
    {
        private readonly IJsonConfiguration _config;
        private readonly IUrlManager _urlManager;
        private readonly IDataManager _dataManager;

        private QueryOptions _queryOptions = new QueryOptions 
        {
            SeriesType = TimeSeries.TIME_SERIES_DAILY,
            Outsize = Outsize.compact,
            Symbol = "EPAM",
            TypeOfData = DataType.json
        };

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            

            MinimumSize = new Size(800, 600);

            #region DI

            _config = new JsonConfiguration();
            _config.AddJsonFile("appsettings.personal.json", true);
            //_config.AddJsonFile("config.json", true);
            //_urlManager = new UrlManager(_config["API_BASE_URL"], _config["API_KEY"]);
            _dataManager = new DataManager(_config["DataSource"]);

            #endregion
        }

        private void PrintCnadlestickChart(IEnumerable<FinancialData> points)
        {
            var plotModel = new PlotModel
            {
                Title = "CandlestickSeries",
                Subtitle = "Financial Data",
            };

            // Prepare the data
            var candlestickItems = new List<HighLowItem>();

            points = points.OrderBy(x => x.DateTime).ToList();

            foreach (var point in points)
            {
                
                var item = new HighLowItem
                {
                    X = DateTimeAxis.ToDouble(point.DateTime),
                    Close = point.Close,
                    High = point.High,
                    Low = point.Low,
                    Open = point.Open
                };

                candlestickItems.Add(item);
            }

            var candlestickSeries = new CandleStickSeries
            {
                Title = "Candlestick",
                Color = OxyColors.Black,
                IncreasingColor = OxyColors.Green,
                DecreasingColor = OxyColors.Red,
                TrackerFormatString = "DateTime: {2:yyyy-MM-dd HH:mm:ss}\nOpen: {3}\nHigh: {4}\nLow: {5}\nClose: {6}"
            };

            // Add the data to the series
            candlestickSeries.Items.AddRange(candlestickItems);

            // Add the series to the plot model
            plotModel.Series.Add(candlestickSeries);

            plotView1.Model = plotModel;
        }

        private void OneDay_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddDays(-1);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void FiveDays_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddDays(-5);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void OneMonth_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddMonths(-1);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void ThreeMonth_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddMonths(-3);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void SixMonth_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddMonths(-6);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private async void CurrentYear_Click(object sender, EventArgs e)
        {}

        private void OneYear_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddYears(-1);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void TwoYears_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddYears(-2);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private void FiveYears_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            var end = start.AddYears(-5);
            var filter = Expressions.GetInRangeFilter(start, end);
            var filteredData = _dataManager.GetfinancialDataWithFilter(filter);

            PrintCnadlestickChart(filteredData);
        }

        private async Task LoadAndSaveAllEpamData() 
        {
            _queryOptions.SeriesType = TimeSeries.TIME_SERIES_INTRADAY;
            _queryOptions.Outsize = Outsize.full;
            _queryOptions.Interval = Interval.onemin;
            _queryOptions.Symbol = "EPAM";
            _queryOptions.TypeOfData = DataType.json;
            
            var currentMounth = DateTime.Now;
            var directoryPath = _config["DATA_PATH"];

            for (int i = 0; i < 25; i++)
            {
                _queryOptions.Month = currentMounth.AddMonths(-i).ToString("yyyy-MM");
                var url = _urlManager.GetUrlWithOptions(_queryOptions);
                var loadedFinancialData = await _dataManager.LoadDataWithUrlAsync(url);

                var fileName = Path.Combine(directoryPath, _queryOptions.Month + ".json");

                using (var file = File.CreateText(fileName)) 
                {
                    var serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, loadedFinancialData);
                }
            }
        }

        private void InitializeChart() 
        {
            
        }

        private IEnumerable<HighLowItem> GetVisibleDataPoints(PlotView plotView)
        {
            var plotArea = plotView.ActualModel.PlotArea;
            var xAxis = plotView.ActualModel.Axes.FirstOrDefault(a => a.Position == AxisPosition.Bottom);
            var yAxis = plotView.ActualModel.Axes.FirstOrDefault(a => a.Position == AxisPosition.Left);

            if (xAxis != null && yAxis != null)
            {
                var xMin = xAxis.InverseTransform(plotArea.Left);
                var xMax = xAxis.InverseTransform(plotArea.Right);
                var yMin = yAxis.InverseTransform(plotArea.Bottom);
                var yMax = yAxis.InverseTransform(plotArea.Top);

                foreach (var series in plotView.ActualModel.Series)
                {
                    if (series is CandleStickSeries candleStick)
                    {
                        var items = candleStick.Items;

                        return items.Where(item => item.High <= yMax && item.Low >= yMin && item.X >= xMin && item.X <= xMax);
                    }
                }
            }

            return Enumerable.Empty<HighLowItem>();
        }
    }
}
