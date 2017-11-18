using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject objectToSpawn;
    public GameObject map;
    public float spawnTime;
    public int spawnLimit = 0;

    private float xRange;
    private float yRange;
    // Use this for initialization
	void Start () {
        map = GameObject.FindGameObjectWithTag("Map");
        xRange = (map.GetComponent<Renderer>().bounds.size.x / 2) - 10;
        yRange = (map.GetComponent<Renderer>().bounds.size.y / 2) - 10;

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn () {
        if (spawnLimit == 0 || GameObject.FindGameObjectsWithTag(objectToSpawn.tag).Length < spawnLimit) {
            Instantiate(objectToSpawn, new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0), new Quaternion());
        }
    }
}