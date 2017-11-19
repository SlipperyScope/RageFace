using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : parentEnemy {

	public float speed = 80;	
	public Transform player;

	public PlayerStats painIncreases;

	Rigidbody2D enemyBod;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		enemyBod = GetComponent<Rigidbody2D>();
		painIncreases = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	


	void FixedUpdate () {

		damage = 2 * painIncreases.comboMultiplier;


		float z = Mathf.Atan2((player.transform.position.y - transform.position.y),
							  (player.transform.position.x - transform.position.x))
							   * Mathf.Rad2Deg - 90;

		transform.eulerAngles = new Vector3(0, 0, z);
		enemyBod.AddForce(gameObject.transform.up * speed);
	}
}
