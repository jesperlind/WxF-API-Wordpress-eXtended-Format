using System;
using System.Xml.Linq;
using Wxf;

namespace WxfLib
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
            GenerateChildElements();
        }


        private void GenerateChildElements()
        {
            this.XElement.Add(new XElement(WxfNamespaces.Dc + "creator"));
            this.XElement.Add(new XElement(WxfNamespaces.Content + "encoded"));
            this.XElement.Add(new XElement(WxfNamespaces.Excerpt + "encoded"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_id"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_date"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_date_gmt"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "comment_status"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "ping_status"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "status"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_parent"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "menu_order"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_type"));
            this.XElement.Add(new XElement(WxfNamespaces.Wp + "post_password"));
        }

        //private XElement CreateElement(XNamespace wpNamespace )
        //{
        //    return new XElement(wpNamespace + "1.1",
        //                 new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
        //                 new XAttribute(xsi + "schemaLocation",
        //                                "http://www.foo.bar someSchema.xsd")
        //        );
        //}

        public string Creator
        {
            get { return this.XElement.Element(WxfNamespaces.Dc + "creator").Value; }
            set { this.XElement.Element(WxfNamespaces.Dc + "creator").ReplaceNodes(new XCData(value)); }
        }

        public string Content
        {
            get { return this.XElement.Element(WxfNamespaces.Content + "encoded").Value; }
            set { this.XElement.Element(WxfNamespaces.Content + "encoded").ReplaceNodes(new XCData(value)); }
        }

        public XElement ContentAsXElement
        {
            get { return this.XElement.Element(WxfNamespaces.Content + "encoded"); }
        }

        public WxfItemCategoryCollection Categories
        {
            get;
            set;
        }

        public string Excerpt
        {
            get { return this.XElement.Element(WxfNamespaces.Excerpt + "encoded").Value; }
            set { this.XElement.Element(WxfNamespaces.Excerpt + "encoded").Value = value; }
        }

        public string PostID
        {
            get { return this.XElement.Element(WxfNamespaces.Wp+ "post_id").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_id").Value = value; }
        }

        public DateTime PostDate
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.Wp + "post_date").Value); }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_date").Value = value.ToString(); }
        }

        public DateTime PostDateGmt
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.Wp + "post_date_gmt").Value); }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_date_gmt").Value = value.ToString(); }
        }

        public string CommentStatus
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "comment_status").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "comment_status").Value = value; }
        }

        public string PingStatus
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "ping_status").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "ping_status").Value = value; }
        }

        public string Status
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "status").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "status").Value = value; }
        }

        public int PostParent
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.Wp + "post_parent").Value); }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_parent").Value = value.ToString(); }
        }

        public int MenuOrder
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.Wp + "menu_order").Value); }
            set { this.XElement.Element(WxfNamespaces.Wp + "menu_order").Value = value.ToString(); }
        }

        public string PostType
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "post_type").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_type").Value = value; }
        }

        public string PostPassword
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "post_password").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "post_password").Value = value; }
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
