using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	Rigidbody2D playerBod;
    PlayerStats stats;
	void Start() {
		playerBod = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
	}
	
	void FixedUpdate () {
		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		playerBod.angularVelocity = 0;

		//playerBod.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
		playerBod.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed),ForceMode2D.Impulse);
	}

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PickUp")) {
            stats.getHealed(20);
            col.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Sloth"))
        {
            int damage = col.gameObject.GetComponent<parentEnemy>().damage;
            stats.getHurt(damage);
        }
    }
}