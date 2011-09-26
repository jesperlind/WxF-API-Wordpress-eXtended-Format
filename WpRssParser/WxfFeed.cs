using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    /// <summary>
    /// Represents a WxfFeed.
    /// </summary>
    public class WxfFeed : RssFeed
    {
        private XDocument _doc;
        private XElement _element;

        internal WxfFeed(XDocument document)
            : base(document)
        {
            _doc = document;
            _element = document.Element("rss");

            Channels = new WxfChannelCollection(_element);

            if (_element.Name != "rss")
            {
                throw new WxfParseException();
            }
        }

        public new WxfChannelCollection Channels
        {
            get;
            set;
        }

        public XElement XElement
        {
            get { return this._element; }
        }

        /// <summary>
        /// Cast to RssFeed.
        /// </summary>
        /// <returns>A RssFeed-object.</returns>
        public RssFeed ToRssFeed()
        {
            return this as RssFeed;
        }
    }
}
