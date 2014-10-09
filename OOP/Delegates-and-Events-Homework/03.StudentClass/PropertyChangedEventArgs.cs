using System;

namespace _03.StudentClass
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string OldName { get; set; }
        public int OldAge { get; set; }
        public string ChangedProperty { get; set; }
    }
}