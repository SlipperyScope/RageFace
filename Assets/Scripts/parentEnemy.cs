using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentEnemy : MonoBehaviour {
    public int damage;
    public float score;
    public float health;
    public Transform map;

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
            if (map) {
                map.GetComponent<BloodManager>().AddBlood(transform.position, transform.rotation, transform.localScale);
            }

            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            stats.addToPlayerScore(score);
            stats.incrementPlayerNumKills();
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
