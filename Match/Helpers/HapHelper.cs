using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using Match.ParsingCode;

namespace Match.Helpers
{
    public static class HapHelper
    {
        public static HtmlNode GetChildNodeByAttribute(HtmlNode parent, string attr, string value)
        {
            return parent.Descendants()
                .Where(n =>
                !string.IsNullOrEmpty(n.Attributes[attr]?.Value)
                && n.Attributes[attr].Value.Contains(value))
                .First();
        }

        public static HtmlNode GetChildNodeByAttribute( HtmlNode parent, string element, string attr, string value)
        {
            return parent.Descendants( element )
                .Where(n =>
                !string.IsNullOrEmpty(n.Attributes[attr]?.Value)
                && n.Attributes[attr].Value.Contains(value))
                .First();
        }


        public static List<HtmlNode> GetAllChildNodeByAttribute(HtmlNode parent, string attr, string value)
        {
            return parent.Descendants()
                .Where(n =>
                !string.IsNullOrEmpty(n.Attributes[attr]?.Value)
                && n.Attributes[attr].Value.Contains(value))
                .ToList();
        }

        public static List<HtmlNode> GetAllChildNodeByAttribute(HtmlNode parent, string element, string attr, string value)
        {
            return parent.Descendants(element)
                .Where(n =>
                !string.IsNullOrEmpty(n.Attributes[attr]?.Value)
                && n.Attributes[attr].Value.Contains(value))
                .ToList();
        }


        public static bool IsContainsAttr(HtmlNode node, string attr, string value)
        {
            return !string.IsNullOrEmpty(node.Attributes[attr]?.Value)
                && node.Attributes[attr]?.Value == value;
        }

    }
}