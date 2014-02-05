using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AtributeVersion
{
    [VersionAttribute(5, 15)]
    [VersionAttribute(6, 13)]
    class AtributeVersionTest
    {
        static void Main(string[] args)
        {
            //set AllowMultiple to true
            //so that it is posible to use more than 1 attribute of VersionAttribute
            VersionAttribute[] versionAttribute = (VersionAttribute[]) Attribute.GetCustomAttributes(typeof(AtributeVersionTest), typeof(VersionAttribute));

            foreach (VersionAttribute version in versionAttribute)
            {
                if (version == null)
                {
                    Console.WriteLine("The attribute was not found.");
                }
                else
                {
                    Console.WriteLine(version.Version);
                }
            }
        }
    }
}
