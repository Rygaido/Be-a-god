using UnityEngine;
using System.Collections;

public class MainEngine : MonoBehaviour
{
	public static MainEngine singleton;

    float yearTimer;
    int rando;
    int eventCounter;
    public static int numberofFollowers;
    public static int powerLeft;
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
        yearTimer = 120.0f;
        numberofFollowers = 100;
        powerLeft = 0;
		timeForSacrifice();
        
        eventCounter = 4;
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
		powerLeft += numberSaced * 2;
		//MainEngine.singleton.badEvent (1);
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
		 rando = Random.Range (1, 21);

        UIMain.NewEvent(chooserofeventts.ec.events[rando].badeventsvariation, new string[] { "pass", "option1", "option2", "option3", "option4" }, new int[] { 0, 5, 10, 15, 20 }, eventSeverity + 1); 

        //UIMain.NewEvent("Repace discription",new string[]{"option1","option2"},new int[]{0,12},eventSeverity);




    }

	public void BadEventEnd(int optionSelected,int eventSeverity){
		timerRunning = true;
		playerChoice = optionSelected;
	//	UIMain.NewOutcome(chooserofeventts.ec.events[1].response4);
		if(playerChoice==1)
		{
			if(eventSeverity==0)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-5);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=8)
				{
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response1);

					followersChange(1);
				}

				else 
				{

					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);

					followersChange(-3);
				}
			}
			
			else if(eventSeverity==1)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-5);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <= 6)
				{
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response1);

					followersChange(1);
				}
				
				else 
				{
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);

					followersChange(-7);
				}
			}
			
			else if(eventSeverity==2)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-5);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=2)
				{

					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response1);

					followersChange(1);
				}
				
				else 
				{

					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);

					followersChange(-5);
				}

			}
		}
		
		else if (playerChoice == 2)
		{
			if (eventSeverity == 0)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-10);
				int randomResponse = Random.Range(1,11);
				if(randomResponse<=6)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response3);

					followersChange(2);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);

					followersChange(-4);
				}
			}
			
			else if (eventSeverity == 1)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-10);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=5)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response3);

					followersChange(2);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);

					followersChange(-5);
				}
			}
			
			else if (eventSeverity == 2)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-10);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=4)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response3);
					followersChange(2);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);
					followersChange(-8);
				}
			}
		}
		
		else if (playerChoice == 3)
		{
			if (eventSeverity == 0)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-15);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=4)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response5);
					followersChange(4);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
					followersChange(-6);
				}
			}
			
			else if (eventSeverity == 1)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-15);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=5)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response5);
					followersChange(3);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
					followersChange(-4);
				}
			}
			
			else if (eventSeverity == 2)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-15);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=6)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response5);
					followersChange(3);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
					followersChange(-4);
				}
			}
		}
		
		else if (playerChoice == 4)
		{
			if (eventSeverity == 0)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-20);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=2)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response7);
					followersChange(7);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
					followersChange(-10);
				}
			}
			
			else if (eventSeverity == 1)
			{
				//numberOfFollowersUpdate(-7);
				powerUpdate(-20);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=4)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response7);
					followersChange(6);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
					followersChange(-7);
				}
			}
			
			else if (eventSeverity == 2)
			{
				numberOfFollowersUpdate(-7);
				powerUpdate(-20);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=8)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response7);
					followersChange(4);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
					followersChange(-3);
				}
			}
		}
		
		else if (playerChoice == 0)
		{
			if (eventSeverity == 0)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-5);
				powerUpdate(0);
			}
			
			else if (eventSeverity == 1)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-10);
				powerUpdate(0);
			}
			
			else if (eventSeverity == 2)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-20);
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
		//timerRunning = false;
        Debug.Log("Good Event Occurred with severity of " + eventSeverity);
		UIMain.NewEvent ("Good event", new string[]{"option1","o2"}, new int[]{0,12}, (1 +eventSeverity) * -1);
		UIMain.NewOutcome ("Good EventResolution");
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
        int eventType = Random.Range(0, 11);

        if (eventType > 3)
        {
            int eventSeverity = Random.Range(0, 2);
            badEvent(eventSeverity);
        }

        else if (eventType == 3)
        {
            neutralEvent();
        }

        else if (eventType >= 0 & eventType < 3)
        {
            int eventSeverity = Random.Range(0, 3);
            goodEvent(eventSeverity);
        }

    }


    //After an year ends i.e. timer expires, timer is reset to 360 seconds
    void reInitialization()
    {
        
        timeForSacrifice();
		eventCounter = 4;
		yearTimer = 120.0f;
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
        if (yearTimer >= 110.0f && yearTimer < 120.0f)
        {
            int eventProbability = Random.Range(1, 3);
            if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredJan==false)
            {
				Debug.Log(eventProbability);
                eventOccurred();
                eventHasOccurredJan = true;
                eventCounter--;
                followersIncreaseRandomly();
              //  yearTimer = 330;
            }

			else if(eventProbability==1)
			{
				eventHasOccurredJan = true;
			}
        }

        //Resolution for month of February
        else if (yearTimer >= 100.0f && yearTimer < 110.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredFeb == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredFeb = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredFeb = true;
			}
        }

        //Resolution for month of March
        else if (yearTimer >= 90.0f && yearTimer < 100.0f )
        {
            int eventProbability = Random.Range(1, 3);
			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredMar == false)
            {
				//Debug.Log(eventProbability);
                eventOccurred();
                eventCounter--;
                eventHasOccurredMar = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{

				eventHasOccurredMar = true;
			}
        }


        //Resolution for month of April
        else if (yearTimer >= 80.0f && yearTimer < 90.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredApr ==false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredApr = true;
                followersIncreaseRandomly();
            }
			else if(eventProbability==1)
			{
				eventHasOccurredApr = true;
			}
        }

        //Resolution for month of May
        else if (yearTimer >= 70.0f && yearTimer < 80.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredMay == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredMay = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredMay = true;
			}
        }

        //Resolution for month of June
        else if (yearTimer >= 60.0f && yearTimer < 70.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredJun == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredJun = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredJun = true;
			}
        }

        //Resolution for month of July
        else if (yearTimer >= 50.0f && yearTimer < 60.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredJul == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredJul = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredJul = true;
			}
        }

        //Resolution for month of August
        else if (yearTimer >= 40.0f && yearTimer < 50.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredAug == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredAug = true;
                followersIncreaseRandomly();
            }
			else if(eventProbability==1)
			{
				eventHasOccurredAug = true;
			}
        }

        //Resolution for month of September
        else if (yearTimer >= 30.0f && yearTimer < 40.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredSep == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredSep = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredSep = true;
			}
        }

        //Resolution for month of October
        else if (yearTimer >= 20.0f && yearTimer < 30.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredOct == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredOct = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredOct = true;
			}
        }


        //Resolution for month of November
        else if (yearTimer >= 10.0f && yearTimer < 20.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredNov == false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredNov = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredNov = true;
			}
        }

        //Resolution for month of December
        else if (yearTimer >= 0.0f && yearTimer < 10.0f )
        {
            int eventProbability = Random.Range(1, 3);

			if (eventProbability == 2 && eventCounter > 0 && eventHasOccurredDec ==false)
            {
                eventOccurred();
                eventCounter--;
                eventHasOccurredDec = true;
                followersIncreaseRandomly();
            }

			else if(eventProbability==1)
			{
				eventHasOccurredDec = true;
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


	float randomPercentage(int average){
		return Random.Range (average - 1, average + 1) * 0.01f;
	}
	void followersChange(int averagePercentage){
		int followersIncrease=(int)(randomPercentage(averagePercentage)*numberofFollowers);
		numberOfFollowersUpdate(followersIncrease);
	}
}
