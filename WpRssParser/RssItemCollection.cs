using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// A collection of RssItems.
    /// </summary>
    public class RssItemCollection : RssNodeCollection<RssItem>
    {
        public RssItemCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "channel")
                throw new Exception("Argument is not a valid XElement. Expected 'channel'.");
        }

        public override void Add(RssItem item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(RssItem item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Item '{0}' was not found in collection.", item.Title));
        }

        public override IEnumerator<RssItem> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements("item"))
            {
                yield return new RssItem(item);
            }
        }
    }
}
