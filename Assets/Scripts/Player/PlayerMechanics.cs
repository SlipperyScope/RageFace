using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			anim.SetTrigger("Punch");
			this.Punch();
		}
	}

	void Punch() {
		var offset = transform.right * 1.13f;
		Debug.DrawRay(transform.position, transform.up * 10, Color.yellow, 1f);
		Debug.DrawRay(transform.position + offset, transform.up * 10, Color.yellow, 1f);
		Debug.DrawRay(transform.position + offset * -1, transform.up * 10, Color.yellow, 1f);
		Debug.Log(transform.eulerAngles.ToString());
	}
}
