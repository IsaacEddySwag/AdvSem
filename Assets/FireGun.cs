using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] private float delaySpeed = 2f;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform bulletSpawn;
    void Update()
    {
        Invoke("SpawnBullet", delaySpeed);
    }

    public void SpawnBullet()
    {
        Instantiate(prefabBullet, bulletSpawn.position, gameObject.transform.rotation);
    }
}
