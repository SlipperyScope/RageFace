using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentEnemy : MonoBehaviour {
    public int damage;
    public float score;
    public float health;
    private PlayerStats stats;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

    public void enemyDead(float hitpointsTakenByBadGuy)
    {
        if(health <= 0)
        {
            stats = GetComponent <PlayerStats>();
            stats.addToPlayerScore(score);
            gameObject.SetActive(false);
        }
    }
}
