using UnityEngine;
using System.Collections;

public class SetColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
        Renderer rend = GetComponent<MeshRenderer>();
        rend.material.color = new Color(Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f), Random.Range(0.2f, 1.0f));

    }
	
	
}
