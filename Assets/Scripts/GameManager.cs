using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    private int playerLivesMax = 3;
    public int playerScore;
    private int timesDamaged = 0;
    private int spawnRate = 1;

    private float oldScore = 0f;

    public bool playerDied;
    
    public GameObject gameOver;
    public GameObject HUD;

    public Transform playerSpawn;

    public GameObject playerObject;
    public TMP_Text scoreText;

    private GameObject[] enemies;

    public GameObject[] health;

    public EnemyManager enemyManager;

    private void Start()
    {
        playerObject.transform.position = playerSpawn.position;
        HUD.SetActive(true);
        gameOver.SetActive(false);
    }

    public void ResetGame()
    {
        playerLives = playerLivesMax;
        playerScore = 0;
    }

    public void HealthLowered()
    {
        health[timesDamaged].SetActive(false);
        timesDamaged++;
        if (timesDamaged == 3)
        {
            Time.timeScale = 0f;
            playerDied = true;
            HUD.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    public void UpdateScore(int score)
    {
        playerScore += score;
        scoreText.text = "Score: " + playerScore.ToString();
        float difficultyLevel = Mathf.Floor(playerScore/100);
        if (oldScore != difficultyLevel)
        {
            IncreaseEnemySpawning();
        }
        oldScore = difficultyLevel;
    }

    void IncreaseEnemySpawning()
    {
        spawnRate++;
        enemyManager.CancelInvoke("SpawnEnemy");
        enemyManager.InvokeRepeating("SpawnEnemy", 2f/spawnRate, 2f/spawnRate);
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
