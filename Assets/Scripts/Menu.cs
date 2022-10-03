using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject startBtn, nextBtn, menuCanvas;

    public bool isGameStarted = false;

    public void Start()
    {
        isGameStarted = false;
        FindObjectOfType<Player>().speed = 0f;
        nextBtn = GameObject.Find("MenuCanvas").transform.Find("NextBtn").gameObject;
        startBtn = GameObject.Find("MenuCanvas").transform.Find("StartBtn").gameObject;
        menuCanvas = GameObject.Find("MenuCanvas").gameObject;
    }

    public void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<Player>().speed = 30f;
        FindObjectOfType<LevelManager>().Respawn();
        menuCanvas.SetActive(false);
    }

    public void NextLevel()
    {
        Debug.Log("Level Complete");
        menuCanvas.SetActive(false);
        FindObjectOfType<LevelManager>().Respawn();
        FindObjectOfType<LevelManager>().SpawnNextLevel();
    }
    public void LevelEnd()
    {
        menuCanvas.SetActive(true);
        startBtn.SetActive(false);
        nextBtn.SetActive(true);
    }
}
