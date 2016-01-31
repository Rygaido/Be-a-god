using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class GoodEvents  {

	[XmlAttribute("goodeventsvariation")]
	public string goodeventsvariation;
	
	[XmlElement("Response1")]
	public string response1;
	
	[XmlElement("Response2")]
	public string response2;
	
	[XmlElement("Response3")]
	public string response3;
	

}
