using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Xml.Serialization;

namespace Lab_2
{
    public partial class ComponentLoadXml : Component
    {
        public ComponentLoadXml()
        {
            InitializeComponent();
        }

        public ComponentLoadXml(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public T LoadXml<T>(string Path)
        {
            if (!typeof(T).IsSerializable) 
                throw new Exception("Класс не сериализуем");

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    using (Stream stream = archive.Entries.First()?.Open())
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(T));
                        T deserializeClass = (T)formatter.Deserialize(stream);
                        return deserializeClass;
                    }
                }
            }
        }
    }
}
