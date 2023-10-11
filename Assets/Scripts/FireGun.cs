using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] private float delaySpeed = 2f;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform bulletSpawn;
    void Start()
    {
        Invoke("SpawnBullet", delaySpeed);
    }

    public void SpawnBullet()
    {
        Quaternion bulletPoint = Quaternion.identity;
        bulletPoint.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x + 90, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);

        Instantiate(prefabBullet, bulletSpawn.position, bulletPoint);
        Invoke("SpawnBullet", delaySpeed);
    }
}
