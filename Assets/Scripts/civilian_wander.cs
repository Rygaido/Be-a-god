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

	public bool jumping = true;
	float y0 = 0.0f;
	float jumpHeight = 0.1f;
	float j=0.0f;
	bool falling=false;
	float jumpSpeed=0.5f;

	// Use this for initialization
	void Start () {
		y0 = transform.position.y;	
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

		//make civs jump while walking, comment out to remove
		jumping = (speed > 0);

		if (jumping) {
			int inverse = 1;
			if (falling) {
				inverse *= -1;
			}

			j += inverse * jumpSpeed * Time.deltaTime;
			transform.position = new Vector3 (transform.position.x, y0 + j, transform.position.z);
			if (j <= 0.0f) {
				j = 0.0f;
				falling = false;
			} else if (j >= jumpHeight) {
				j = jumpHeight;
				falling = true;
			}
		} else if (j > 0.0f) {
			j -= jumpSpeed * Time.deltaTime;
			if(j < 0){j=0;}
			transform.position = new Vector3 (transform.position.x, y0 + j, transform.position.z);
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
