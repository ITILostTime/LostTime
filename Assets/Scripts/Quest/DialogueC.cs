using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("DialogueCollection")]
public class DialogueC
{
    [XmlArray("dialogueArray")]
    [XmlArrayItem("dialogue")]
    public string[] dialogueArray;
}