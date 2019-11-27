using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour {

    private int playerHealth = 5;
    private int enemyThrough = 1;

    public Text healthText;

	// Use this for initialization
	void Start () {
        UpdateHealth();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0)
        {
            SceneManager.LoadScene("03 Lose");
        }
        
	}

    void UpdateHealth()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth -= enemyThrough;
        Debug.Log(collision + " Passed");
        UpdateHealth();
    }
}
