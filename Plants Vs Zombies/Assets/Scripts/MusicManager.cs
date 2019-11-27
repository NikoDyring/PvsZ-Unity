using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChange;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont Destroy On Load:" + name);
    }

    // Update is called once per frame
    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChange[level];
        Debug.Log("Playing Clip:" + thisLevelMusic);
        
        if(thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
