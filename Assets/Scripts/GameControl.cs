using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text lifeCount;
    public Text victoryText;

    private bool dead = false;
    private bool victorious = false;
    private int totalKilled = 0;
    private int roundNumber = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((dead || victorious) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if ((dead || victorious) && Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (victorious && !dead)
        {
            gameOverText.SetActive(true);
            victoryText.text = "You Win! Press 'R' to Restart or Press 'M' for Main Menu";
        }
    }

    public void PlayerDied()
    {
        gameOverText.SetActive(true);
        dead = true;
    }

    public void RunningKills()
    {
        if (dead)
        {
            return;
        }
        ++totalKilled;
        if (totalKilled == 20 && roundNumber == 0)
        {
            victorious = true;
        }

        if (totalKilled == 1 && roundNumber == 1)
        {
            victorious = true;
        }
    }

    public void DeductHealth(int hp)
    {
        lifeCount.text = "HP: " + hp.ToString();
    }
}
