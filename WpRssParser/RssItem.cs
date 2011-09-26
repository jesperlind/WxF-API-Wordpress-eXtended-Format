using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// RssItem
    /// </summary>
    public class RssItem : IRssNode
    {
        public RssItem(XElement element)
        {
            XElement = element;

            if (Title == null)
            {
                throw new WxfParseException();
            }
        }

        public RssItem()
        {
            XElement = new XElement("item");

            generateChildElements();
        }

        private void generateChildElements()
        {
            this.XElement.Add(new XElement("title"));
            this.XElement.Add(new XElement("link"));
            this.XElement.Add(new XElement("description"));
            this.XElement.Add(new XElement("pubDate"));
            this.XElement.Add(new XElement("guid"));
        }

        public string Title
        {
            get { return this.XElement.Element("title").Value; }
            set { this.XElement.Element("title").Value = value; }
        }

        public Uri Link
        {
            get { return new Uri(this.XElement.Element("link").Value); }
            set
            {
                if (this.XElement.Elements("link") == null)
                {
                    this.XElement.Add(new XElement("link"));
                }

                this.XElement.Element("link").Value = value.AbsoluteUri;
            }
        }

        public string Description
        {
            get
            {
                var node = this.XElement.Element("description");
                return node.Value;
            }

            set { this.XElement.Element("description").Value = value; }
        }

        public DateTime PublishingDate
        {
            get { return DateTime.Parse(this.XElement.Element("pubDate").Value); }
            set { this.XElement.Element("pubDate").Value = value.ToString(); }
        }

        public string Guid
        {
            get
            {
                var node = this.XElement.Element("guid");
                return node.Value;
            }

            set { this.XElement.Element("guid").Value = value; }
        }

        public void Detach()
        {
            XElement.Remove();    
        }        

        public RssChannel ParentChannel
        {
            get;
            set;
        }

        public XElement XElement
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return this.XElement.ToString();
        }
    }
}
