using UnityEngine;
using System.Collections;

public class Sacrifice_code : MonoBehaviour {
    int humanpopulation;
    int poweramount;
    int years;
    int sacrificeamount;
    int input;
    bool correctamount=false;
    //properties
    public int Input
    {
        get { return input; }
        set { input = value; }
    }

    public int Years
    {
        get { return years; }
        set { years = value; }
    }

    public int Humanpopulation
    {
        get { return humanpopulation; }
        set { humanpopulation = value; }
    }
    public int Poweramount
    {
        get { return poweramount; }
        set { poweramount = value; }
    }
	// Use this for initialization
	void Start () {
        //check to see if response can be used
        correctamount = false;
        while (correctamount == false)
        {
            if (input>0&&input<=humanpopulation)
            {
                sacrificeamount = input;
                correctamount = true;
            }
        }
        //scaling power for people
        if(years<10)
        {
            if (poweramount + (sacrificeamount * 10) > 100)
            {
                poweramount = 100;
            }
            else
            {
                poweramount += (sacrificeamount * 10);
            }
            humanpopulation = humanpopulation - sacrificeamount;
        }
        if(years<20)
        {
            if (poweramount + (sacrificeamount * 20) > 100)
            {
                poweramount = 100;
            }
            else
            {
                poweramount += (sacrificeamount * 20);
            }
            humanpopulation = humanpopulation - sacrificeamount;
        }
        if(years<30)
        {
            if (poweramount + (sacrificeamount * 30) > 100)
            {
                poweramount = 100;
            }
            else
            {
                poweramount += (sacrificeamount * 30);
            }
            humanpopulation = humanpopulation - sacrificeamount;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
