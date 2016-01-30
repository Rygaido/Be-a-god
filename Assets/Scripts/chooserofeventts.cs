using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class chooserofeventts : MonoBehaviour {
  
    System.IO.StreamReader reader;
    int severity;
    int typeofevent;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       

	}
List<string> goodevent(int severity)
    {
        string line;
        List<string> text = new List<string>();
        reader = new System.IO.StreamReader("goodevent.txt");
        //picks an event from the list
        int y = Random.Range(0, 5);
        //cuts through the list to get to the event
        for(int g =0;g< y;g++)
        {
            for(int h=0;h< y;h++)
            {
                while ((line = reader.ReadLine()) != null)
                {
                   
                }
            }
        }
        //picks the lines of text that goes with the severity
        if (severity == 0)
        {
            while((line=reader.ReadLine())!= null)
            {
                text.Add(line);
            }
            return text;
        }
        else if( severity ==1)
        {
            for(int x =0;x<2;x++)
            {
                if (x == 0)
                {
                    while ((line = reader.ReadLine()) != null)
                    {

                    }
                }
                else
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        text.Add(line);
                    }
                }
            }
            return text;
        }
        else
        {
            for(int x=0;x<3;x++)
            {
                if(x<2)
                {
                    while ((line = reader.ReadLine()) != null)
                    {

                    }
                }
                else
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        text.Add(line);
                    }
                }
            }
            return text;
        }

    }

string[] neutralevent()
    {

    }

string[] badevent(int severity)
    {

    }
}
