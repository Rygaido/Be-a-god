using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
[XmlRoot("GoodeventsCollection")]
public class GoodEventContainer {
	
	[XmlArray("Goodevents")]
	[XmlArrayItem("Events")]
	public List<GoodEvents> events = new List<GoodEvents>();
	
	public static GoodEventContainer Load(string path)
	{
		
		TextAsset _xml = Resources.Load<TextAsset> (path);
		
		XmlSerializer serializer = new XmlSerializer (typeof(GoodEventContainer));
		
		StringReader reader = new StringReader (_xml.text);
		
		GoodEventContainer events = serializer.Deserialize (reader) as GoodEventContainer;
		
		reader.Close ();
		
		return events;
	}
}