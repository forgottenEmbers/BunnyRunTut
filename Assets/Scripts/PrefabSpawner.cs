using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour {

    // Private Variables
    private float nextSpawn = 0f;

    // Public Variables
    public Transform prefabToSpawn;
    public float spawnRate = 1f;
    public float randomDelay = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
	
	}
}
