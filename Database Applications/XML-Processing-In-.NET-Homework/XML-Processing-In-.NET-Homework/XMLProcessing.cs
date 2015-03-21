namespace XML_Processing_In_.NET_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class XMLProcessing
    {
        static void Main()
        {
            ExtractAlbumNames();
            ExtractArtistsAlphabetically();
            ExtractArtistsAndNuberOfAlbums();
            ExtractArtistsAndNumberOfAlbumsWithXPath();
            DeleteAlbums();
            OldAlbums();
            OldAlbumsWithLinq();
        }

        public static void ExtractAlbumNames()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            XmlNode root = doc.DocumentElement;

            foreach (XmlNode album in root)
            {
                Console.WriteLine(album["name"].InnerText);
            }
        }

        public static void ExtractArtistsAlphabetically()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            XmlNode root = doc.DocumentElement;

            SortedSet<string> artists = new SortedSet<string>();
            foreach (XmlNode album in root)
            {
                string artist = album["artist"].InnerText;
                artists.Add(artist);
            }

            foreach (string artist in artists)
            {
                Console.WriteLine(artist);
            }
        }

        public static void ExtractArtistsAndNuberOfAlbums()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            XmlNode root = doc.DocumentElement;

            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();
            foreach (XmlNode album in root)
            {
                var artist = album["artist"].InnerText;
                if (artistAlbums.ContainsKey(artist))
                {
                    artistAlbums[artist]++;
                }
                else
                {
                    artistAlbums[artist] = 1;
                }
            }

            foreach (var artistAlbum in artistAlbums)
            {
                Console.WriteLine("{0}: {1}", artistAlbum.Key, artistAlbum.Value);
            }
        }

        public static void ExtractArtistsAndNumberOfAlbumsWithXPath()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            var albums = doc.SelectNodes("/catalog/album");

            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();
            foreach (XmlNode album in albums)
            {
                var artist = album["artist"].InnerText;
                if (artistAlbums.ContainsKey(artist))
                {
                    artistAlbums[artist]++;
                }
                else
                {
                    artistAlbums[artist] = 1;
                }
            }

            foreach (var artistAlbum in artistAlbums)
            {
                Console.WriteLine("{0}: {1}", artistAlbum.Key, artistAlbum.Value);
            }
        }

        public static void DeleteAlbums()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            var root = doc.DocumentElement;

            foreach (XmlNode album in root)
            {
                decimal price = decimal.Parse(album["price"].InnerText);
                if (price > 20)
                {
                    root.RemoveChild(album);
                }
            }

            doc.Save("../../cheap-albums-catalog.xml");
        }

        public static void OldAlbums()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            var albums = doc.SelectNodes("catalog/album");
            foreach (XmlNode album in albums)
            {
                int publishYear = int.Parse(album["year"].InnerText);
                var currentYear = DateTime.Now.Year;
                if (currentYear - publishYear >= 5)
                {
                    var title = album["name"].InnerText;
                    var price = album["price"].InnerText;
                    Console.WriteLine("{0}: {1}", title, price);
                }
            }
        }

        public static void OldAlbumsWithLinq()
        {
            XDocument doc = XDocument.Load("../../catalog.xml");

            var oldAlbums =
                (from album in doc.Descendants("album")
                 where int.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
                 select new
                 {
                     Name = album.Element("name").Value,
                     Price = album.Element("price").Value
                 }
            ).ToList();

            foreach (var oldAlbum in oldAlbums)
            {
                Console.WriteLine("{0}: {1}", oldAlbum.Name, oldAlbum.Price);
            }
        }
    }
}
