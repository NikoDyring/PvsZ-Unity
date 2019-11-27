using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds;

    private float secondsLeft;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winText;

	// Use this for initialization
	void Start () {
        winText = GameObject.Find("winText");
        audioSource = GetComponent<AudioSource>();
        slider = gameObject.GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        winText.SetActive(false);
        secondsLeft = levelSeconds;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);

        if(timeIsUp && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
            winText.SetActive(true);
        }
	}

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        
        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
