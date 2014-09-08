namespace _14.XslTransform
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    public class XslTransform
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../albums.xslt");
            xslt.Transform("../../../albums.xml", "../../albums.html");
        }
    }
}