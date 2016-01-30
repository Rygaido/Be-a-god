using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

public class chooserofeventts : MonoBehaviour {
  
	public const string path = "Events";

	void Start()
	{
		EventContainer ec = EventContainer.Load (path);

		Events e = ec.events [1];
		Debug.Log (e.happening2);
		//foreach (Events e in ec.events) 
		//{
			//print(e.badeventsvariation);
		//}
	}


}
