using System;
using System.Xml.Serialization;

namespace Match.ParsingCode
{
    [Serializable]
    public enum BetType
    {
        [XmlEnum("1")]
        Home = 1,

        [XmlEnum("2")]
        Draw,

        [XmlEnum("3")]
        Away,

        [XmlEnum("4")]
        HomeOrDraw,

        [XmlEnum("5")]
        NotDraw,

        [XmlEnum("6")]
        AwayOrDraw,

        [XmlEnum("7")]
        HandicapHome,

        [XmlEnum("8")]
        HandicapAway,

        [XmlEnum("9")]
        TotalMore,

        [XmlEnum("10")]
        TotalLess,

        [XmlEnum("11")]
        ITHomeMore,

        [XmlEnum("12")]
        ITHomeLess,

        [XmlEnum("13")]
        ITAwayMore,

        [XmlEnum("14")]
        ITAwayLess

    }
}