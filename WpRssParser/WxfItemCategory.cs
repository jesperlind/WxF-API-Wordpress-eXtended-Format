using System.Xml.Linq;
using Wxf;

namespace WxfLib
{
    /// <summary>
    /// Represents a WxfItemCategory.
    /// </summary>
    public class WxfItemCategory : IRssNode
    {
        private readonly XElement _element;

        internal WxfItemCategory(XElement element)
        {
            _element = element;

            if (Value == null)
            {
                throw new WxfParseException();
            }
        }

        public WxfItemCategory(string name)
        {
            _element = new XElement("category");

            GenerateChildElements();

            this.Value = name;
        }

        public WxfItemCategory(string name, string niceName)
        {
            _element = new XElement("category");

            GenerateChildElements();

            this.Value = name;
            this.NiceName = niceName;
        }

        private void GenerateChildElements()
        {
            this.XElement.Add(new XAttribute("nicename",string.Empty));
            this.XElement.Add(new XAttribute("domain", string.Empty));
        }

        public static WxfItemCategory Parse(XElement element)
        {
            return new WxfItemCategory(element);
        }

        public string Value
        {
            get { return this.XElement.Value; }
            set { this.XElement.ReplaceNodes(new XCData(value)); }
        }

        public string NiceName
        {
            get { return this.XElement.Attribute("nicename").Value; }
            set { this.XElement.Attribute("nicename").Value = value; }
        }

        public string Domain
        {
            get { return this.XElement.Attribute("domain").Value; }
            set { this.XElement.Attribute("domain").Value = value; }
        }

        public void Detach()
        {
            DetachFromParent();
        }

        internal void DetachFromParent()
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
