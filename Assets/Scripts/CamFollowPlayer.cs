using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour {
	public Transform playerLocation;
	
	private float distanceFromPlayer = 10.0f;
	public void Update()
	{
	   transform.position = playerLocation.position + new Vector3(0,0,-distanceFromPlayer);
		Debug.Log("Camera: " + transform.position.ToString());
	}
}
