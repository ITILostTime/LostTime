using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("DialogueCollection")]
public class DialogueCollection
{
    [XmlArray("dialogueArray")]
    [XmlArrayItem("dialogue")]
    public string[] dialogueArray;
}