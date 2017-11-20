using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	[SerializeField]
	private Stat health;

    public float coolDownTime;

	[SerializeField]
	private float playerScore;

	[SerializeField]
	private int playerNumKills;

	public int comboMultiplier = 1;
	private AudioSource ouchAudioSource;
	public AudioClip ouchNoise;
	public AudioClip deathSound;
 	
	// Use this for initialization
	
	private void Awake()
	{
        DontDestroyOnLoad(this);
		health.Initialize();
		ouchAudioSource = GetComponent<AudioSource>();
	}

	public float getPlayerHealth()
	{
		return health.CurrentVal;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//The following block of code is used for debugging and needs to be disabled when shipped.
		/*if(Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal-=10;
		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			health.CurrentVal+=10;
		}
		getComboMultiplier(health.CurrentVal);
		*/
	}

	public int getComboMultiplier(float  currentHealth)
	{
			if(currentHealth<=100 && currentHealth >67)
			{
				comboMultiplier = 1;
				return comboMultiplier;
			}
			else if(currentHealth <= 67  && currentHealth > 33)
			{
				comboMultiplier = 2;
				return comboMultiplier;
			}
			else if(currentHealth <= 33  && currentHealth > 15)
			{
				comboMultiplier = 3;
				return comboMultiplier;
			}
			else if(currentHealth <= 15  && currentHealth > 5)
			{
				comboMultiplier = 4;
				return comboMultiplier;
			}
			else if(currentHealth <= 5)
			{
				comboMultiplier = 5;
				return comboMultiplier;
			}
			return 0; //Should never reach this point.
	}

	public float getScore
	{
		get
		{
			return playerScore;
		}
	}

    public int getKillCount
    {
        get
        {
            return playerNumKills;
        }
    }

	public void addToPlayerScore(float scoreIncrease)
	{
		if(health.CurrentVal > 0)
		{
		    playerScore += scoreIncrease * comboMultiplier;
		}
	}

	public void incrementPlayerNumKills()
	{
		if(health.CurrentVal > 0)
		{
            playerNumKills++;
		}
	}

    public void getHurt(int dmgAmount)
    {
        health.CurrentVal -= dmgAmount;
        if (health.CurrentVal <= 0)
        {
            SceneManager.LoadScene("Game_Over");
        } else
        {
		    ouchAudioSource.PlayOneShot(ouchNoise, 5);
        }
    }
    public void getHealed(int healedAmount)
    {
        health.CurrentVal += healedAmount;
    }

    public void losePoints(float pointLoss)
    {
        if (playerScore - pointLoss >= 0)
        {
            playerScore -= pointLoss;
        }
        else
        {
            playerScore = 0;
        }
    }
}
