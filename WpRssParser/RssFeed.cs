using System.Xml.Linq;
using Wxf;

namespace WxfLib
{
    /// <summary>
    /// RssFeed
    /// </summary>
    public class RssFeed
    {
        internal RssFeed(XDocument document)
        {
            XDocument = document;
            XElement = document.Element("rss");

            Channels = new RssChannelCollection(XElement);

            if (XElement.Name != "rss")
            {
                throw new WxfParseException();
            }
        }

        public RssFeed()
        {
            XDocument = new XDocument();

            this.XElement = new XElement("rss", new XAttribute("version", "2.0"));
            XDocument.Add(XElement);

            Channels = new RssChannelCollection(XElement);
        }

        public string Version 
        { 
            get { return XDocument.Element("rss").Attribute("version").Value; }
            set { XDocument.Element("rss").Attribute("version").Value = value; }
        }


        public new RssChannelCollection Channels
        {
            get;
            set;
        }

        public XElement XElement
        {
            get;
            set;
        }

        public void SaveXml(string fileName)
        {
            XDocument.Save(fileName);
        }

        public void Delete()
        {
            XDocument.Remove();
        }

        public XDocument XDocument
        {
            set;
            get;
        }

        public override string ToString()
        {
            return XDocument.ToString();
        }
    }
}
