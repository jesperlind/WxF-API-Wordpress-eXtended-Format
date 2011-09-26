using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    /// <summary>
    /// Represents a WxfCategory.
    /// </summary>
    public class WxfCategory : IRssNode
    {
        private XElement _element;

        internal WxfCategory(XElement element)
        {
            

            _element = element;

            if (Name == null)
            {
                throw new WxfParseException();
            }
        }

        public WxfCategory(string name)
        {
            _element = new XElement(WxfNamespaces.wp + "category");

            GenerateChildElements();

            this.Name = name;
        }

        public WxfCategory(string name, WxfCategory parent)
        {
            _element = new XElement(WxfNamespaces.wp + "category");
            
            GenerateChildElements();

            this.Name = name;
            this.SetParent(parent);
        }

        private void GenerateChildElements()
        {
            this.XElement.Add(new XElement(WxfNamespaces.wp + "cat_name"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "category_nicename"));
            this.XElement.Add(new XElement(WxfNamespaces.wp + "category_parent"));
        }

        public static WxfCategory Parse(XElement element)
        {
            return new WxfCategory(element);
        }

        public string Name
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "cat_name").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "cat_name").ReplaceNodes(new XCData(value)); }
        }

        public string NiceName
        {
            get { return this.XElement.Element(WxfNamespaces.wp + "category_nicename").Value; }
            set { this.XElement.Element(WxfNamespaces.wp + "category_nicename").Value = value; }
        }

        public void SetParent(WxfCategory category)
        {
            this.XElement.Element(WxfNamespaces.wp + "category_parent").Value = category.Name;
        }

        public void SetParent(string name)
        {
            this.XElement.Element(WxfNamespaces.wp + "category_parent").Value = name;
        }

        public string GetParent()
        {
            return this.XElement.Element(WxfNamespaces.wp + "category_parent").Value;
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
            set { _element = value; }
        }

        public override string ToString()
        {
            return this.XElement.ToString();
        }
    }
}
