using UnityEngine;
using System.Collections;

public class GenericSpawner : MonoBehaviour {

    public GameObject spawn;
    public GameObject spawned;
    public float spawnTime;    
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (spawnTime < time)
        {
            MakeZombie();
            time = 0;
        }
        
    }

    void MakeZombie()
    {
        spawned = GameObject.Instantiate(spawn, transform.position, transform.rotation) as GameObject;
    }
}
