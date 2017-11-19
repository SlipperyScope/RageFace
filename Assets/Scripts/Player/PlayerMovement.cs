using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	Rigidbody2D playerBod;
    PlayerStats stats;
    bool cooling = false;
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
            Destroy(stats.gameObject);
            SceneManager.LoadScene("Master_Scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PickUp")) {
            stats.getHealed(20);
            col.gameObject.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (!cooling && (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Sloth") || col.gameObject.CompareTag("Glutton")))
        {
            cooling = true;
            int damage = col.gameObject.GetComponent<parentEnemy>().damage;
            stats.getHurt(damage);
            Invoke("stopCooling", stats.coolDownTime);
        }
        else if (!cooling && col.gameObject.CompareTag("Greed"))
        {
            cooling = true;
            int pointLoss = col.gameObject.GetComponent<parentEnemy>().damage;
            stats.losePoints(pointLoss);
            Invoke("stopCooling", stats.coolDownTime);
        }
        else if (!cooling && col.gameObject.CompareTag("Lust"))
        {
            cooling = true;
            int healthGain = col.gameObject.GetComponent<parentEnemy>().damage;
            stats.getHealed(healthGain);
            Invoke("stopCooling", stats.coolDownTime);
        }
    }

    private void stopCooling()
    {
        cooling = false;
    }
}