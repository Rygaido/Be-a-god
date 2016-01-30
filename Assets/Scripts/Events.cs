using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Events {

	[XmlAttribute("badeventsvariation")]
	public string badeventsvariation;

	[XmlElement("Happening1")]
	public string happening1;

	[XmlElement("Happening2")]
	public string happening2;

	[XmlElement("Response")]
	public string response;

}
