using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    public class WxfTag : IRssNode
    {
        private XElement _element;

        internal WxfTag(XElement element)
        {
            _element = element;

            if (Name == null)
            {
                throw new WxfParseException();
            }
        }

        public WxfTag(string name)
        {
            _element = new XElement(WxfNamespaces.wp + "tag");

            this.Name = name;
        }

        public static WxfTag Parse(XElement element)
        {
            return new WxfTag(element);
        }

        public string Name
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "tag_name").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "tag_name").Value = value; }
        }

        public string Slug
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "tag_slug").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "tag_slug").Value = value; }
        }

        public void Detach()
        {
            detachFromParent();
        }

        internal void detachFromParent()
        {
            XElement.Remove();
        }

        public XElement XElement
        {
            get { return this._element; }
        }

        public override string ToString()
        {
            return this.XElement.ToString();
        }
    }
}
