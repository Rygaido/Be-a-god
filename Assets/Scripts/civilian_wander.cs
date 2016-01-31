using UnityEngine;
using System.Collections;

public class civilian_wander : MonoBehaviour {

	float walkChance = 0.2f; //how likely an idle civilian is to start walking (1.0 is 100%, 0.0 is never)

	//the minimum and maximum speed an idle civilian may start moving at
	float maxSpeed = 0.50f;
	float minSpeed = 0.25f;

	//the minimum and maximum lengths of time an idle civilian will spend doing one thing, then switches randomly to something else
	float stateTimerMax = 2;
	float stateTimerMin = 1;

	//how far civilian can wander from center screen //USE MANAGER BOUNDARYX & Z
	//float boundary = 3;

	float speed = 0;
	float direction = 0;
	float stateTimer = 0;


	//static Random r = new Random();

	bool jumping = false;
	float y0 = 0.0f;
	float jumpHeight = 0.1f;
	float j=0.0f;
	bool falling=false;
	float jumpSpeed=0.5f;
	float jumpDelay = -1.0f;//randomizes jump timing
	public civilian_manager manager;

	// Use this for initialization
	void Start () {
        
        Renderer rend = GetComponent<MeshRenderer>();
        y0 = transform.position.y;
        rend.material.color = new Color(Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f));
    }
	
	// Update is called once per frame
	void Update () {
		if(manager.panic){ //panicing people never slow down
			speed = maxSpeed;
		}
		if (speed > 0.0f) {
			transform.position += transform.forward * speed * Time.deltaTime; //apply movement
			//transform.Translate(transform.forward * speed * Time.deltaTime); //apply movement
		}
		enforceBoundary ();

		stateTimer -= Time.deltaTime; //decrement timer

		//time up, choose a new actions
		if (stateTimer <= 0) {

			if(!manager.joy && (manager.panic || Random.Range(0.0f,1.0f) <= walkChance)){ //walk in random direction (wander)
				//random chance to walk, unless panicing

				if(!manager.panic){ //random speed assigned, never during a panic
					speed = Random.Range (minSpeed, maxSpeed);
				}
				direction = Random.Range (0, 360);

				transform.Rotate(Vector3.up, direction);
			}
			else{ //stand still
				direction=0;
				speed=0;
			}

			stateTimer = Random.Range(stateTimerMin,stateTimerMax);
		}

		if (manager.panic) {

			if (!jumping) {
				if (jumpDelay == -1.0f) {
					jumpDelay = Random.Range (0.0f, 0.5f);
				} 
				if (jumpDelay >= 0) {
					jumpDelay -= Time.deltaTime;
					if(jumpDelay <= 0){
						jumping = true;
						jumpDelay = -1;
					}
				} 
			}
		} else {
			jumpDelay = -1.0f;
		}
		if (manager.joy) {
			jumping = true;
			speed = 0;
		}

		if (!manager.panic && !manager.joy) {
			jumping = false;
		}

		//make civs jump while walking, comment out to remove
		//jumping = (speed > 0);

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
		if (Mathf.Abs(transform.position.x) > manager.boundaryX || Mathf.Abs(transform.position.z) > manager.boundaryZ) {
			Vector3 toCenter = -transform.position;
			toCenter.y =0;
			transform.rotation = Quaternion.LookRotation(toCenter, Vector3.up);
			speed = minSpeed;
			//transform.LookAt(Vector3.zero);
			//transform.Rotate(transform.up, );
		}
	}
}
