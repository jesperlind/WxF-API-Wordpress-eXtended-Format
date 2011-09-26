using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wxf
{
    public interface IRssNode
    {
        XElement XElement { get; }

        void Detach();

        //XElement GenerateXElement();
    }
}
