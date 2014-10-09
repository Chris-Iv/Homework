using System;

namespace _01.School
{
    class Class
    {
        public string TextIdentifier { get; set; }
        public Teacher[] Teachers { get; set; }
        public string Details { get; set; }

        public Class(string textIdentifier, Teacher[] teachers, string details = "")
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = teachers;
            this.Details = details;
        }
    }
}
