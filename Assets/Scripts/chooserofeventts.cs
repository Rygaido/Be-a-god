using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

public class chooserofeventts : MonoBehaviour {

	public static EventContainer ec;
	public static GoodEventContainer Gec;
	public static NeutralEventContainer Nec;

	public const string path1 = "Events";
	public const string path2 = "GoodEvents";
	public const string path3 = "NeutralEvents";
	void Start()
	{
		 ec = EventContainer.Load (path1);
		Gec = GoodEventContainer.Load (path2);
		Nec = NeutralEventContainer.Load (path3);
		//EventContainer Goodec = EventContainer.Load("GoodEvents");
		//EventContainer Neutralec = EventContainer.Load("NeutralEvents")


		//foreach (Events e in ec.events) 
		//{
			//print(e.badeventsvariation);
		//}
	}



}
