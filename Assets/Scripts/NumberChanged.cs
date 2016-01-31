using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberChanged : MonoBehaviour {

    public AnimationCurve yPosition;
    public Text textObj;
    public string text;
    public Color color;
    private float st;
    public float maxTime;
    private Vector2 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = textObj.transform.position;
        st = Time.time;
        textObj.text = text;
        textObj.color = color;
	}
	
	// Update is called once per frame
	void Update ()
    {
        textObj.transform.position = startPosition + Vector2.up * yPosition.Evaluate((Time.time - st)*0.2f) * -100f;
        color.a = (1f-((Time.time - st) / maxTime));
        textObj.color = color;
        if(((Time.time - st) / maxTime) >= 1)
        {
            Destroy(gameObject);
        }
	}
}
