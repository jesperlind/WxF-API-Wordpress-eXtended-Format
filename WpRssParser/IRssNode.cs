using System.Xml.Linq;

namespace WxfLib
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRssNode
    {
        /// <summary>
        /// 
        /// </summary>
        XElement XElement { get; }

        /// <summary>
        /// 
        /// </summary>
        void Detach();

        //XElement GenerateXElement();
    }
}
