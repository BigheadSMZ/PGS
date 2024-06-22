using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

// Credits to Ivan Yakimov at codeproject. This is phenomenal code.
// https://www.codeproject.com/Articles/639486/Save-and-Restore-Icon-Positions-on-Desktop

namespace IconsRestorer.Code
{
    internal class Storage
    {
        public void SaveIconPositions(IEnumerable<NamedDesktopPoint> iconPositions, IDictionary<string, string> registryValues)
        {
            var xDoc = new XDocument(
                new XElement("Desktop",
                    new XElement("Icons",
                        iconPositions.Select(p => new XElement("Icon",
                            new XAttribute("x", p.X),
                            new XAttribute("y", p.Y),
                            new XText(p.Name)))),
                    new XElement("Registry",
                        registryValues.Select(p => new XElement("Value",
                            new XElement("Name", new XCData(p.Key)),
                            new XElement("Data", new XCData(p.Value)))))));

            using (var storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists("Desktop"))
                { storage.DeleteFile("Desktop"); }

                using (var stream = storage.CreateFile("Desktop"))
                {
                    using (var writer = XmlWriter.Create(stream))
                    {
                        xDoc.WriteTo(writer);
                    }
                }
            }
        }

        public IEnumerable<NamedDesktopPoint> GetIconPositions()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists("Desktop") == false)
                { return new NamedDesktopPoint[0]; }

                using (var stream = storage.OpenFile("Desktop", FileMode.Open))
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        var xDoc = XDocument.Load(reader);

                        return xDoc.Root.Element("Icons").Elements("Icon")
                            .Select(el => new NamedDesktopPoint(el.Value, int.Parse(el.Attribute("x").Value), int.Parse(el.Attribute("y").Value)))
                            .ToArray();
                    }
                }
            }
        }

        public IDictionary<string, string> GetRegistryValues()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists("Desktop") == false)
                { return new Dictionary<string, string>(); }

                using (var stream = storage.OpenFile("Desktop", FileMode.Open))
                {
                    using (var reader = XmlReader.Create(stream))
                    {
                        var xDoc = XDocument.Load(reader);

                        return xDoc.Root.Element("Registry").Elements("Value")
                            .ToDictionary(el => el.Element("Name").Value, el => el.Element("Data").Value);
                    }
                }
            }
        }
    }
}
