using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject map;
    public float spawnTime = 3f;

    private float xRange;
    private float yRange;
    // Use this for initialization
	void Start () {
        map = GameObject.FindGameObjectWithTag("Map");
        xRange = map.GetComponent<Renderer>().bounds.size.x / 2;
        yRange = map.GetComponent<Renderer>().bounds.size.y / 2;

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        Instantiate(enemy, new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0), new Quaternion());
    }
}