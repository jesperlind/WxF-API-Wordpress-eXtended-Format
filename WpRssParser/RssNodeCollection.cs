using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    /// <summary>
    /// A collection of RssNode objects.
    /// </summary>
    /// <typeparam name="T">A type inheriting from the IRssNode class.</typeparam>
    public abstract class RssNodeCollection<T> : IEnumerable<T> where T : IRssNode
    {
        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="parentXElement"></param>
        public RssNodeCollection(XElement parentXElement)
        {
            ParentXElement = parentXElement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">An item to add to the collection.</param>
        /// 
        public abstract void Add(T item);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">An item contained in the collection that you is going to remove.</param>
        public abstract void Remove(T item);

        /// <summary>
        /// The parent XElement that contains the nodes contained by this collection.
        /// </summary>
        public XElement ParentXElement
        {
            get;
            protected set;
        }

        #region IEnumerable<T> Members

        public abstract IEnumerator<T> GetEnumerator();

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// The count of nodes.
        /// </summary>
        public int Count
        {
            get { return this.ToList().Count; }
        }

        /// <summary>
        /// A indexer for this collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.ElementAt(index); }
        }

        /// <summary>
        /// Cast this collection to a RssNodeCollection(T).
        /// </summary>
        /// <returns>A RssNodeCollection(T)-object containing this collections objects.</returns>
        public RssNodeCollection<T> ToRssNodeCollection()
        {
            return this as RssNodeCollection<T>;
        }
    }

    /// <summary>
    /// A collection of WxfChannels.
    /// </summary>
    public class WxfChannelCollection : RssNodeCollection<WxfChannel>
    {
        public WxfChannelCollection(XElement parentXElement) : base(parentXElement)
        {
            if (parentXElement.Name != "rss")
                throw new Exception("Argument is not a valid XElement. Expected 'rss'.");
        }

        public override void Add(WxfChannel item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfChannel item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Channel '{0}' was not found in collection.", item.Title));
        }

        public override IEnumerator<WxfChannel> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements("channel"))
            {
                yield return new WxfChannel(item);
            }
        }
    }

    /// <summary>
    /// A collection of WxfItems.
    /// </summary>
    public class WxfItemCollection : RssNodeCollection<WxfItem>
    {
        public WxfItemCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "channel")
                throw new Exception("Argument is not a valid XElement. Expected 'channel'.");
        }

        public override void Add(WxfItem item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfItem item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Item '{0}' was not found in collection.", item.Title));
        }

        public override IEnumerator<WxfItem> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements("item"))
            {
                yield return new WxfItem(item);
            }
        }
    }

    /// <summary>
    /// A collection of WxfComments.
    /// </summary>
    public class WxfCommentCollection : RssNodeCollection<WxfComment>
    {
        public WxfCommentCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "item")
                throw new Exception("Argument is not a valid XElement. Expected 'item'.");
        }

        public override void Add(WxfComment item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfComment item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Comment #{0} was not found in collection.", item.ID));
        }

        public override IEnumerator<WxfComment> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements(WxfNamespaces.wp + "comment"))
            {
                yield return new WxfComment(item);
            }
        }
    }

    /// <summary>
    /// A collection of WxfCategories.
    /// </summary>
    public class WxfCategoryCollection : RssNodeCollection<WxfCategory>
    {
        public WxfCategoryCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "channel")
                throw new Exception("Argument is not a valid XElement. Expected 'channel'.");
        }

        public override void Add(WxfCategory item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfCategory item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Category '{0}' was not found in collection.", item.Name));
        }

        public override IEnumerator<WxfCategory> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements(WxfNamespaces.wp + "category"))
            {
                yield return new WxfCategory(item);
            }
        }
    }

    /// <summary>
    /// A collection of WxfItemCategories.
    /// </summary>
    public class WxfItemCategoryCollection : RssNodeCollection<WxfItemCategory>
    {
        public WxfItemCategoryCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "item")
                throw new Exception("Argument is not a valid XElement. Expected 'item'.");
        }

        public override void Add(WxfItemCategory item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfItemCategory item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Category '{0}' was not found in collection.", item.Value));
        }

        public override IEnumerator<WxfItemCategory> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements("category"))
            {
                yield return new WxfItemCategory(item);
            }
        }
    }

    /// <summary>
    /// A collection of WxfTags.
    /// </summary>
    public class WxfTagCollection : RssNodeCollection<WxfTag>
    {
        public WxfTagCollection(XElement parentXElement)
            : base(parentXElement)
        {
            if (parentXElement.Name != "channel")
                throw new Exception("Argument is not a valid XElement. Expected 'channel'.");
        }

        public override void Add(WxfTag item)
        {
            this.ParentXElement.Add(item.XElement);
        }

        public override void Remove(WxfTag item)
        {
            if (ParentXElement.Element(item.XElement.Name) != null)
            {
                item.Detach();
            }
            else
                throw new Exception(string.Format("Tag '{0}' was not found in collection.", item.Name));
        }

        public override IEnumerator<WxfTag> GetEnumerator()
        {
            foreach (var item in ParentXElement.Elements(WxfNamespaces.wp + "tag"))
            {
                yield return new WxfTag(item);
            }
        }
    }
}
