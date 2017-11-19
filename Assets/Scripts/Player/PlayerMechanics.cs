using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

	public float punchForce = 50;
	public float punchRange = 10;

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
		var origin = transform.position;
		var offset = transform.right * 1.13f;

		var hits = new HashSet<RaycastHit2D>();
		foreach (var hit in Physics2D.RaycastAll(origin, transform.up, punchRange)) {
			hits.Add(hit);
		}
		foreach (var hit in Physics2D.RaycastAll(origin + offset, transform.up, punchRange)) {
			hits.Add(hit);
		}
		foreach (var hit in Physics2D.RaycastAll(origin + -offset, transform.up, punchRange)) {
			hits.Add(hit);
		}
		
		foreach(var hit in hits) {
			if (hit.transform == transform) { continue; }

			var rb = hit.transform.gameObject.GetComponent<Rigidbody2D>();
			if (rb) {
				rb.AddForce(
					new Vector2(transform.up.x, transform.up.y) * punchForce,
					ForceMode2D.Impulse
				);
			}
		}
	}
}
