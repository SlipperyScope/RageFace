using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentEnemy : MonoBehaviour {
    public int damage;
    public float score;
    public float health;

    private AudioSource enemyGetsHurtNoiseAudioSource;
	public AudioClip enemyGetsHurtNoise;

    private bool isCooling = false;
    private float coolDownTime = .12f;
    private PlayerStats stats;

	private void Awake()
	{
		enemyGetsHurtNoiseAudioSource = GetComponent<AudioSource>();
	}

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        enemyGetsHurtNoiseAudioSource.PlayOneShot(enemyGetsHurtNoise, 50);
        if(health <= 0)
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            stats.addToPlayerScore(score);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!isCooling && col.gameObject.CompareTag("Aura"))
        {
            if (col.gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                isCooling = true;
                float damage = col.gameObject.GetComponent<auraChecking>().damage;
                TakeDamage(damage);
                Invoke("stopCooling", coolDownTime);
            }
        }
    }
    private void stopCooling()
    {
        isCooling = false;
    }
}
