using UnityEngine;
using System.Collections;

public class candySpawn : MonoBehaviour {
    public GameObject candyPrefab;
    public GameObject spawnedObject;

    float timeOfLastWave = 0;
    float timeBetweenWaves = 3.0f;

    void Update()
    {
        if ((Time.time == 0) || (Time.time - timeOfLastWave > timeBetweenWaves))
        {
            int n = (Random.Range(1, 10));
            timeOfLastWave = Time.time;

            if (n <= 6)
            {
                spawnedObject = GameObject.Instantiate(candyPrefab, transform.position, transform.rotation) as GameObject;
                timeBetweenWaves = Random.Range(0.1f, 1.0f);
            }
        }
    }
}
