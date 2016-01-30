using UnityEngine;
using System.Collections;

public class MainEngine : MonoBehaviour
{

    float yearTimer;
    int eventCounter;

    bool eventHasOccurredJan;
    bool eventHasOccurredFeb;
    bool eventHasOccurredMar;
    bool eventHasOccurredApr;
    bool eventHasOccurredMay;
    bool eventHasOccurredJun;
    bool eventHasOccurredJul;
    bool eventHasOccurredAug;
    bool eventHasOccurredSep;
    bool eventHasOccurredOct;
    bool eventHasOccurredNov;
    bool eventHasOccurredDec;
    // Use this for initialization
    void Start()
    {
        yearTimer = 360.0f;
        eventCounter = Random.Range(0, 4);
        eventHasOccurredJan = false;
        eventHasOccurredFeb = false;
        eventHasOccurredMar = false;
        eventHasOccurredApr = false;
        eventHasOccurredMay = false;
        eventHasOccurredJun = false;
        eventHasOccurredJul = false;
        eventHasOccurredAug = false;
        eventHasOccurredSep = false;
        eventHasOccurredOct = false;
        eventHasOccurredNov = false;
        eventHasOccurredDec = false;
    }


    //Details on what happens in a bad event
    //@param is the severity of event, 0: mild 1: so-so 2:severe
    void badEvent(int eventSeverity)
    {
        Debug.Log("Bad Event Occurred with severity of " + eventSeverity);
    }

    //Detalis on what happens in a neutral event
    void neutralEvent()
    {
        Debug.Log("Neutral Event Occurred");
    }

    //Details on what happens in a good event
    void goodEvent(int eventSeverity)
    {
        Debug.Log("Good Event Occurred with severity of " + eventSeverity);
    }


    //Details when event Occurs
    void eventOccurred()
    {
        //Defines whether event is bad, neutral or good
        int eventType = Random.Range(0, 8);

        if (eventType > 3)
        {
            int eventSeverity = Random.Range(0, 3);
            badEvent(eventSeverity);
        }

        else if (eventType == 3)
        {
            neutralEvent();
        }

        else if (eventType > 0 & eventType < 3)
        {
            int eventSeverity = Random.Range(0, 3);
            goodEvent(eventSeverity);
        }

    }


    //After an year ends i.e. timer expires, timer is reset to 360 seconds
    void reInitialization()
    {
        yearTimer = 360.0f;
        eventCounter = Random.Range(0, 4);
        eventHasOccurredJan = false;
        eventHasOccurredFeb = false;
        eventHasOccurredMar = false;
        eventHasOccurredApr = false;
        eventHasOccurredMay = false;
        eventHasOccurredJun = false;
        eventHasOccurredJul = false;
        eventHasOccurredAug = false;
        eventHasOccurredSep = false;
        eventHasOccurredOct = false;
        eventHasOccurredNov = false;
        eventHasOccurredDec = false;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(yearTimer);
        yearTimer -= Time.deltaTime;

        //Resolution for month of January 
        if (yearTimer >= 330.0f && yearTimer < 360.0f)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredJan==false)
            {
                eventOccurred();
                eventHasOccurredJan = true;
                eventCounter--;
              //  yearTimer = 330;
            }
        }

        //Resolution for month of February
        else if (yearTimer >= 300.0f && yearTimer < 330.0f && eventHasOccurredFeb == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredFeb = true;
             //   yearTimer = 300;
            }
        }

        //Resolution for month of March
        else if (yearTimer >= 270.0f && yearTimer < 300.0f && eventHasOccurredMar == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredMar = true;
               // yearTimer = 270;
            }
        }


        //Resolution for month of April
        else if (yearTimer >= 240.0f && yearTimer < 270.0f && eventHasOccurredApr ==false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredApr = true;
               // yearTimer = 240;
            }
        }

        //Resolution for month of May
        else if (yearTimer >= 210.0f && yearTimer < 240.0f && eventHasOccurredMay == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredMay = true;
              //  yearTimer = 210;
            }
        }

        //Resolution for month of June
        else if (yearTimer >= 180.0f && yearTimer < 210.0f && eventHasOccurredJun == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredJun = true;
               // yearTimer = 180;
            }
        }

        //Resolution for month of July
        else if (yearTimer >= 150.0f && yearTimer < 180.0f && eventHasOccurredJul == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredJul = true;
                //yearTimer = 150;
            }
        }

        //Resolution for month of August
        else if (yearTimer >= 120.0f && yearTimer < 150.0f && eventHasOccurredAug == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredAug = true;
               // yearTimer = 120;
            }
        }

        //Resolution for month of September
        else if (yearTimer >= 90.0f && yearTimer < 120.0f && eventHasOccurredSep == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredSep = true;
                //yearTimer = 90;
            }
        }

        //Resolution for month of October
        else if (yearTimer >= 60.0f && yearTimer < 90.0f && eventHasOccurredOct == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredOct = true;
                //yearTimer = 60;
            }
        }


        //Resolution for month of November
        else if (yearTimer >= 30.0f && yearTimer < 60.0f && eventHasOccurredNov == false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredNov = true;
                //yearTimer = 30;
            }
        }

        //Resolution for month of December
        else if (yearTimer >= 0.0f && yearTimer < 30.0f && eventHasOccurredDec ==false)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredDec = true;
                //earTimer = 0;
            }
        }

        else if (yearTimer < 0.0f)
        {
            reInitialization();
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 90), yearTimer.ToString());
    }
}
