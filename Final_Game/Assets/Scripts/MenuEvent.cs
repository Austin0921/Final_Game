using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MenuEvent : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        Time.timeScale = 1;
        mixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
        mixer.SetFloat("Volume", volumeSlider.value);

    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
