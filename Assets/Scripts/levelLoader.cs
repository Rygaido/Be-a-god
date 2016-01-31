using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour {

    public GameObject[] instructionTexts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    public void InstructionText()
    {
        for(int i = 0; i < instructionTexts.Length; i++)
        {
            instructionTexts[i].SetActive(true);
        }
    }
}
