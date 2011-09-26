using System.Xml.Linq;
using Wxf;

namespace WxfLib
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
