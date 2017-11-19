using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameoverScript : MonoBehaviour {
    [SerializeField]
    private Text scoreBoardText;
    public float score = 0;

	void Start () {
        var playerStats = GameObject.FindObjectOfType<PlayerStats>();
        score = playerStats.getScore;
        Destroy(playerStats.gameObject);
	}
	
	void Update () {
        scoreBoardText.text = "" + (int)score;
    }
}
