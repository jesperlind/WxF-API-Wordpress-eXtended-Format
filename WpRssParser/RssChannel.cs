using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// RssChannel
    /// </summary>
    public class RssChannel : IRssNode
    {
        internal RssChannel(XElement element)
        {
            XElement = element;
            Items = new RssItemCollection(XElement);

            if (this.Title == null)
            {
                throw new Exception();
            }
        }

        public RssChannel()
        {
            XElement = new XElement("channel");
            Items = new RssItemCollection(XElement);

            generateParentElements();
        }

        private void generateParentElements()
        {
            this.XElement.Add(new XElement("title"));
            this.XElement.Add(new XElement("link"));
            this.XElement.Add(new XElement("description"));
            this.XElement.Add(new XElement("pubDate"));
            this.XElement.Add(new XElement("lastBuildDate"));
            this.XElement.Add(new XElement("generator"));
            this.XElement.Add(new XElement("language"));
            this.XElement.Add(new XElement("docs"));
            this.XElement.Add(new XElement("managingEditor"));
            this.XElement.Add(new XElement("webMaster"));
            this.XElement.Add(new XElement("ttl"));
        }

        public string Title
        {
            get 
            {
                if (this.XElement.Elements("title") == null)
                {
                    this.XElement.Add(new XElement("title"));
                }

                return this.XElement.Element("title").Value; 
            }
            set 
            {
                if (this.XElement.Elements("title") == null)
                {
                    this.XElement.Add(new XElement("title"));
                }

                this.XElement.Element("title").Value = value; 
            }
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

            set 
            {
                if (this.XElement.Elements("description") == null)
                {
                    this.XElement.Add(new XElement("description"));
                }

                this.XElement.Element("description").Value = value; 
            }
        }

        public DateTime PublishingDate
        {
            get { return DateTime.Parse(this.XElement.Element("pubDate").Value); }
            set { this.XElement.Element("pubDate").Value = value.ToString(); }
        }

        public DateTime LastBuildDate
        {
            get { return DateTime.Parse(this.XElement.Element("lastBuildDate").Value); }
            set 
            {
                if (this.XElement.Elements("lastBuildDate") == null)
                {
                    this.XElement.Add(new XElement("lastBuildDate"));
                }

                this.XElement.Element("lastBuildDate").Value = value.ToString(); 
            }
        }

        public string Generator
        {
            get { return this.XElement.Element("generator").Value; }
            set 
            {
                if (this.XElement.Elements("generator") == null)
                {
                    this.XElement.Add(new XElement("generator"));
                }

                this.XElement.Element("generator").Value = value; 
            }
        }

        public string Language
        {
            get { return this.XElement.Element("language").Value; }
            set 
            {
                if (this.XElement.Elements("language") == null)
                {
                    this.XElement.Add(new XElement("language"));
                }

                this.XElement.Element("language").Value = value; 
            }
        }

        public string Docs
        {
            get { return this.XElement.Element("docs").Value; }
            set 
            {
                if (this.XElement.Elements("docs") == null)
                {
                    this.XElement.Add(new XElement("docs"));
                }

                this.XElement.Element("docs").Value = value; 
            }
        }

        public string ManagingEditor
        {
            get { return this.XElement.Element("managingEditor").Value; }
            set 
            {
                if (this.XElement.Elements("managingEditor") == null)
                {
                    this.XElement.Add(new XElement("managingEditor"));
                }

                this.XElement.Element("managingEditor").Value = value; 
            }
        }

        public string WebMaster
        {
            get { return this.XElement.Element("webMaster").Value; }
            set 
            {
                if (this.XElement.Elements("webMaster") == null)
                {
                    this.XElement.Add(new XElement("webMaster"));
                }

                this.XElement.Element("webMaster").Value = value; 
            }
        }

        public int TimeToLive
        {
            get { return int.Parse(this.XElement.Element("ttl").Value); }
            set 
            {
                if (this.XElement.Elements("ttl") == null)
                {
                    this.XElement.Add(new XElement("ttl"));
                }

                this.XElement.Element("ttl").Value = value.ToString(); 
            }
        }

        public RssItemCollection Items
        {
            get;
            protected set;
        }

        public RssFeed ParentFeed
        {
            get;
            internal set;
        }

        public XElement XElement
        {
            get;
            protected set;
        }

        public void Detach()
        {
            XElement.Remove();
        }

        public override string ToString()
        {
            return this.XElement.ToString();
        }
    }
}
