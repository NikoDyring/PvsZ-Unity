using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefsManager.GetDifficulty());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
