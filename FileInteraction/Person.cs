using System.Xml.Serialization;
namespace FileInteraction
{
    public class Person
    {
        // fields
        [XmlAttribute]
        public string? name;
        public double? height;
        public double? weight;

        private XmlSerializer Serializer = new XmlSerializer(typeof(Person));

        // constructor
        public Person() { }
        public Person(string? name, double? height, double? weight)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
        }

        // methods
        public string SerializeXml()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}