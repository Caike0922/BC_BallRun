using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody rb;

    float horizontalInput;

    public int score = 0;

    public Text scoreCoin;

    public Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<Menu>();
        scoreCoin = GameObject.Find("CoinTxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalInput = Input.GetAxis("Mouse X");
        }

        if(rb.position.y <= -5)
        {
            Debug.Log("You fell");
            speed = 0f;
            FindObjectOfType<LevelManager>().Restart();
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    public void AddScore()
    {
        score++;
        scoreCoin.text = "Coin : " + score;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToString() == "End")
        {
            Debug.Log("Reached end of the level.");
            menu.LevelEnd();
        }
        if (other.gameObject.name == "Player(Clone)")
        {
            Debug.Log("Game Over");
            speed = 0f;
            FindObjectOfType<LevelManager>().Restart();
        }
    }
}
