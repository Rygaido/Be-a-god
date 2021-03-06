﻿using UnityEngine;
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
    public AudioClip followersLargeSound;
    public AudioClip followersSmallSound;
    public AudioClip goodEventSound;
    public AudioClip goodDecisionSound;
    public AudioClip badEventSound;
    public AudioClip badDecisionSound;

    AudioSource audio;
    
    public static int totalFollowersLost = 0;
   // public static int highestFollowers = 0;
    public static int yearsLasted = 0;

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
        audio = GetComponent<AudioSource>();

        eventCounter = 12;
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
        numberOfFollowersUpdate(-numberSaced);
        //numberofFollowers -= numberSaced;
		powerLeft += numberSaced * 4;
        UIMain.PowerChanged(true, numberSaced * 4);
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
        audio.PlayOneShot(badEventSound);
		followers.Panic ();
        Debug.Log("Bad Event Occurred with severity of " + eventSeverity);
		timerRunning = false;
		 rando = Random.Range (1, 21);

        UIMain.NewEvent(chooserofeventts.ec.events[rando].badeventsvariation, new string[] { "pass", "option1", "option2", "option3", "option4" }, new int[] { 0, 5, 10, 15, 20 }, eventSeverity + 1,chooserofeventts.ec.events[rando].id); 
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
                    audio.PlayOneShot(goodDecisionSound);

					followersChange(1);
				}

				else 
				{

					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);
                    audio.PlayOneShot(badDecisionSound);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(2);
				}
				
				else 
				{
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-9);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(4);
				}
				
				else 
				{

					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response2);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-14);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(4);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-8);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(4);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-4);
				}
			}
			
			else if (eventSeverity == 2)
			{
				powerUpdate(-10);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=4)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response3);
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(6);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response4);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-12);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(6);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
					followersChange(-3);
                    audio.PlayOneShot(badDecisionSound);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(6);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
                    audio.PlayOneShot(badDecisionSound);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(8);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response6);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-8);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(14);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
                    audio.PlayOneShot(badDecisionSound);
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
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(10);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-7);
				}
			}
			
			else if (eventSeverity == 2)
			{
				
				powerUpdate(-20);
				int randomResponse = Random.Range(1,11);
				if(randomResponse <=8)
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response7);
                    audio.PlayOneShot(goodDecisionSound);
                    followersChange(8);
				}
				
				else 
				{
					
					UIMain.NewOutcome(chooserofeventts.ec.events[rando].response8);
                    audio.PlayOneShot(badDecisionSound);
                    followersChange(-13);
				}
			}
		}
		
		else if (playerChoice == 0)
		{
            Debug.Log("Pass Selected");
			if (eventSeverity == 0)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-5);
                audio.PlayOneShot(badDecisionSound);
                powerUpdate(0);
			}
			
			else if (eventSeverity == 1)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-10);
				powerUpdate(0);
                audio.PlayOneShot(badDecisionSound);
            }
			
			else if (eventSeverity == 2)
			{
				//numberOfFollowersUpdate(-7);
				followersChange(-20);
				powerUpdate(0);
                audio.PlayOneShot(badDecisionSound);
            }
            UIMain.NewOutcome("You sit back and watch as your loyal followers died a gruesome death");
        }
	}

    //Detalis on what happens in a neutral event
    void neutralEvent()
    {
        
        followers.Calm ();
        Debug.Log("Neutral Event Occurred");
		UIMain.NewEvent (chooserofeventts.Nec.events[0].neutraleventsvariation,new string[0],new int[0],0,-1);
        timerRunning = true;
    }

    //Details on what happens in a good event
    void goodEvent(int eventSeverity)
    {
        audio.PlayOneShot(goodEventSound);
		followers.Celebrate ();
		//Grando = Random.Range (0, 15);
		//timerRunning = false;
        Debug.Log("Good Event Occurred with severity of " + eventSeverity);
		UIMain.NewEvent (chooserofeventts.Gec.events[0].goodeventsvariation,new string[0],new int[0],0,-1);
		//UIMain.NewEvent ("Good event", new string[]{"option1","o2"}, new int[]{0,12}, (1 +eventSeverity) * -1);
		//UIMain.NewOutcome ("Good EventResolution");
        GoodEventEnd(0, eventSeverity);
    }

	public void GoodEventEnd(int optionSelected,int sevarity)
    {
        
        if (sevarity == 0) {
			numberOfFollowersUpdate (5);
			UIMain.NewOutcome (chooserofeventts.Gec.events [0].response1);
		} else if (sevarity == 1) {
			numberOfFollowersUpdate (10);
			UIMain.NewOutcome (chooserofeventts.Gec.events [0].response2);
		} else if (sevarity == 2) 
		{
			numberOfFollowersUpdate (15);
			UIMain.NewOutcome (chooserofeventts.Gec.events [0].response3);
		}
        timerRunning = true;
    }

    static void numberOfFollowersUpdate(int k)
    {
        if(k < 0)
        {
            totalFollowersLost -= k;
        }
        numberofFollowers += k;
        UIMain.FollowerChanged(true, k);
    }

    void powerUpdate(int k)
    {
        powerLeft += k;
        UIMain.PowerChanged(true, k);
    }

    //Details when event Occurs
    void eventOccurred()
    {
        //Defines whether event is bad, neutral or good
        int eventType = Random.Range(0, 11);

        if (eventType > 3)
        {
            int eventSeverity = Random.Range(0, 3);
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
        yearsLasted += 1;

        timeForSacrifice();
		eventCounter = 12;
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
            int eventProbability = 2;
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
            int eventProbability = 2;

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
            int eventProbability = 2;
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
            int eventProbability = 2;

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
            int eventProbability = 2;

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
            int eventProbability = 2;

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
            int eventProbability = 2;

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
            int eventProbability = 2;

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
            int eventProbability =2;

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
            int eventProbability = 2;

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
            int eventProbability = 2;

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
            int eventProbability = 2;

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

        if(numberofFollowers <=0)
        {
            
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

    void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 90), yearTimer.ToString());
    }

    void followersIncreaseRandomly()
    {
        if(followersIncreaseTimes>0)
        {
            int randomlyIncreaseFollowers = Random.Range(0, 3);
            if (randomlyIncreaseFollowers == 2)
            {
                int increase = Random.Range(0, 3);
                numberofFollowers += increase;
                UIMain.FollowerChanged(true, increase);
                followersIncreaseTimes--;
            }

        }
    }


	float randomPercentage(int average){
        if(numberofFollowers < 20)
        {
            if (average > 0)
            {
                average += 20;
            }
            else
            {
                average -= 20;
            }
        }
		return Random.Range (average - 1, average + 2) * 0.01f;
	}
	void followersChange(int averagePercentage){
        int followersIncrease;
        float change = randomPercentage(averagePercentage) * numberofFollowers;
        if(change >= 0)
        {
            followersIncrease = (int)Mathf.Ceil(change);
        }
        else
        {
            followersIncrease = (int)Mathf.Floor(change);
        }
		
		numberOfFollowersUpdate(followersIncrease);
	}
}
