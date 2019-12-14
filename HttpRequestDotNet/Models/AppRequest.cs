using System.Xml.Serialization;

namespace HttpRequestDotNet.Models
{
    public class AppRequest
    {
        public string RequestString { get; set; }

        public string NextString { get; set; }

        public string ToXmlString()
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            }
        }
    }
}