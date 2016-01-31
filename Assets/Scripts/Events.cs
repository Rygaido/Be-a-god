using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Events  {

	[XmlAttribute("badeventsvariation")]
	public string badeventsvariation;

	[XmlElement("Response1")]
	public string response1;

	[XmlElement("Response2")]
	public string response2;

	[XmlElement("Response3")]
	public string response3;

	[XmlElement("Response4")]
	public string response4;
	
	[XmlElement("Response5")]
	public string response5;
	
	[XmlElement("Response6")]
	public string response6;

	[XmlElement("Response7")]
	public string response7;
	
	[XmlElement("Response8")]
	public string response8;
	


}
