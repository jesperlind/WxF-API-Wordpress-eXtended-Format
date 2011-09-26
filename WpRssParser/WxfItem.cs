using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    /// <summary>
    /// Represents a WxfItem.
    /// </summary>
    public class WxfItem : RssItem
    {
        internal WxfItem(XElement element) : base(element)
        {
            Categories = new WxfItemCategoryCollection(XElement);
            Comments = new WxfCommentCollection(XElement);
        }

        public WxfItem()
            : base()
        {
            generateChildElements();
        }


        private void generateChildElements()
        {
            this.XElement.Add(new XElement(WxfNamespaces.dc + "creator"));
            this.XElement.Add(new XElement(WxfNamespaces.content + "encoded"));
            this.XElement.Add(new XElement(WxfNamespaces.excerpt + "encoded"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_id"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_date"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_date_gmt"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "comment_status"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "ping_status"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "status"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_parent"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "menu_order"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_type"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "post_password"));
        }

        public string Creator
        {
            get { return this.XElement.Element(WxfNamespaces.dc + "creator").Value; }
            set { this.XElement.Element(WxfNamespaces.dc + "creator").ReplaceNodes(new XCData(value)); }
        }

        public string Content
        {
            get { return this.XElement.Element(WxfNamespaces.content + "encoded").Value; }
            set { this.XElement.Element(WxfNamespaces.content + "encoded").ReplaceNodes(new XCData(value)); }
        }

        public XElement ContentAsXElement
        {
            get { return this.XElement.Element(WxfNamespaces.content + "encoded"); }
        }

        public WxfItemCategoryCollection Categories
        {
            get;
            set;
        }

        public string Excerpt
        {
            get { return this.XElement.Element(WxfNamespaces.excerpt + "encoded").Value; }
            set { this.XElement.Element(WxfNamespaces.excerpt + "encoded").Value = value; }
        }

        public string PostID
        {
            get { return this.XElement.Element(WxfNamespaces.wp+ "post_id").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "post_id").Value = value; }
        }

        public DateTime PostDate
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.wp + "post_date").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "post_date").Value = value.ToString(); }
        }

        public DateTime PostDateGmt
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.wp + "post_date_gmt").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "post_date_gmt").Value = value.ToString(); }
        }

        public string CommentStatus
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_status").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_status").Value = value; }
        }

        public string PingStatus
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "ping_status").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "ping_status").Value = value; }
        }

        public string Status
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "status").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "status").Value = value; }
        }

        public int PostParent
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.wp + "post_parent").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "post_parent").Value = value.ToString(); }
        }

        public int MenuOrder
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.wp + "menu_order").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "menu_order").Value = value.ToString(); }
        }

        public string PostType
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "post_type").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "post_type").Value = value; }
        }

        public string PostPassword
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "post_password").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "post_password").Value = value; }
        }

        public WxfCommentCollection Comments
        {
            get;
            protected set;
        }

        /// <summary>
        /// Cast to RssItem.
        /// </summary>
        /// <returns>A RssItem-object.</returns>
        public RssItem ToRssItem()
        {
            return this as RssItem;
        }
    }
}
