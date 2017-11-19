using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraScript : MonoBehaviour {

	private PlayerStats stats;

	private SpriteRenderer aura1;
	private SpriteRenderer aura2;

	private float playerHealth;

	// Use this for initialization
	void Start () {
		stats = GetComponent <PlayerStats>();
		playerHealth = stats.getPlayerHealth();
		aura1 = transform.Find("Aura_1").gameObject.GetComponent<SpriteRenderer>();
		aura2 = transform.Find("Aura_2").gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = stats.getPlayerHealth();
		if(playerHealth < 33.0)//all aura's on
		{
			aura1.enabled = true;
			aura2.enabled = true;
		}
		else if(playerHealth < 66.0)//third aura off
		{
			aura1.enabled = true;
			aura2.enabled = false;
		}
		else//Both off
		{
			aura1.enabled = false;
			aura2.enabled = false;
		}
		
		
	}
}
