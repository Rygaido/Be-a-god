using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

public class chooserofeventts : MonoBehaviour {

	public static EventContainer ec;
  
	public const string path = "Events";

	void Start()
	{
		 ec = EventContainer.Load (path);
		//EventContainer Goodec = EventContainer.Load("GoodEvents");
		//EventContainer Neutralec = EventContainer.Load("NeutralEvents")


		//foreach (Events e in ec.events) 
		//{
			//print(e.badeventsvariation);
		//}
	}



}
