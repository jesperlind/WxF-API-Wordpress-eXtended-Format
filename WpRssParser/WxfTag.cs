using System.Xml.Linq;

namespace WxfLib
{
    public class WxfTag : IRssNode
    {
        private readonly XElement _element;

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
            _element = new XElement(WxfNamespaces.Wp + "tag");

            this.Name = name;
        }

        public static WxfTag Parse(XElement element)
        {
            return new WxfTag(element);
        }

        public string Name
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "tag_name").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "tag_name").Value = value; }
        }

        public string Slug
        {
            get { return this.XElement.Element(WxfNamespaces.Wp + "tag_slug").Value; }
            set { this.XElement.Element(WxfNamespaces.Wp + "tag_slug").Value = value; }
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
