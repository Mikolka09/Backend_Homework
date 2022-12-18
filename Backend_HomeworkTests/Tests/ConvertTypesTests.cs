using Backend_Homework.Classes;

namespace Backend_HomeworkTests.Tests
{
    [TestClass]
    public class ConvertTypesTests
    {
        private Document? docActual { get; set; }
        private string? InputJson { get; set; }
        private string? InputXml { get; set; }
        private string? InputBson { get; set; }
        private string? InputYaml { get; set; }


        [TestInitialize]
        public void TestInitialize()
        {
            docActual = new Document()
            {
                Title = "Lorem Ipsum",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            InputJson = "{\"Title\":\"Lorem Ipsum\",\"Text\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit.\"}";
            InputXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<document>\r\n<title>Lorem Ipsum</title>\r\n<text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</text>\r\n</document>\r\n";
            InputBson = "XwAAAAJUaXRsZQAMAAAATG9yZW0gSXBzdW0AAlRleHQAOQAAAExvcmVtIGlwc3VtIGRvbG9yIHNpdCBhbWV0LCBjb25zZWN0ZXR1ciBhZGlwaXNjaW5nIGVsaXQuAAA=";
            InputYaml = "Text: Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\nTitle: Lorem Ipsum\r\n";
        }

        [TestMethod]
        public void ParsingJsonToDocument_InputJson_To_Document()
        {
            ConvertTypes.ParsingJsonToDocument(InputJson);
            Assert.AreEqual(ConvertTypes.Doc!.Title, docActual!.Title);
            Assert.AreEqual(ConvertTypes.Doc!.Text, docActual!.Text);
        }

        [TestMethod]
        public void ParsingXmlToDocument_InputXml_To_Document()
        {
            ConvertTypes.ParsingXmlToDocument(InputXml);
            Assert.AreEqual(ConvertTypes.Doc!.Title, docActual!.Title);
            Assert.AreEqual(ConvertTypes.Doc!.Text, docActual!.Text);
        }

        [TestMethod]
        public void ParsingBsonToDocument_InputBson_To_Document()
        {
            ConvertTypes.ParsingBsonToDocument(InputBson);
            Assert.AreEqual(ConvertTypes.Doc!.Title, docActual!.Title);
            Assert.AreEqual(ConvertTypes.Doc!.Text, docActual!.Text);
        }

        [TestMethod]
        public void ParsingYamlToDocument_InputYaml_To_Document()
        {
            ConvertTypes.ParsingYamlToDocument(InputYaml);
            Assert.AreEqual(ConvertTypes.Doc!.Title, docActual!.Title);
            Assert.AreEqual(ConvertTypes.Doc!.Text, docActual!.Text);
        }

    }
}