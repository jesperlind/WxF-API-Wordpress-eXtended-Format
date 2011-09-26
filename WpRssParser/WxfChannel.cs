using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
   /// <summary>
    /// Represents a WxfChannel.
   /// </summary>
    public class WxfChannel : RssChannel
    {
        private XElement _element;

        internal WxfChannel(XElement element) : base(element)
        {  
            _element = element;

            Tags = new WxfTagCollection(XElement);
            Items = new WxfItemCollection(XElement);
            Categories = new WxfCategoryCollection(XElement);

            if (this.Title == null)
            {
                throw new WxfParseException();
            }
        }

        public WxfImage Image
        {
            get { return new WxfImage(XElement.Element("image")); }
        }
        
        public string WxrVersion
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "wxr_version").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "wxr_version").Value = value; }
        }

        public string BaseSiteUrl
        {
            get
            {
                return this.XElement.Element(WxfNamespaces.wp + "base_site_url").Value;
            }

            set { this.XElement.Element(WxfNamespaces.wp + "base_site_url").Value = value; }
        }

        public string BaseBlogUrl
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "base_blog_url").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "base_blog_url").Value = value; }
        }

        public WxfTagCollection Tags
        {
            get;
            protected set;
        }

        public WxfCategoryCollection Categories
        {
            get;
            protected set;
        }

        public new WxfItemCollection Items
        {
            get;
            protected set;
        }

        /// <summary>
        /// Cast to RssChannel.
        /// </summary>
        /// <returns>A RssChannel-object.</returns>
        public RssChannel AsRssChannel()
        {
            return this as RssChannel;
        }
    }
}
