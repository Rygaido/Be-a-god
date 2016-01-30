using UnityEngine;
using System.Collections;

public class civilian_wander : MonoBehaviour {

	float walkChance = 0.5f; //how likely an idle civilian is to start walking (1.0 is 100%, 0.0 is never)

	//the minimum and maximum speed an idle civilian may start moving at
	float maxSpeed = 0.50f;
	float minSpeed = 0.25f;

	//the minimum and maximum lengths of time an idle civilian will spend doing one thing, then switches randomly to something else
	float stateTimerMax = 2;
	float stateTimerMin = 1;

	//how far civilian can wander from center screen
	float boundary = 3;

	float speed = 0;
	float direction = 0;
	float stateTimer = 0;


	//static Random r = new Random();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (speed > 0.0f) {
			transform.position += transform.forward * speed * Time.deltaTime; //apply movement
			//transform.Translate(transform.forward * speed * Time.deltaTime); //apply movement
		}
		enforceBoundary ();

		stateTimer -= Time.deltaTime; //decrement timer

		//time up, choose a new actions
		if (stateTimer <= 0) {
			if(Random.Range(0.0f,1.0f) <= walkChance){ //walk in random direction (wander)
				
				speed = Random.Range (minSpeed, maxSpeed);
				direction = Random.Range (0, 360);

				transform.Rotate(Vector3.up, direction);
			}
			else{ //stand still
				direction=0;
				speed=0;
			}

			stateTimer = Random.Range(stateTimerMin,stateTimerMax);
		}


	}

	//constrains civilians to a square of size "boundary" from origin in all directions
	//sets civilians to move towards center
	void enforceBoundary(){
		if (Mathf.Abs(transform.position.x) > boundary || Mathf.Abs(transform.position.z) > boundary) {
			Vector3 toCenter = -transform.position;
			toCenter.y =0;
			transform.rotation = Quaternion.LookRotation(toCenter, Vector3.up);
			speed = minSpeed;
			//transform.LookAt(Vector3.zero);
			//transform.Rotate(transform.up, );
		}
	}
}
