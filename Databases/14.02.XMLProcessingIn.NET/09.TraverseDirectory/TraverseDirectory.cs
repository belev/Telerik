namespace _09.TraverseDirectory
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;

    public class TraverseDirectory
    {
        static void Main()
        {
            using (var xmlWriter = XmlWriter.Create("../../directory.xml"))
            {
                string startFolderLocation = "../../";
                var directory = new DirectoryInfo(startFolderLocation);


                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("directories");

                WriteFilesAndDirectoriesToXml(directory, xmlWriter);

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        public static void WriteFilesAndDirectoriesToXml(DirectoryInfo dir, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("dir");

            xmlWriter.WriteAttributeString("name", dir.Name);

            foreach (var file in dir.GetFiles())
            {
                xmlWriter.WriteStartElement("file");

                xmlWriter.WriteAttributeString("name", file.Name);

                xmlWriter.WriteEndElement();

            }

            foreach (var subDir in dir.GetDirectories())
            {
                WriteFilesAndDirectoriesToXml(subDir, xmlWriter);
            }

            xmlWriter.WriteEndElement();
        }
    }
}