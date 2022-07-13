using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float spawnRateMin = 0.1f;
    public float spawnRateMax = 5f;

    private Transform target;
    private float spawnRate;
    private float AfterTimeSpawn;
    bool isPlayer = false;

    void Start()
    {
        AfterTimeSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (isPlayer == true)
        {
            AfterTimeSpawn += Time.deltaTime;
            if (AfterTimeSpawn > spawnRate)
            {
                AfterTimeSpawn = 0f;
                GameObject bullet
                    = Instantiate(BulletPrefab, transform.position, transform.rotation);
            }
            gameObject.transform.LookAt(target);
        }
        transform.Rotate(0, 1, 0);
    }

    void OnTriggerStay(Collider other)
    {
        isPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayer = false;
    }
}
