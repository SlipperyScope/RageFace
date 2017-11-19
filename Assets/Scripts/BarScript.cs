using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public class BarScript : MonoBehaviour {

	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image healthBar;

	public float maxPlayerHealthValue { get; set; }

	public float Value
	{
		set
		{
			fillAmount = mapPlayersHealthToTheHealthBar(value,0,maxPlayerHealthValue,0,1);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		handleBar();
	}

	private void handleBar()
	{
		if(fillAmount != healthBar.fillAmount)
		{
			healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,fillAmount,Time.deltaTime*lerpSpeed);
		}

	}

	private float mapPlayersHealthToTheHealthBar(float playersHealth, float minPlayerHealth, float maxPlayerHealth, 
													float minOutValue, float maxOutValue)
	{
		return (playersHealth - minPlayerHealth) * (maxOutValue-minOutValue) / (maxPlayerHealth-minPlayerHealth) + minOutValue;
	}
}
