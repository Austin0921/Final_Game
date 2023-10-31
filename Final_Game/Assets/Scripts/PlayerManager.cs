using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2(0,0);
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
    public GameObject pauseMenuScreen;

    public void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject Player = Instantiate(playerPrefabs[characterIndex],lastCheckPointPos,Quaternion.identity);
        VCam.m_Follow = Player.transform;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
