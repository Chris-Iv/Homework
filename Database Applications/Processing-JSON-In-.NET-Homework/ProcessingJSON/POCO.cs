namespace ProcessingJSON
{
    using System;
    using Newtonsoft.Json;

    public class POCO
    {
        public string Link { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("<a href=\"{0}\">Question's page</a><br/><h1>{1}</h1><br/><p>{2}</p><br/><em>{3}</em>",
                this.Link,
                this.Title,
                this.Description,
                this.Date);
        }
    }
}
