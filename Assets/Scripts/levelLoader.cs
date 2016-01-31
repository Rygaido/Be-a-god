using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelLoader : MonoBehaviour {

    public GameObject[] instructions;
    public Text yearsLastedText;
  //  public GameObject yearsLastedText;
    public Text followersLostText;

	// Use this for initialization
	void Start () {
	
        if(yearsLastedText != null)
        {
            yearsLastedText.text += ""+MainEngine.yearsLasted;
        }
        if (followersLostText != null)
        {
            followersLostText.text += "" + MainEngine.totalFollowersLost;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
        MainEngine.yearsLasted = 0;
        MainEngine.totalFollowersLost = 0;
    }

    public void InstructionText()
    {
        for(int i = 0; i < instructions.Length; i++)
        {
            instructions[i].SetActive(true);
        }
    }
}
