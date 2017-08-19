using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Match.Models
{
    public class Line
    {
        public int Id { get; set; }

        public double Home { get; set; }

        public double Draw { get; set; }

        public double Away { get; set; }

        public double HomeOrDraw { get; set; }

        public double NotDraw { get; set; }

        public double AwayOrDraw { get; set; }

        public double Total { get; set; }

        public double TotalMore { get; set; }

        public double TotalLess { get; set; }

        public string HandicapValue { get; set; }

        public double HandicapHome { get; set; }

        public double HandicapAway { get; set; }

        public double ITHomeValue { get; set; }

        public double ITAwayValue { get; set; }

        public double ITHomeMore { get; set; }

        public double ITHomeLess { get; set; }

        public double ITAwayMore { get; set; }

        public double ITAwayLess { get; set; }
    }
}