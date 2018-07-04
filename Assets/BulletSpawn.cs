using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject spawnedBullet;

    public float speed;
    public int shootTime = 100;
    int shootCount = 0;
    bool canFire = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootCount++;
        if (shootCount >= shootTime)
        {
            canFire = true;
            shootCount = 0;
        }

        if ( GetComponentInParent<Player>().GetSpecial() && canFire)
        {
            spawnedBullet = GameObject.Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -2), transform.rotation) as GameObject;

            spawnedBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0,speed));
            canFire = false;
        }
    }
}
