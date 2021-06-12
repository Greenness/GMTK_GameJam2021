using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    
    ObjectPooler bulletPooler;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletPooler = new ObjectPooler(bulletPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject shootNewBullet(Vector3 bulletStartPosition, Vector2 bulletTravelVector) {
        GameObject newBullet = bulletPooler.GetPooledObject();
        if (newBullet != null) {
            newBullet.transform.position = bulletStartPosition;

            BulletBehavior newBulletScript = newBullet.GetComponent<BulletBehavior>();
            newBulletScript.movement = bulletTravelVector;
            newBullet.SetActive(true);
        }
        return newBullet;
    }
}
