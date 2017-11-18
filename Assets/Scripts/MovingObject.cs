using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {
	
	public float MoveTime = 0.1f; 		//time it takes object, Secs.
	public LayerMask blockingLayer;		//layer that collison will be checked. 

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
