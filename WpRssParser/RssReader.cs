using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// RssReader
    /// </summary>
    public class RssReader
    {
        public static RssFeed Parse(string pathToXml)
        {
            return new RssFeed(XDocument.Load(pathToXml));
        }
    }
}
