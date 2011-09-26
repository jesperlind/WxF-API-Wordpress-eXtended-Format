using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WxfLib
{
    /// <summary>
    /// A collection of RssChannels.
    /// </summary>
    public class RssChannelCollection : RssNodeCollection<RssChannel>
    {
        public RssChannelCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "rss")
                throw new Exception("Argument is not a valid XElement. Expected 'rss'.");
        }

        public RssChannelCollection(XDocument parentXDocument)
            : base(parentXDocument.Element("rss"))
        {

        }

        public override void Add(RssChannel item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(RssChannel item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Channel '{0}' was not found in collection.", item.Title));
        }

        public override IEnumerator<RssChannel> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements("channel"))
            {
                yield return new RssChannel(item);
            }
        }
    }
}
