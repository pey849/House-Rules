using UnityEngine;
using System.Collections;

public class FindLeader : MonoBehaviour {
    public string Leader;
    public GameObject[] Player;
	// Use this for initialization
	void Start () {
        Leader = PlayerPrefs.GetString("Leader");
        Player = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in Player)
        {
            if (player.name == Leader)
            {
                player.GetComponent<Leader>().SetLeader();
            }
            else
            {
                player.GetComponent<Leader>().SetHat();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
