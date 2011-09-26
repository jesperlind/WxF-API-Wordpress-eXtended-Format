using System;
using System.Xml.Linq;
using Wxf;

namespace WxfLib
{
    /// <summary>
    /// Represents a WxfImage.
    /// </summary>
    public class WxfImage : IRssNode
    {
        private readonly XElement _element;

        internal WxfImage(XElement element)
        {
            _element = element;

            if (Title == null)
            {
                throw new WxfParseException();
            }
        }

        public Uri Url
        {
            get { return new Uri(this.XElement.Element("url").Value); }
            set { this.XElement.Element("url").Value = value.ToString(); }
        }

        public string Title
        {
            get { return this.XElement.Element("title").Value; }
            set { this.XElement.Element("title").Value = value; }
        }

        public Uri Link
        {
            get { return new Uri(this.XElement.Element("link").Value); }
            set { this.XElement.Element("link").Value = value.ToString(); }
        }

        private readonly System.Net.WebClient _client = new System.Net.WebClient();

        public System.Drawing.Image Image
        {
            get 
            {
                const string path = @"wxf_image.dat";
                _client.DownloadFile(this.Url, path);

                return System.Drawing.Image.FromFile(path); 
            }
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
