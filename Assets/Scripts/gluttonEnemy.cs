using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gluttonEnemy : parentEnemy {
    public float speed;
    Rigidbody2D enemyBod;

    void Start () {
        enemyBod = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
        if (pickups.Length > 0)
        {
            float minDistance = -1;
            GameObject closest = null;
            foreach (var item in pickups)
            {
                float dist = Vector2.Distance(enemyBod.position, item.transform.position);
                if (closest == null || dist < minDistance)
                {
                    minDistance = dist;
                    closest = item;
                }
            }

            if (closest != null) {
                float z = Mathf.Atan2((closest.transform.position.y - transform.position.y),
                (closest.transform.position.x - transform.position.x))
                * Mathf.Rad2Deg - 90;

                transform.eulerAngles = new Vector3(0, 0, z);
                enemyBod.AddForce(gameObject.transform.up * speed, ForceMode2D.Impulse);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PickUp"))
        {
            TakeHeals(10);
            col.gameObject.SetActive(false);
        }
    }

    void TakeHeals(float healsAmount)
    {
        health += healsAmount;
    }
}
