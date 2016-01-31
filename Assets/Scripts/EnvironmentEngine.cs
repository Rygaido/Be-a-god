using UnityEngine;
using System.Collections;

public class EnvironmentEngine : MonoBehaviour {

    // Fields
    private GameObject[] clouds;

    /// <summary>
    /// Speed of cloud movement.
    /// </summary>
    //public float speed = 10.0f;
    public Vector3 velocity = new Vector3(10.0f, 0f, 5.0f);
    public float rangeX = 20.0f;
    public float rangeZ = -10.0f;
    public GameObject cloudPrefab;
    public GameObject cloudSpawnPoint;

    // Range transforms
    private Vector3 minBoundry;
    private Vector3 maxBoundry;

    // Use this for initialization
    void Start () {

        clouds = new GameObject[20];

        Vector3 randomLocation;
        // Start with LEN clouds for debug
        for (int i = 0; i < clouds.Length; i++)
        {
            randomLocation = new Vector3(
                Random.Range(cloudSpawnPoint.transform.position.x, cloudSpawnPoint.transform.position.x + rangeX),
                cloudSpawnPoint.transform.position.y,
                Random.Range(cloudSpawnPoint.transform.position.z, cloudSpawnPoint.transform.position.z - rangeZ)
            );
            clouds[i] = (GameObject)Instantiate(cloudPrefab, randomLocation, Quaternion.AngleAxis(-90, Vector3.right));
        }

        // setup boundary transforms
        minBoundry = transform.position;
        maxBoundry = new Vector3(transform.position.x + rangeX, 0, transform.transform.position.z + rangeZ);

        
	}
	
	// Update is called once per frame
	void Update () {
        // Move the cloud across the sky!
        for (int i = 0; i < clouds.Length; i++)
        {
            // check for wrap around and react
            if (clouds[i].transform.position.x > maxBoundry.x)
                clouds[i].transform.position = new Vector3(minBoundry.x, clouds[i].transform.position.y, clouds[i].transform.position.z);
            if (clouds[i].transform.position.x < minBoundry.x)
                clouds[i].transform.position = new Vector3(maxBoundry.x, clouds[i].transform.position.y, clouds[i].transform.position.z);

            // fix this
            if (clouds[i].transform.position.z > maxBoundry.z)
                clouds[i].transform.position = new Vector3(clouds[i].transform.position.x, clouds[i].transform.position.y, minBoundry.z);
            if (clouds[i].transform.position.z < minBoundry.z)
                clouds[i].transform.position = new Vector3(clouds[i].transform.position.x, clouds[i].transform.position.y, maxBoundry.z);
                
            // move the cloud
            clouds[i].transform.position = clouds[i].transform.position + (velocity * Time.deltaTime);
        }
    }


}
    