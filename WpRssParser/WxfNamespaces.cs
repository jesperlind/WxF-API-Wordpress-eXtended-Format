using System.Xml.Linq;

namespace WxfLib
{
    /// <summary>
    /// Contains objects representing the Wxf namespaces.
    /// </summary>
    public static class WxfNamespaces
    {
        /// <summary>
        /// wfw = http://wellformedweb.org/CommentAPI/
        /// </summary>
        public static XNamespace Wfw
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
        public static XNamespace Dc
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
        public static XNamespace Content
        {
            get
            {
                XNamespace content = "http://purl.org/rss/1.0/modules/content/";
                return content;
            }
        }

        /// <summary>
        /// wp = http://wordpress.org/export/1.1/
        /// </summary>
        public static XNamespace Wp
        {
            get
            {
                XNamespace wp = "http://wordpress.org/export/1.1/";
                return wp;
            }
        }

        ///// <summary>
        ///// wp
        ///// </summary>
        //public static string WpPrefix
        //{
        //    get
        //    {
        //        return "wp";
        //    }
        //}

        /// <summary>
        /// excerpt = http://wordpress.org/export/1.1/excerpt/
        /// </summary>
        public static XNamespace Excerpt
        {
            get
            {
                XNamespace excerpt = "http://wordpress.org/export/1.1/excerpt/";
                return excerpt;
            }
        }
    }
}
