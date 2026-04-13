using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    private int playerLivesMax = 3;
    public int playerScore;
    private int timesDamaged = 0;

    public GameObject playerPrefab;
    public TMP_Text scoreText;

    private GameObject[] enemies;

    public GameObject[] health;

    public void ResetGame()
    {
        playerLives = playerLivesMax;
        playerScore = 0;
    }

    public void HealthLowered()
    {
        health[timesDamaged].SetActive(false);
        timesDamaged++;
    }

    public void UpdateScore(int score)
    {
        playerScore += score;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void RemoveEnemies()
    {
        if (playerLives == 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
    }
}
