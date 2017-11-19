﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	[SerializeField]
	private Stat health;


	// Use this for initialization
	private void Awake()
	{
		health.Initialize();
	}

	public float getPlayerHealth()
	{
		return health.CurrentVal;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal-=10;
		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			health.CurrentVal+=10;
		}
	}
}
