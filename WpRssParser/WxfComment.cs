using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// Represents a WxfComment.
    /// </summary>
    public class WxfComment : IRssNode
    {
        internal WxfComment(XElement element)
        {
            XElement = element;
        }
        
        public string ID
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_id").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_id").Value = value; }
        }

        public string Author
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_author").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_author").Value = value; }
        }

        public string Email
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_author_email").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_author_email").Value = value; }
        }

        public string Url
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_author_url").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_author_url").Value = value; }
        }

        public IPAddress IP
        {
            get { return IPAddress.Parse(this.XElement.Element(WxfNamespaces.wp + "comment_author_IP").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_author_IP").Value = value.ToString(); }
        }

        public DateTime Date
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.wp + "comment_date").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_date").Value = value.ToString(); }
        }

        public DateTime DateGMT
        {
            get { return DateTime.Parse(this.XElement.Element(WxfNamespaces.wp + "comment_date_gmt").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_date_gmt").Value = value.ToString(); }
        }

        public string Content
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_content").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_content").Value = value; }
        }

        public string Approved
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_approved").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_approved").Value = value; }
        }

        public string Type
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "comment_type").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_type").Value = value; }
        }

        public int Parent
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.wp + "comment_parent").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_parent").Value = value.ToString(); }
        }

        public int UserID
        {
            get { return int.Parse(this.XElement.Element(WxfNamespaces.wp + "comment_user_id").Value); }
            set { this.XElement.Element(WxfNamespaces.wp + "comment_user_id").Value = value.ToString(); }
        }

        public void Detach()
        {
            this.XElement.Remove();
        }

        public XElement XElement
        {
            get;
            set;
        }
    }
}
