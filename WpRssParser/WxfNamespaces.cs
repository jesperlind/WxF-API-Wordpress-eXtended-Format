using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Wxf
{
    /// <summary>
    /// Contains objects representing the Wxf namespaces.
    /// </summary>
    public static class WxfNamespaces
    {
        /// <summary>
        /// wfw = http://wellformedweb.org/CommentAPI/
        /// </summary>
        public static XNamespace wfw
        {
            get
            {
                XNamespace wfw = "http://wellformedweb.org/CommentAPI/";
                return wfw;
            }
        }

        /// <summary>
        /// dc = http://purl.org/dc/elements/1.1/
        /// </summary>
        public static XNamespace dc
        {
            get
            {
                XNamespace dc = "http://purl.org/dc/elements/1.1/";
                return dc;
            }
        }

        /// <summary>
        /// content = http://purl.org/rss/1.0/modules/content/
        /// </summary>
        public static XNamespace content
        {
            get
            {
                XNamespace content = "http://purl.org/rss/1.0/modules/content/";
                return content;
            }
        }

        /// <summary>
        /// wp = http://wordpress.org/export/1.0/
        /// </summary>
        public static XNamespace wp
        {
            get
            {
                XNamespace wp = "http://wordpress.org/export/1.0/";
                return wp;
            }
        }

        /// <summary>
        /// excerpt = http://purl.org/rss/1.0/modules/excerpt/
        /// </summary>
        public static XNamespace excerpt
        {
            get
            {
                XNamespace excerpt = "http://purl.org/rss/1.0/modules/excerpt/";
                return excerpt;
            }
        }
    }
}
