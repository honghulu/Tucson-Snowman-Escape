using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamRandomSpawn : MonoBehaviour
{
    public float timeToSpawn;
    private float timeToSpawnCopy;
    public GameObject iceCream;

    void Start() {
        timeToSpawnCopy = timeToSpawn;
    }

    void Update() {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0) {
            Instantiate<GameObject>(iceCream, new Vector3(Random.Range(-9, 8), 4f, 0f), this.transform.rotation);
            timeToSpawn = timeToSpawnCopy;
        }
    }
}
