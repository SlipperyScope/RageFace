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
	[SerializeField]
	private Text comboScore;

	private int combo;
	public float maxPlayerHealthValue { get; set; }

	public float Value
	{
		set
		{
			fillAmount = mapPlayersHealthToTheHealthBar(value,0,maxPlayerHealthValue,0,1);

			if(value<=100 && value >67)
			{
				combo = 1;
			}
			else if(value <= 67  && value > 33)
			{
				combo = 2;
			}
			else if(value <= 33  && value > 15)
			{
				combo = 3;
			}
			else if(value <= 15  && value > 5)
			{
				combo = 4;
			}
			else if(value <= 5)
			{
				combo = 5;
			}


			comboScore.text =""+combo+"X!!";
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
