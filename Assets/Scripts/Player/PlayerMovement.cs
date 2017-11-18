using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 30;
	Rigidbody2D playerBod;
	void Start() {
		playerBod = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PickUp")) {
            col.gameObject.SetActive(false);
        }
    }
}
