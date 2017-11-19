using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameoverScript : MonoBehaviour {
    [SerializeField]
    private Text scoreBoardText;
    [SerializeField]
    private Text killCountText;
    public float score = 0;
    public int killCount = 0;

	void Start () {
        var playerStats = GameObject.FindObjectOfType<PlayerStats>();
        score = playerStats.getScore;
        killCount = playerStats.getKillCount;
        Destroy(playerStats.gameObject);
	}
	
	void Update () {
        scoreBoardText.text = "" + (int)score;
        killCountText.text = "" + killCount;
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
