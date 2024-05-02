using System;

namespace Temp.Services.Models
{
    public class CandlestickData
    {
        public long DateTicks { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}
