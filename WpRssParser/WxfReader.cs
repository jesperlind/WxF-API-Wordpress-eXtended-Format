using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    /// <summary>
    /// WxfReader
    /// </summary>
    public class WxfReader : RssReader
    {
        public new static WxfFeed Parse(string pathToXml)
        {
            return new WxfFeed(XDocument.Load(pathToXml));
        }
    }
}
