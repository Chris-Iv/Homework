using System;

namespace _03.GenericList
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
        | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    class Version : System.Attribute
    {
        public int major { get; private set; }
        public int minor { get; private set; }

        public Version(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public override string ToString()
        {
            return this.major + "." + this.minor;
        }
    }
}
