using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
[XmlRoot("BadeventsCollection")]
public class EventContainer {

	[XmlArray("Badevents")]
	[XmlArrayItem("Events")]
	public List<Events> events = new List<Events>();

	public static EventContainer Load(string path)
	{

		TextAsset _xml = Resources.Load<TextAsset> (path);

		XmlSerializer serializer = new XmlSerializer (typeof(EventContainer));

		StringReader reader = new StringReader (_xml.text);

		EventContainer events = serializer.Deserialize (reader) as EventContainer;

		reader.Close ();

		return events;
	}
}
