using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Player player;

    public bool isLevelSpawned = false;

    public GameObject worldPrefab;
    public GameObject playerPrefab;
    public GameObject canvasPrefab;
    public List<GameObject> levels;

    int lnum = 0;

    public Text levelNumberTxt;

    private void Awake()
    {
        SpawnGameRoots();
        levelNumberTxt = GameObject.Find("LevelNumberTxt").GetComponent<Text>();
        player = GameObject.Find("Player(Clone)").GetComponent<Player>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        player.score = 0;
        levelNumberTxt.text = "Level " + lnum;
        levels[lnum].SetActive(true);
    }

    public void SpawnNextLevel()
    {
        lnum++;
        Respawn();
        
        if (lnum >= levels.Count)
        {
            lnum = 0;
        }

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
        levels[lnum].SetActive(true);
        levelNumberTxt.text = "Level " + lnum;
    }

    public void Respawn()
    {
        player.transform.position = new Vector3(0, 1, 0);
        player.speed = 30f;
    }

    public void Restart()
    {
        Invoke("Respawn", 2f);
    }

    public void SpawnGameRoots()
    {
        Instantiate(worldPrefab, transform.position, Quaternion.identity);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Instantiate(canvasPrefab, transform.position, Quaternion.identity);
    }
}
