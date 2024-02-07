// Pega o caminho dos vídeos
using System.Xml;

string[] dirs = Directory.GetFiles(@"C:\Users\burni\Videos\diferentao");

XmlDocument doc = new XmlDocument();
XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
doc.AppendChild(docNode);

XmlElement uploadMainNode = doc.CreateElement("upload");
(uploadMainNode).SetAttribute("application", "Youtube Mass Uploader");
(uploadMainNode).SetAttribute("secret", "C:\\Users\\burni\\Documents\\workstation\\BurningpixelCwb\\UpYoutube\\secret.json");
doc.AppendChild(uploadMainNode);

foreach (string dir in dirs)
{
    string result;

    result = Path.GetFileName(dir);
    string nomeVideo = result.Substring(0, result.LastIndexOf("."));

    XmlElement videoNode = doc.CreateElement("video");
    (videoNode).SetAttribute("file", dir);
    (videoNode).SetAttribute("privacy", "Public");
    (videoNode).SetAttribute("category", "Sports");
    uploadMainNode.AppendChild(videoNode);

    XmlElement channelNode = doc.CreateElement("channel");
    (channelNode).SetAttribute("id", "UC2-pwvZJqYtVbqZAg4Yq60w");
    videoNode.AppendChild(channelNode);

    XmlNode titleNode = doc.CreateElement("title");
    titleNode.AppendChild(doc.CreateTextNode(nomeVideo));
    videoNode.AppendChild(titleNode);

    XmlNode descriptionNode = doc.CreateElement("description");
    descriptionNode.AppendChild(doc.CreateTextNode("Este vídeo é um upload realizado de forma automatica. Ainda estamos testando qual a maneira mais adequada de fazermos isso mas pelo que parece está indo tudo muito bem!"));
    videoNode.AppendChild(descriptionNode);

    XmlNode tagsNode = doc.CreateElement("tags");
    tagsNode.AppendChild(doc.CreateTextNode("viva padel, padel, jogadas, jogada padel"));
    videoNode.AppendChild(tagsNode);
}

// Fecha o arquivo XML
var basePath = Path.Combine(@"C:\Users\burni\Documents\workstation\BurningpixelCwb\UpYoutube\YMU_v1.0\YMU", @"XMLFiles\");
if (!Directory.Exists(basePath))
{
    Directory.CreateDirectory(basePath);
}

var newFileName = "Upload_Configuration.xml";
doc.Save(basePath + newFileName);