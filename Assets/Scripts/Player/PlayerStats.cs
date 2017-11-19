using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	[SerializeField]
	private Stat health;

    public float coolDownTime;

    [SerializeField]
	private float playerScore;


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


	public float getScore
	{
		get
		{
			return playerScore;
		}
	}

	public void addToPlayerScore(float scoreIncrease)
	{
		playerScore += scoreIncrease;
	}

    public void getHurt(int dmgAmount)
    {
        health.CurrentVal -= dmgAmount;
    }
    public void getHealed(int healedAmount)
    {
        health.CurrentVal += healedAmount;
    }
}
