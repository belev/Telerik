using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AtributeVersion
{
    //11.Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        private int majorVersion;
        private int minorVersion;

        public VersionAttribute(int major, int minor)
        {
            this.majorVersion = major;
            this.minorVersion = minor;
        }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.majorVersion, this.minorVersion);
            }
        }
    }
}
