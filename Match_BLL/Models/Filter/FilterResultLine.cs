using Match.ParsingCode;
using System.Collections.Generic;

namespace Match_BLL.Models
{
    public class FilterResultLine
    {
        public FilterResultLine(IEnumerable<BetType> types, Line line)
        {
            BetTypes = types;
            Line = line;
        }

        public IEnumerable<BetType> BetTypes { get; set; }
        public Line Line { get; set; }
    }
}
