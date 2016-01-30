using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoUpdater : MonoBehaviour {

	public Text followers;
	public Text power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		followers.text = "" + MainEngine.numberofFollowers;
		power.text = "" + MainEngine.powerLeft;
	}
}
