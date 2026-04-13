using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    private int playerLivesMax = 3;
    public int playerScore;

    public GameObject playerPrefab;
    private GameObject[] enemies;

    public void ResetGame()
    {
        playerLives = playerLivesMax;
        playerScore = 0;
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
