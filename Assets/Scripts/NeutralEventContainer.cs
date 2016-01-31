using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
[XmlRoot("NeutraleventsCollection")]
public class NeutralEventContainer {

	[XmlArray("Neutralevents")]
	[XmlArrayItem("Events")]
	public List<NeutralEvents> events = new List<NeutralEvents>();
	
	public static NeutralEventContainer Load(string path)
	{
		
		TextAsset _xml = Resources.Load<TextAsset> (path);
		
		XmlSerializer serializer = new XmlSerializer (typeof(NeutralEventContainer));
		
		StringReader reader = new StringReader (_xml.text);
		
		NeutralEventContainer events = serializer.Deserialize (reader) as NeutralEventContainer;
		
		reader.Close ();
		
		return events;
	}
}
