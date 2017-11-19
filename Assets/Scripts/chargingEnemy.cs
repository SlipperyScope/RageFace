using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargingEnemy : parentEnemy {
    public float speed;
    public Transform player;
    private bool isMoving = false;
    Rigidbody2D enemyBod;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyBod = GetComponent<Rigidbody2D>();
        Invoke("startMove", 2);
    }

    void FixedUpdate () {
        if (isMoving)
        {
            enemyBod.AddForce(gameObject.transform.up * speed, ForceMode2D.Impulse);
        } else
        {
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
                (player.transform.position.x - transform.position.x))
                * Mathf.Rad2Deg - 90;

            transform.eulerAngles = new Vector3(0, 0, z);
        }


        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void startMove()
    {
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isMoving = false;
        Invoke("startMove", 2);
    }
}
