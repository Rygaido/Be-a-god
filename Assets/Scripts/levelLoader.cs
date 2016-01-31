using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour {

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
}
