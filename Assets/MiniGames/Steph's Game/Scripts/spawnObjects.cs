using UnityEngine;
using System.Collections;

public class spawnObjects : MonoBehaviour {

    public GameObject boxPrefab;
    public GameObject stickyPrefab;
    public GameObject bombPrefab;
    public GameObject spawnedObject;

    float timeOfLastWave = 0;
    float timeBetweenWaves = 2.5f;

    void Update()
    {
        if ((Time.time == 0) || (Time.time - timeOfLastWave > timeBetweenWaves))
        {
            int n = (Random.Range(1, 11));
            timeOfLastWave = Time.time;

            if (n <= 6)
            {
                spawnedObject = GameObject.Instantiate(boxPrefab, transform.position, transform.rotation) as GameObject; 
            }
            else if (n >= 9)
            {
                spawnedObject = GameObject.Instantiate(bombPrefab, transform.position, transform.rotation) as GameObject;
            }
            else 
            { 
                spawnedObject = GameObject.Instantiate(stickyPrefab, transform.position, transform.rotation) as GameObject;
            }
        }
    }
}
