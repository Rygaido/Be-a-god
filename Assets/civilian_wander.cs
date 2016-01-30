using UnityEngine;
using System.Collections;

public class civilian_wander : MonoBehaviour {

	float maxSpeed = 1;
	float speed = 0;

	float stateTimerMax = 1;
	float stateTimer = 0;

	float boundary = 1;

	static Random r;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speed = 0;
	}
}
