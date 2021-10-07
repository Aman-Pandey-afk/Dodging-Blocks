using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Text secondsSurvived;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(600, 1000, true);
        FindObjectOfType<PlayerControl>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0); 
            }
        }
    }
    void OnGameOver()
    {
        GameOverScreen.SetActive(true);
        secondsSurvived.text = (Mathf.Round(Time.timeSinceLevelLoad*10)/10f).ToString() + "s";
        gameOver = true;
    }
}
