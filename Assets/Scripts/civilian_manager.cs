using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class civilian_manager : MonoBehaviour {

	public int population=0;


	public GameObject civilian;

	List<GameObject> people = new List<GameObject>();  

	//how far civilians can wander from the center point in the X or Z directions
	public float boundaryX = 3;
	public float boundaryZ = 3; 

	//whether civilians should be running around wildly, or jumping up and down
	public bool panic=false;
	public bool joy=false;

	// Use this for initialization
	void Start () {
		SetPopulation (100);
	}
	
	// Update is called once per frame
	void Update () {
		if (MainEngine.numberofFollowers != population) {
			SetPopulation (MainEngine.numberofFollowers);
		}
	}

	//sets the number of people on screen to match an integer
	public void SetPopulation(int pop){
		if (pop < population) {
			RemovePeople (population - pop);
		} else if (population < pop) {
			AddPeople (pop-population);
		}

	}
	//raises the number of people on screen by amount
	public void AddPeople(int add){
		for (int i =0; i < add; i++) {
			Vector3 randomLoc = new Vector3(Random.Range(-boundaryX,boundaryX),0,Random.Range(-boundaryZ,boundaryZ));
			GameObject g = (GameObject)Instantiate(civilian,randomLoc,Quaternion.identity); //create a new person

			g.GetComponent<civilian_wander>().manager=this;

			people.Add (g); //add person to list
		}
		population += add; //adjust population number
	}
	//lowers the number of people on screen by amount
	public void RemovePeople(int remove){
		for (int i = 0; i < remove; i++) {
			int r = population-1-i; 	//the index of person about to be removed
			GameObject g = people[r]; 	//the person about to be removed
			people.RemoveAt (r); 		//remove access to person
			Destroy(g);					//kill-- I mean, remove the person
		}
		population -= remove; //adjust population number
	}

	//commence panicing
	public void Panic(){
		joy = false;
		panic = true;
	}
	//commence the dance of joy!
	public void Celebrate(){
		joy = true;
		panic = false;
	}
	public void Calm(){
		joy = panic = false;
	}
}
