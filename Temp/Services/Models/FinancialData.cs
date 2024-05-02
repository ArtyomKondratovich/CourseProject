using System;
using System.ComponentModel.DataAnnotations;

namespace Temp.Services.Models
{
    public class FinancialData
    {
        [Key]
        public DateTime DateTime { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public override string ToString()
        {
            return $"\tOpen: {Open}\n\tHight: {High}\n\tLow: {Low}\n\tClose: {Close}\n\tVolume: {Volume}";
        }
    }
}
