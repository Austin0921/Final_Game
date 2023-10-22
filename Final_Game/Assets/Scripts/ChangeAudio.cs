using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeAudio : MonoBehaviour
{

    public static ChangeAudio musicplay;
    public GameObject music;

    private string firstLevelName = "Main"; // Replace with your actual first level scene name

    void Awake()
    {
        if (musicplay == null)
        {
            DontDestroyOnLoad(gameObject);
            musicplay = this;
        }
        else if (musicplay != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the newly loaded scene is the first level
        if (scene.name == firstLevelName)
        {
            // Stop the music
            StopMusic();
        }
    }

    private void StopMusic()
    {
        if (music != null)
        {
            AudioSource audioSource = music.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

