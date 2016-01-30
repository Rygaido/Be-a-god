using UnityEngine;
using System.Collections;

public class MainEngine : MonoBehaviour
{
	public static MainEngine singleton;

    float yearTimer;
    int eventCounter;
    static int numberofFollowers;
    static int powerLeft;
    int followersIncreaseTimes;
    int playerChoice;
	static bool timerRunning;

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

	public GameObject civilianManager;
	civilian_manager followers; //use followers' methods to add and subtract person objects and change emotion

    // Use this for initialization
    void Start()
    {
		singleton = this;
        followersIncreaseTimes = 6;
        yearTimer = 360.0f;
        numberofFollowers = 100;
        powerLeft = 0;
		timeForSacrifice();
        
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

		followers = civilianManager.GetComponent<civilian_manager> ();
    }

	public static void NewSacrificeMade(int numberSaced){
		timerRunning = true;
		numberofFollowers -= numberSaced;
		powerLeft += numberSaced * 10;
		MainEngine.singleton.badEvent (1);
	}

    void timeForSacrifice()
    {
		timerRunning = false;
		UIMain.NewSac (numberofFollowers);
    }

    //Details on what happens in a bad event
    //@param is the severity of event, 0: mild 1: so-so 2:severe
    void badEvent(int eventSeverity)
    {
		followers.Panic ();
        Debug.Log("Bad Event Occurred with severity of " + eventSeverity);
		timerRunning = false;
		UIMain.NewEvent("Repace discription",new string[]{"option1","option2"},new int[]{0,12},eventSeverity);



        
    }

	public void BadEventEnd(int optionSelected,int eventSeverity){
		timerRunning = true;
		playerChoice = optionSelected;
		if(playerChoice==1)
		{
			if(eventSeverity==0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-5);
			}
			
			else if(eventSeverity==1)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-5);
			}
			
			else if(eventSeverity==2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-5);
			}
		}
		
		else if (playerChoice == 2)
		{
			if (eventSeverity == 0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-10);
			}
			
			else if (eventSeverity == 1)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-10);
			}
			
			else if (eventSeverity == 2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-10);
			}
		}
		
		else if (playerChoice == 3)
		{
			if (eventSeverity == 0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-15);
			}
			
			else if (eventSeverity == 1)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-15);
			}
			
			else if (eventSeverity == 2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-15);
			}
		}
		
		else if (playerChoice == 4)
		{
			if (eventSeverity == 0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-20);
			}
			
			else if (eventSeverity == 1)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-20);
			}
			
			else if (eventSeverity == 2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-20);
			}
		}
		
		else if (playerChoice == 5)
		{
			if (eventSeverity == 0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(0);
			}
			
			else if (eventSeverity == 1)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(0);
			}
			
			else if (eventSeverity == 2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(0);
			}
		}
	}

    //Detalis on what happens in a neutral event
    void neutralEvent()
    {
		followers.Calm ();
        Debug.Log("Neutral Event Occurred");
		UIMain.NewEvent ("NeutralEvent",new string[0],new int[0],0);
    }

    //Details on what happens in a good event
    void goodEvent(int eventSeverity)
    {
		followers.Celebrate ();
        Debug.Log("Good Event Occurred with severity of " + eventSeverity);
		UIMain.NewEvent ("Good event", new string[]{"option1","o2"}, new int[]{0,12}, eventSeverity * -1);
    }

	public void GoodEventEnd(int optionSelected,int sevarity){
		if(sevarity==0)
			numberOfFollowersUpdate(5);
		
		else if(sevarity==1)
			numberOfFollowersUpdate(10);
		
		else if (sevarity == 2)
			numberOfFollowersUpdate(15);
	}

    void numberOfFollowersUpdate(int k)
    {
        numberofFollowers += k;
    }

    void powerUpdate(int k)
    {
        powerLeft += k;
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
        
        timeForSacrifice();
        eventCounter = Random.Range(0, 4);
        followersIncreaseTimes = 6;
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
		if (timerRunning == true)
		{
			yearTimer -= Time.deltaTime;
		}
        //Resolution for month of January 
        if (yearTimer >= 330.0f && yearTimer < 360.0f)
        {
            int eventProbability = Random.Range(1, 4);
            if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredJan==false)
            {
                eventOccurred();
                eventHasOccurredJan = true;
                eventCounter--;
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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
                followersIncreaseRandomly();
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

    void followersIncreaseRandomly()
    {
        if(followersIncreaseTimes>0)
        {
            int randomlyIncreaseFollowers = Random.Range(0, 3);
            if (randomlyIncreaseFollowers == 2)
            {
                numberofFollowers += Random.Range(0, 3);
                followersIncreaseTimes--;
            }

        }
    }
}
