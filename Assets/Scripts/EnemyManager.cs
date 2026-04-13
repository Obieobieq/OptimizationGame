using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] enemySpawnPoints;

    public float maxTimer = 2f;
    private float currentTimer;

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTimer = maxTimer;
        InvokeRepeating("SpawnEnemy", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns in enemies every 2 seconds, unless player has lost
    void SpawnEnemy()
    {
        int randomLocation = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemyPrefab, enemySpawnPoints[randomLocation].position, Quaternion.identity);
        if (gameManager.playerLives == 0)
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
